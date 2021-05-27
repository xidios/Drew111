using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend6.Models
{
    public class OrderExecutor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
        public Guid ExecutorId { get; set; }
        [Required]
        public Executor Executor { get; set; }
    }
}