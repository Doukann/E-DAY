using KD25_BitirmeProjesi.UI.MVC_Core.Areas.Personel.Models.ViewModels.Expence_VMs;
using KD25_BitirmeProjesi.UI.MVC_Core.Areas.SiteAdministrator.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KD25_BitirmeProjesi.UI.MVC_Core.Areas.SiteAdministrator.Controllers
{
    [Area("SiteAdministrator")]
    //[Authorize(Roles = "Personel,Admin,CompanyManager,SiteAdministrator")]

    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public HomeController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _baseUrl = _configuration["ApiSettings:BaseUrl"]; // API Base URL
        }

        public async Task<IActionResult> Index()
        {
            // Session'dan token'ı al
            var token = HttpContext.Session.GetString("Token");

            // Token yoksa kullanıcıyı Login sayfasına yönlendir
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }

            // Kullanıcı bilgilerini almak için HTTP istemcisini oluştur
            var client = _httpClientFactory.CreateClient();
            var userId = HttpContext.Session.GetInt32("UserId"); // Aktif kullanıcının ID'si

            if (!userId.HasValue)
            {
                ViewBag.Error = "Kullanıcı bilgisi alınamadı.";
                return View("Error");
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/api/SiteAdministrator/summary/{userId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // API'ye istek gönder
            var response = await client.SendAsync(request);

            // API çağrısı başarısızsa hata mesajı göster
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Veriler alınırken bir hata oluştu.";
                return View(new UserSummary_VM()); // Boş kullanıcı nesnesi dön
            }

            // API'den gelen veriyi JSON olarak oku
            var json = await response.Content.ReadAsStringAsync();

            // JSON verisini UserSummary_VM nesnesine dönüştür
            var user = JsonConvert.DeserializeObject<UserSummary_VM>(json);

            // Kullanıcıyı View'da göster
            return View(user);
        }
    }






}
