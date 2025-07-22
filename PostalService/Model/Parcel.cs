using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostalService.Model
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime PlacedAt { get; set; }

        public DateTime ArrivedAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsFulfilled { get; set; }

        [Required]
        public ParcelSize Size { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string SenderId { get; set; }
        public virtual User Sender { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string ReceiverId  { get; set; }

        public virtual User Receiver { get; set; } = null!;

        [ForeignKey(nameof(Location))]
        public int StartLocationid { get; set; }
        public virtual Location StartLocation { get; set; }

        [ForeignKey(nameof(Location))]
        public int EndLocationid { get; set; }
        public virtual Location EndLocation { get; set; }


        [ForeignKey(nameof(Location))]
        public int CurrentLocationId { get; set; }

        public virtual Location CurrentLocation { get; set; }
    }
}
