using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IdentityType()
        {
            return Ok(User.Identity.AuthenticationType);
        }

        public async Task<IActionResult> AddClaims()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                await _userManager.AddClaimsAsync(user
                        , new[] {
                            new Claim("FirstName","Jack" ?? string.Empty),
                            new Claim("LastName","Sparrow" ?? string.Empty),
                            new Claim("NationalCode","555" ?? string.Empty)
                        });
            };

            return Ok("Done");
        }

        public IActionResult Name()
        {
            var userName = User.Identity.Name;
            return Ok(userName);
        }
    }
}