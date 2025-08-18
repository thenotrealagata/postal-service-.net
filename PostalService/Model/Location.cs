using System.ComponentModel.DataAnnotations;

namespace PostalService.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public required string Address { get; set; }

        public required int Capacity { get; set; }

        public required LocationType LocationType { get; init; }
    }
}
