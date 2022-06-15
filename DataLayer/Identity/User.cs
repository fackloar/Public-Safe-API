using Microsoft.AspNetCore.Identity;

namespace Safe_Development.DataLayer.Identity
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }

    }
}
