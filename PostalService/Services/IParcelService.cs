using PostalService.Model;

namespace PostalService.Services
{
    public interface IParcelService
    {
        Task<List<Parcel>> GetReceivedParcelsAsync();
        Task<List<Parcel>> GetCreatedParcelsAsync();
        Task<List<Parcel>> GetParcelsAsync();
        Task<Parcel> GetByIdAsync(int id);
        Task<Parcel> GetByAccessCodeAsync(string email, string accessCode);
        Task CreateParcelAsync(Parcel parcel);
        Task<Parcel> ReceiveParcelAsync(int id);
        Task<Parcel> PostParcelAsync(int id);
    }
}
