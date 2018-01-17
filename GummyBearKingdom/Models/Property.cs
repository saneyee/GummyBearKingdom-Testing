using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummyBearKingdom.Models
{
    [Table("Properties")]
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Property()
        {
            this.Reviews = new HashSet<Review>();
        }
		

		public double AverageRating()
		{
			if (Reviews.Count > 0)
			{
                return (Reviews.Sum(review => review.Rating) /(double)Reviews.Count());

			}
			else
			{
				return 0;
			}
		}

		      //public double AverageRating()
		      //{
		      //    double rating = 0;
		      //    double totRating = 0;

		      //    if (Reviews != null)
		      //    {
		      //        int totReview = Reviews.Count;

		      //        foreach (var review in Reviews)
		      //        {
        //            totRating = totRating + review.Rating;
		      //        }
		      //        rating = totRating / totReview;
		      //    }

		      //    return rating;

		      //}
		


		

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


                return (EqualId && EqualName && EqualCost && EqualDescription);
            }
        }

        public override int GetHashCode()
        {
            return this.PropertyId.GetHashCode();
        }
    }

   
}
