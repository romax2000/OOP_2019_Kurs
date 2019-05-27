using rusty.Resources.Model;
using rusty.Resources.Pages.Cars;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Patterns
{
    class UnitOfWork
    {
        public interface IRepository<T> where T : class
        {
            IQueryable<T> Entities { get; }
            void Remove(T entity);
            void Add(T entity);
        }

        public class GenericRepository<T> : IRepository<T> where T : class
        {
            private readonly STOModelContext _dbContext;
            private IDbSet<T> _dbSet => _dbContext.Set<T>();
            public IQueryable<T> Entities => _dbSet;
            public GenericRepository(STOModelContext dbContext)
            {
                _dbContext = dbContext;
            }
            public void Remove(T entity)
            {
                _dbSet.Remove(entity);
            }
            public void Add(T entity)
            {
                _dbSet.Add(entity);
            }
        }

        public interface IUnitOfWork
        {
            IRepository<Car> CompanyRepository { get; }

            IRepository<Order> PhoneRepository { get; }
            void Commit();
            void RejectChanges();
            void Dispose();
        }
        public class unitOfWork : IUnitOfWork
        {
            private readonly STOModelContext _dbContext;

            public IRepository<Order> CompanyRepository => new GenericRepository<Order>(_dbContext);

            public IRepository<Car> PhoneRepository => new GenericRepository<Car>(_dbContext);//создаем общий контекст для репов

            IRepository<Car> IUnitOfWork.CompanyRepository => throw new NotImplementedException();

            IRepository<Order> IUnitOfWork.PhoneRepository => throw new NotImplementedException();

            public unitOfWork(STOModelContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void Commit()
            {
                _dbContext.SaveChanges();
            }

            public void Dispose()
            {
                _dbContext.Dispose();
            }

            public void RejectChanges()
            {
                foreach (var entry in _dbContext.ChangeTracker.Entries()
                      .Where(e => e.State != EntityState.Unchanged))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                    }
                }
            }
        }
    }
}
