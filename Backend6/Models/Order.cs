using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend6.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public String Name { get; set; }
        public ApplicationUser Creator { get; set; }
        public Guid ExecutorId { get; set; }
        public Executor Executor { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
