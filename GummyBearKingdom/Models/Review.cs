using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummyBearKingdom.Models
{
    [Table("Reviews")]
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
       



        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                bool EqualId = this.ReviewId.Equals(newReview.ReviewId);
                bool EqualAuthor = this.Author.Equals(newReview.Author);
                bool EqualContent = this.Content.Equals(newReview.Content);
                bool EqualRating = this.Rating.Equals(newReview.Rating);

                return (EqualId && EqualAuthor && EqualContent && EqualRating);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }
    }

}
