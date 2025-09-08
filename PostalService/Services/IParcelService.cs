using PostalService.Model;

namespace PostalService.Services
{
    public interface IParcelService
    {
        Task<List<Parcel>> GetReceivedParcelsAsync();
        Task<List<Parcel>> GetCreatedParcelsAsync();
        Task<List<Parcel>> GetParcelsAsync();
        Task<Parcel> GetByIdAsync(int id);
        Task CreateParcel(Parcel parcel);
    }
}
