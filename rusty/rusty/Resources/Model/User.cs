using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Lonin { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserType { get; set; }



        public static string getHash(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return "-1";
            }
            else
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
