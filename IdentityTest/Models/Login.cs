using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityTest.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        public string usereName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
 
    }
}