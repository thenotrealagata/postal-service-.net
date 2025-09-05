using PostalService.Model;

namespace PostalService.DTO
{
    public class LocationResponseDto
    {
        public int Id { get; init; }
        public string Address { get; init; }
        public int Capacity { get; init; }
        public LocationType LocationType {  get; init; }
    }
}
