using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Account;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class AccountController : AbstractApiAuthController
    {
        private readonly UserManager<ApplicationUser> _userManager;
 
        public AccountController(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/account/sumary
        [HttpGet("summary")]
        public async Task<UserSummaryViewModel> GetSummary()
        {
            var user = await _userManager.GetUserAsync(this.User);
            var isAdmin = this.User.IsInRole("admin");

            var vm = new UserSummaryViewModel
            {
                Email = user.Email,
                IsAdmin = isAdmin,
            };

            return vm;
        }
    }
}