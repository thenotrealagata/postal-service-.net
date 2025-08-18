
using Microsoft.EntityFrameworkCore;
using PostalService.Exceptions;
using PostalService.Model;

namespace PostalService.Services
{
    public class LocationService : ILocationService
    {
        private DbContext _dbContext;
        private IParcelService _parcelService;

        public LocationService (DbContext dbContext, IParcelService parcelService)
        {
            _dbContext = dbContext;
            _parcelService = parcelService;
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if (location is null)
            {
                throw new ResourceNotFoundException(nameof(Location));
            }

            return location;
        }

        public async Task PostParcelAsync(int locationId, int parcelId)
        {
            // Post parcel at any given location that has free capacity
            var parcel = await _parcelService.GetByIdAsync(parcelId);
            var location = await GetLocationByIdAsync(locationId);

            // Check if location still has capacity
            var remainingCapacity = _dbContext.Parcels.Count<Parcel>(p => p.CurrentLocationId == locationId);
            if (remainingCapacity == 0)
            {
                throw new InvalidDataException("Location doesn't have any free capacity!");
            }

            parcel.CurrentLocationId = location.Id;
            parcel.StartLocationId = location.Id;
            parcel.PlacedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ReceiveParcelAsync(int parcelId)
        {
            // Receive parcel if it has reached its end location
            var parcel = await _parcelService.GetByIdAsync(parcelId);

            if (parcel.CurrentLocationId == parcel.EndLocationId)
            {
                parcel.IsFulfilled = true;
                await _dbContext.SaveChangesAsync();
            } else
            {
                throw new InvalidDataException("Parcel hasn't arrived to end location yet!");
            }
        }

        public Task MoveParcel(int parcelId, int toLocationId)
        {
            throw new NotImplementedException();
        }
    }
}
