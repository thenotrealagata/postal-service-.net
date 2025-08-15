using System.ComponentModel.DataAnnotations;
using PostalService.Model;

namespace PostalService.DTO
{
    public class ParcelResponseDto
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? PlacedAt { get; init; }
        public DateTime? ArrivedAt { get; init; }
        public bool IsFulfilled { get; init; }
        public ParcelSize ParcelSize { get; init; }
        public string SenderEmail { get; init; }
        public string ReceiverEmail { get; init; }
        public Location StartLocation { get; init; }
        public Location EndLocation { get; init; }
        public Location? CurrentLocation { get; init; }
    }
}
