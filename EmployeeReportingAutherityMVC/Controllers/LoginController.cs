using EmployeeReportingAutherityMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeReportingAutherityMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();
            ViewBag.Msg = "";
        }
        [HttpPost]
        public async Task<IActionResult> Login( LoginEmpModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"]);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Authenticate/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jwtToken = JsonConvert.DeserializeObject<JwtTokenResponse>(responseString);

                // Save token in session
                HttpContext.Session.SetString("JWToken", jwtToken.token);

                // Decode JWT token to extract role
                var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken.token);



                // Try multiple possible claim types
                var roleClaim = token.Claims.FirstOrDefault(c => c.Type == "UserRole")?.Value
                    ?? token.Claims.FirstOrDefault(c => c.Type == "role")?.Value
                    ?? token.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value
                    ?? token.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

                Console.WriteLine($"Extracted Role: '{roleClaim}'");

                // Redirect based on role
                if (!string.IsNullOrEmpty(roleClaim) && roleClaim.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    return RedirectToAction("UserDashboard");
                }
            }
            else
            {
                ViewBag.Msg = "Invalid Login Attempt";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Msg = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationEmpModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"]);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            if (model.UserRole == "Employee")
                response = await client.PostAsync("api/Authenticate/register", content);
            else
                response = await client.PostAsync("api/Authenticate/register-admin", content);

            if (response.IsSuccessStatusCode)
                ViewBag.Msg = "User Registered Successfully";
            else
                ViewBag.Msg = "Invalid Login Attempt";

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login", "Login");
        }
        public class JwtTokenResponse
        {
            public string token { get; set; }
            public DateTime expiration { get; set; }
        }
    }
}
