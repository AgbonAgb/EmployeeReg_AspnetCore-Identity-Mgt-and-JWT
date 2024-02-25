using ApplicationCore.Services.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Interface
{
    public interface IEmployeeBasicInfoRepository
    {
        Task<(string message, bool isSuccessful)> CreateEmpBasicInfo(EmployeeBasicInfoDto empdto);
        Task<(string message, bool isSuccessful)> UpdateEmpBasicInfo(EmployeeBasicInfoDto emptdto);
        Task<IEnumerable<EmployeeBasicInfoDto>> GetAllEmpBasicInfo();
        Task<EmployeeBasicInfoDto> GetEmpBasicInfoById(int id);
        Task<(string message, bool isSuccessful)> DelEmpBasicInfoById(int id);

    }
}
