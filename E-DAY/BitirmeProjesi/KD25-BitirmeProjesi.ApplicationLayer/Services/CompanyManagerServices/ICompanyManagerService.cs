using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KD25_BitirmeProjesi.ApplicationLayer.Models.DTOs.AppUser_DTOs;

namespace KD25_BitirmeProjesi.ApplicationLayer.Services.CompanyManagerServices
{
    public interface ICompanyManagerService
    {
        public interface ICompanyManagerService
        {
            // Yöneticinin detaylarını alacak metod
            Task<AppUser_DTO> GetManagerDetailsAsync(int id);

            // Yöneticinin bilgilerini güncelleyecek metod
            Task<bool> UpdateCompanyManagerAsync(AppUserUpdate_DTO updateDTO);
        }
    }
}
