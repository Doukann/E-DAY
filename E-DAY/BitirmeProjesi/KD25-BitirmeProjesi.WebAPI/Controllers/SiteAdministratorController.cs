using KD25_BitirmeProjesi.ApplicationLayer.Models.DTOs.AppUser_DTOs;
using KD25_BitirmeProjesi.ApplicationLayer.Services.AppUserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KD25_BitirmeProjesi.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Authorize(Roles = "Personel,Admin,CompanyManager")]
    [Area("SiteAdministrator")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Authorize(Roles = "Personel,Admin,CompanyManager,SiteAdministrator")]

    public class SiteAdministratorController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SiteAdministratorController(IAppUserService appUserService, IHttpContextAccessor httpContextAccessor)
        {
            _appUserService = appUserService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetUserSummary()
        {
            // JWT claimlerinden kullanıcı ID'sini al
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            var userSummary = await _appUserService.GetUserSummaryAsync(userId);
            if (userSummary == null) return NotFound("Kullanıcı bulunamadı.");

            return Ok(userSummary);
        }
    }

}

