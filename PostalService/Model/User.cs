using Microsoft.AspNetCore.Identity;

namespace PostalService.Model
{
    public class User : IdentityUser
    {
        public Guid? RefreshToken { get; set; }
    }
}
