using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCExampleProject.Areas.Identity.Data
{
    public class AppClaimsFactory : UserClaimsPrincipalFactory<AppUser>
    {
        public AppClaimsFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("FavColor", user.FavColor));
            identity.AddClaim(new Claim("ForFun", "MVC Rocks"));
            identity.AddClaim(new Claim("Hometown", user.HomeTown));
            identity.AddClaim(new Claim("MothersMaiden", user.MothersMaiden));
            identity.AddClaim(new Claim("Birthday", user.Birthday.ToString()));

            if (user.IsAdmin)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
            }

            return identity;
        }
    }
}
