using PostalService.Model;

namespace PostalService.Services
{
    public interface IParcelService
    {
        Task<Parcel> GetByIdAsync(int id);
        Task CreateParcel(Parcel parcel);
    }
}
