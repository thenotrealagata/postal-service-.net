using PostalService.Model;

namespace PostalService.Services
{
    public interface IParcelService
    {
        Task<List<Parcel>> GetParcelsAsync();
        Task<Parcel> GetByIdAsync(int id);
        Task CreateParcel(Parcel parcel);
    }
}
