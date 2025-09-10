using Microsoft.AspNetCore.Identity;
using PostalService.Model;
using Microsoft.EntityFrameworkCore;
using PostalService.Services;

namespace PostalService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration config)
        {
            // Database
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContext>(options => options
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies()
            );

            // Services
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IParcelService, ParcelService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IUserService, UserService>();

            services.AddIdentity<User, UserRole>(options =>
            {
                // Password settings.
                options.Password.RequiredLength = 6;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
            })
               .AddEntityFrameworkStores<DbContext>()
               .AddDefaultTokenProviders();

            return services;
        }
    }
}
