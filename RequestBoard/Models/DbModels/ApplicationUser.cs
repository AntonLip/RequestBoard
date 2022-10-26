using Microsoft.AspNetCore.Identity;

namespace RequestBoard.Models.DbModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
