﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GummyBearKingdom.Models.Repositories
{
    public class EFPropertyRepository : IPropertyRepository
    {
        GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();

        public IQueryable<Property> Properties
        { get { return db.Properties; } }

        public Property Save(Property property)
        {
            db.Properties.Add(property);
            db.SaveChanges();
            return property;
        }

        public Property Edit(Property property)
        {
            db.Entry(property).State = EntityState.Modified;
            db.SaveChanges();
            return property;
        }

        public void Remove(Property property)
        {
            db.Properties.Remove(property);
            db.SaveChanges();
        }

    }
}