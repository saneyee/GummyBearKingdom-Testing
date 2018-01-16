using System;
using GummyBearKingdom.Models;
using Microsoft.EntityFrameworkCore;


namespace GummyBearKingdom.Tests.Models
{
    public class TestDbContext : GummyBearKingdomDbContext
    {
        public override DbSet<Property> Properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;port=8889;database=gummybearkingdom_test;uid=root;pwd=root;");
        }
    }
}
