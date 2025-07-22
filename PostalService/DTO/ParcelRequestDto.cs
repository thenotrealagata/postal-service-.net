using PostalService.Model;

namespace PostalService.DTO
{
    public class ParcelRequestDto
    {
        public ParcelSize ParcelSize { get; init; }
        public string ReceiverEmail { get; init; }
        public int StartLocationId { get; init; }
        public int EndLocationId { get; init; }
    }
}
