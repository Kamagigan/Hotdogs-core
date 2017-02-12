using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HotDogsWeb.Models
{
    public class HotDogUser : IdentityUser
    {
        public HotDogUser() : base()
        {

        }

        public HotDogUser(string userName) : base(userName)
        {
        }

        public int favoriteStore { get; set; }
    }
}
