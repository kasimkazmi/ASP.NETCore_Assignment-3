using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment03.Models;

namespace Assignment03.Data
{
    public class Assignment03Context : DbContext
    {
        public Assignment03Context (DbContextOptions<Assignment03Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Order> Order { get; set; }
        
    }
}
