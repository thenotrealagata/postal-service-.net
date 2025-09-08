using Microsoft.EntityFrameworkCore;
using PostalService.Exceptions;
using PostalService.Model;

namespace PostalService.Services
{
    public class ParcelService : IParcelService
    {
        private readonly DbContext _context;
        private readonly IUserService _userService;
        private readonly ILocationService _locationService;

        public ParcelService(DbContext context, IUserService userService, ILocationService locationService)
        {
            _context = context;
            _userService = userService;
            _locationService = locationService;
        }

        public async Task<List<Parcel>> GetReceivedParcelsAsync()
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            if (currentUser is null)
            {
                throw new AccessViolationException("User must be logged in to receive list of received parcels!");
            }

            var parcels = await _context.Parcels.Where(p => p.ReceiverEmail.Equals(currentUser.Email)).ToListAsync();
            return parcels;
        }

        public async Task<List<Parcel>> GetCreatedParcelsAsync()
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            if (currentUser is null)
            {
                throw new AccessViolationException("User must be logged in to receive list of created parcels!");
            }

            var parcels = await _context.Parcels.Where(p => p.SenderEmail.Equals(currentUser.Email)).ToListAsync();
            return parcels;
        }

        public async Task<List<Parcel>> GetParcelsAsync()
        {
            var parcels = await _context.Parcels.ToListAsync();

            if (parcels is null)
            {
                throw new ResourceNotFoundException(nameof(Parcel));
            }

            return parcels;
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            var parcel = await _context.Parcels.FirstOrDefaultAsync(parcel => parcel.Id == id && !parcel.IsDeleted);

            if (parcel is null)
            {
                throw new ResourceNotFoundException(nameof(Parcel));
            }

            return parcel;
        }

        public async Task CreateParcel(Parcel parcel)
        {
            parcel.CreatedAt = DateTime.Now;
            parcel.IsDeleted = false;
            parcel.IsFulfilled = false;

            // Check that end and start locations are valid
            if (parcel.StartLocationId is null || parcel.EndLocationId is null)
            {
                throw new InvalidDataException("Both start and end locations need to be provided!");
            }
            await _locationService.GetLocationByIdAsync(parcel.StartLocationId.Value);
            await _locationService.GetLocationByIdAsync(parcel.EndLocationId.Value);


            // Validate sender e-mail address
            // TODO validate that both sender & receiver addresses are valid e-mail addresses
            var user = await _userService.GetCurrentUserAsync();
            if (user != null && user.Email != null)
            {
                parcel.SenderEmail = user.Email;
            } else if (parcel.SenderEmail == null)
            {
                // Throw exception: if user is not logged in, a sender e-mail needs to be provided
                throw new InvalidDataException($"If the user is not logged in, a sender e-mail address needs to be provided! {parcel.SenderEmail}");
            }

            await _context.Parcels.AddAsync(parcel);
            try
            {
                await _context.SaveChangesAsync();
                // TODO send e-mail about parcel creation
            }
            catch (DbUpdateException ex)
            {
                throw new SaveFailedException("Failed to create reservation", ex);
            }
        }
    }
}
