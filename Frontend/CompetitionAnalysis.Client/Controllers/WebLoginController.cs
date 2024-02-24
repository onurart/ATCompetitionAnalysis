using CompetitionAnalysis.Core.Features.AppFeatures.Auth.Commands.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CompetitionAnalysis.Client.Controllers
{
    public class WebLoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WebLoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult SignIn()
        {

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginCommand model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7002/api/Auth/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = await response.Content.ReadFromJsonAsync<TokenRefreshTokenDto>();
                    if (tokenModel != null && tokenModel.Token != null)
                    {
                        var token = new JwtSecurityToken(tokenModel.Token.Token);
                        TempData["EmailOrUserName"] = model.EmailOrUserName;
                        var claims = token.Claims.ToList();
                        claims.Add(new Claim("token", tokenModel.Token.Token));
                        if (tokenModel.Companies != null && tokenModel.Companies.Any())
                        {
                            var companyId = tokenModel.Companies[0].CompanyId; // Assuming the first company's ID is used
                            claims.Add(new Claim("CompanyId", companyId));
                        }
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            IsPersistent = true,
                        };
                        HttpContext.Session.SetString("Token", tokenModel.Token.Token);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps); await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        if (tokenModel.MainRole == "ADMIN")
                        {
                            return RedirectToAction("Index", "Admin/Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                }
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
