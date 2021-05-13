using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend6.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public String Name { get; set; }
        public String Type { get; set; }
        
    }
}
