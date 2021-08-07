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

        public IList<Rating> Ratings { get; set; }

        public void AddRating(Rating rating) => Ratings.Add(rating);

        public override string ToString() => JsonSerializer.Serialize(this);

        private bool Equals(Product other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }
    }
}
