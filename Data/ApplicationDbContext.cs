using Hostapiauthentication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hostapiauthentication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("dbconn") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}