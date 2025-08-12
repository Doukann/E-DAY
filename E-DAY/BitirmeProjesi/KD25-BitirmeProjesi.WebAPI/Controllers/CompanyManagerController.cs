using KD25_BitirmeProjesi.ApplicationLayer.Models.DTOs.AppUser_DTOs;
using KD25_BitirmeProjesi.ApplicationLayer.Services.ExpenceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KD25_BitirmeProjesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyManagerController : ControllerBase
    {
        private readonly ICompanyManagerService _companyManagerService;

        public CompanyManagerController(ICompanyManagerService companyManagerService)
        {
            _companyManagerService = companyManagerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin, CompanyManager, Personel")]
        [HttpGet("ListPersonels")]
        public async Task<IActionResult> ListPersonels([FromQuery] int companyId, int takeNumber)
        {
            var result = await _companyManagerService.ListAllPersonels(companyId, takeNumber);
            
            return Ok(result);
        }


















        // 

        // Personel Ekleme (Companyde çalışan)
        // Personelleri Listeleme (Companyde çalışan)
        // Personel Silme


        // izin listele action (company için tüm istekler)
        // izin onay action 

        // harcama listele action (company için tüm istekler)
        // harcama onay action 

        // avans listele action (company için tüm istekler)
        // avans onay action 

        // Bilgilerimi göster action (Yönetici yani AppUserId)
        // Bilgilerimi Düzenle Action

        /*Adımlar:
            İnfrastructure > CompanyManagerRepo.cs
            Application > CompanyManagerServis klasörü > ICompanyManagerService.cs, CompanyManagerService.cs
            
        Yapılacak işlem için adımlar;
        -Gerekiyorsa DTO ekle
        -ICompanyManagerServis metod ismi
        -CompanyManagerServis metod içeriği
        -Gerekiyorsa ICompanyManagerRepo metod ismi
        -Gerekiyorsa CompanyManagerRepo metod içeriği
        -API Controller'da aksiyon yazılacak

         * */


    }
}
