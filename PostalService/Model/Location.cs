using System.ComponentModel.DataAnnotations;

namespace PostalService.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public LocationType LocationType { get; init; }
    }
}
