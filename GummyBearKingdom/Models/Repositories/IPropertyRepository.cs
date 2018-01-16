using System;
using System.Linq;

namespace GummyBearKingdom.Models.Repositories
{
    public interface IPropertyRepository
    {
        IQueryable<Property> Properties { get; }
        Property Save(Property property);
        Property Edit(Property property);
        void Remove(Property property);
    }
}
