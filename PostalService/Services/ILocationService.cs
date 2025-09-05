using PostalService.Model;

namespace PostalService.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations(LocationType locationType);
        Task<Location> GetLocationByIdAsync(int id);
        Task PostParcelAsync(int locationId, int parcelId);
        Task ReceiveParcelAsync(int parcelId);
        Task MoveParcel(int parcelId, int toLocationId);
    }
}
