// <auto-generated />
namespace rusty.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class Car : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Car));
        
        string IMigrationMetadata.Id
        {
            get { return "201905082226067_Car"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}