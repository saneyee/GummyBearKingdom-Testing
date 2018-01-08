﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GummyBearKingdom.Models
{
    public class GummyBearKingdomDbContext : DbContext
    {
        public GummyBearKingdomDbContext()
        {
        }


        public DbSet<Property> Properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummybearkingdom;uid=root;pwd=root;");
        }

        public GummyBearKingdomDbContext(DbContextOptions<GummyBearKingdomDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
