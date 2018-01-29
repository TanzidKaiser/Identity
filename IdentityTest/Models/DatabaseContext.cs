using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityTest.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Login> Login { get; set; }
    }
}