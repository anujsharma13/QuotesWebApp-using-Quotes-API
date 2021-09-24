using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private object lines;

        public async Task<IActionResult> Index()
        {
            // If the user is authenticated, then this is how you can get the access_token and id_token
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");

                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind);

                string idToken = await HttpContext.GetTokenAsync("id_token");
                using StreamWriter file = new("JWTTokenGenerated.txt");
                await file.WriteLineAsync(idToken);
                // Now you can use them. For more info on when and how to use the
                // access_token and id_token, see https://auth0.com/docs/tokens
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
