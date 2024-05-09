using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taller1.Src.Models;

namespace Taller1.Src.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set;} = null!;

        public DbSet<Role> Roles { get; set;} = null!;

        public DbSet<Product> Products { get; set;} = null!;

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}