using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KD25_BitirmeProjesi.ApplicationLayer.Models.DTOs.AppUser_DTOs;
using KD25_BitirmeProjesi.ApplicationLayer.Services.EmailServices;
using KD25_BitirmeProjesi.CoreLayer.Entities;
using KD25_BitirmeProjesi.CoreLayer.Enums;
using KD25_BitirmeProjesi.InfrastructureLayer.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KD25_BitirmeProjesi.ApplicationLayer.Services.CompanyManagerServices
{
    public class CompanyManagerService : ICompanyManagerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AppUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompanyManagerService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Details
        public async Task<AppUser_DTO> GetManagerDetailsAsync(int id)
        {
            // Çalışanı repository'den ID'ye göre al
            var manager = await _userRepository.FindAsync(id);
            if (manager == null)
            {
                return null; // Çalışan bulunamadı
            }

            // Şirket bilgisini almak için OrderFilterMergeAsync'i kullan
            var companyInfo = await _userRepository.FilteredSearchAsync(
                select: e => new
                {
                    CompanyName = e.Company != null ? e.Company.CompanyName : "No Company" // Şirket adı, null ise varsayılan değer
                },
                where: e => e.Id == id, // Çalışan ID'ye göre filtreleniyor
                include: query => query.Include(e => e.Company) // Şirket bilgisini dahil et
            );

            if (companyInfo == null || !companyInfo.Any())
            {
                return null; // Şirket veya durum bilgileri alınamadı
            }

            // DTO'yu oluştur
            var managerDto = _mapper.Map<AppUser_DTO>(manager);

            // Şirket ve durum bilgilerini DTO'ya ekle
            var firstCompany = companyInfo.First();
            managerDto.Company = firstCompany.CompanyName; // Şirket adı

            // Rol bilgilerini al
            var roles = await _userManager.GetRolesAsync(manager);
            managerDto.Role = string.Join(", ", roles); // Birden fazla rol varsa, virgülle birleştir

            return managerDto;


        }
        #endregion

        #region Update
        public async Task<bool> UpdateCompanyManagerAsync(int id, AppUserUpdate_DTO updateManagerDto)
        {
            var manager = await _userRepository.FindAsync(id);
            //employee = _mapper.Map<Employee>(updateEmployeeDto); // 

            if (manager == null || manager.IsActive != true)
            {
                return false; // Çalışan bulunamadı veya pasif
            }

            // Fotoğraf güncellemesi
            if (!string.IsNullOrEmpty(updateManagerDto.Avatar) && manager.Avatar != updateManagerDto.Avatar)
            {
                // Eski fotoğrafı sil (eğer varsa)
                if (!string.IsNullOrEmpty(manager.Avatar))
                {
                    DeletePhotoFromDatabase(manager.Avatar);
                }

                // Yeni fotoğrafı ata
                //employee.Photo = updateEmployeeDto.Photo;
            }

            // DTO'dan diğer verileri mevcut employee nesnesine uygula
            _mapper.Map(updateManagerDto, manager);

            // Çalışanın status'ünü koru
            manager.IsActive = true;

            var updateResult = await _userRepository.UpdateAsync(manager);
            return updateResult;
        }
        private void DeletePhotoFromDatabase(string photoPath)
        {
            // Burada, dosyayı fiziksel olarak veya veri tabanından silebilirsiniz.
            // Örnek bir fiziksel silme işlemi:
            if (File.Exists(photoPath))
            {
                File.Delete(photoPath);
            }
        }

        #endregion

    }
}
