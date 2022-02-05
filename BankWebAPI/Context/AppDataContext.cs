using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankWebAPI.Context
{
    public class AppDataContext:DbContext
    {

        public AppDataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
