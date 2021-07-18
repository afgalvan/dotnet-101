using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCraft.Web.Models
{
    public class Product
    {
        [Key, MaxLength(20)]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Required, MaxLength(50)]
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public Uri ImageUrl { get; set; }

        [Required]
        public Uri Url { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
