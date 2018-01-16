using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GummyBearKingdom.Models.Repositories
{
    public class EFPropertyRepository : IPropertyRepository
    {
        GummyBearKingdomDbContext db;

        public EFPropertyRepository()
        {
            db = new GummyBearKingdomDbContext();
        }
        public EFPropertyRepository(GummyBearKingdomDbContext thisDb)
        {
            db = thisDb;
        }

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

        public void DeleteAll()
        {
            List<Property> AllProperties = db.Properties.ToList();
            db.Properties.RemoveRange(AllProperties);
            db.SaveChanges();
        }

    }
}
