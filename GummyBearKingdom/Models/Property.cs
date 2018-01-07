using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummyBearKingdom.Models
{
    
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }

    }

   
}
