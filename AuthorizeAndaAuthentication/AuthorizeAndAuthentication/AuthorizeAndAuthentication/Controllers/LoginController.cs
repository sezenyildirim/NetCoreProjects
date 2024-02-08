using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthorizeAndAuthentication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
     
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            string[] roles = new string[3];
            roles[0] = "Admin";
            roles[1] = "UI";
            roles[2] = "Analyst";
            var claims = new List<Claim>
            {
              new  Claim(ClaimTypes.Name,"Sezen YILDIRIM"),
              new Claim(ClaimTypes.Role,roles[0]),
              new Claim(ClaimTypes.Role,roles[1]),
              new Claim(ClaimTypes.Role,roles[2]),

            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), authProperties);
            return RedirectToAction("Index","Home");
        }
    }
}
