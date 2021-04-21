using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCExampleProject.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public string FavColor { get; set; }
        [PersonalData]
        public string HomeTown { get; set; }
        [PersonalData]
        public string MothersMaiden { get; set; }
        [PersonalData]
        public DateTime Birthday { get; set; }
    }
}
