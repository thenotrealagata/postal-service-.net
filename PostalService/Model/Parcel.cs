using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostalService.Model
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime ArrivedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFulfilled { get; set; }

        public required ParcelSize Size { get; set; }

        public required string SenderEmail { get; set; }

        public required string ReceiverEmail { get; set; }

        [ForeignKey(nameof(Location))]
        public int StartLocationId { get; set; }
        public virtual Location StartLocation { get; set; } = null!;

        [ForeignKey(nameof(Location))]
        public int EndLocationId { get; set; }
        public virtual Location EndLocation { get; set; } = null!;


        [ForeignKey(nameof(Location))]
        public int CurrentLocationId { get; set; }
        public virtual Location CurrentLocation { get; set; } = null!;
    }
}
