using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using PostalService.Exceptions;
using PostalService.Model;

namespace PostalService.Services
{
    public class ParcelService : IParcelService
    {
        private readonly DbContext _context;

        public ParcelService(DbContext context)
        {
            _context = context;
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

            // TODO check if receiver location & end location exists

            // TODO connect to ReceiverId if receiver user exists in the system
            var email = parcel.ReceiverEmail;

            await _context.Parcels.AddAsync(parcel);
        }
    }
}
