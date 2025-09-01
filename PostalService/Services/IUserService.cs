using PostalService.Model;

namespace PostalService.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user, string password);
    }
}
