using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}