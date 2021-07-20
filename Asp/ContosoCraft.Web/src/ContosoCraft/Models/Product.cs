using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCraft.Models
{
    public class Product
    {
        [Required, Key, MaxLength(50)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, MaxLength(60)]
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public Uri ImageUrl { get; set; }

        [Required]
        public Uri Url { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
