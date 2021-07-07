using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoPets.Models
{
    public class Customer
    {
#nullable enable
        public int     Id      { get; set; }
        public string? Address { get; set; }
        public string? Phone   { get; set; }
        public string? Email   { get; set; }
#nullable disable
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
