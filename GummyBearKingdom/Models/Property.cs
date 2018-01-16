using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummyBearKingdom.Models
{
    
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }



        public override bool Equals(System.Object otherProperty)
        {
            if (!(otherProperty is Property))
            {
                return false;
            }
            else
            {
                Property newProperty = (Property)otherProperty;
                bool EqualId = this.PropertyId.Equals(newProperty.PropertyId);
                bool EqualName = this.Name.Equals(newProperty.Name);
                bool EqualCost = this.Cost.Equals(newProperty.Cost);
                bool EqualDescription = this.Description.Equals(newProperty.Description);
                bool EqualReviewId = this.ReviewId.Equals(newProperty.ReviewId);


                return (EqualId && EqualName && EqualCost && EqualDescription && EqualReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.PropertyId.GetHashCode();
        }
    }

   
}
