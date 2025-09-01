using Microsoft.AspNetCore.Identity;
using PostalService.Model;

namespace PostalService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddUserAsync(User user, string password)
        {
            user.RefreshToken = Guid.NewGuid();

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new InvalidDataException($"User creation failed: {result.Errors.First().Description}");
            }
        }
    }
}
