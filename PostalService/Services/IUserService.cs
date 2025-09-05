﻿using PostalService.Model;
using System.Data;

namespace PostalService.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user, string password);
        Task<(string authToken, string refreshToken, string userId)> LoginAsync(string email, string password);
        Task<(string authToken, string refreshToken, string userId)> RedeemRefreshTokenAsync(string refreshToken);
        Task LogoutAsync();
        Task<User?> GetCurrentUserAsync();
        string? GetCurrentUserId();
        Task<User> GetUserByIdAsync(string id);
        List<Role> GetCurrentUserRoles();
        bool IsCurrentUserAdmin();
    }
}
