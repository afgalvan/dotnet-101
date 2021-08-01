using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ContosoCraft.Models
{
    [Table("Ratings")]
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double Score { get; set; }

        public override string ToString() =>
            Score.ToString(CultureInfo.InvariantCulture);
    }
}
