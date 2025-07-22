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
        public int SenderId { get; init; }
        public int ReceiverId { get; init; }
        public Location StartLocation { get; init; }
        public Location EndLocation { get; init; }
        public Location? CurrentLocation { get; init; }
    }
}
