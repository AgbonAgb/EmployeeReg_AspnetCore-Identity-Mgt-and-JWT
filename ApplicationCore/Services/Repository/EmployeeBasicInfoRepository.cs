using ApplicationCore.Services.DTOs.Request;
using ApplicationCore.Services.Interface;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Repository
{
    public class EmployeeBasicInfoRepository: IEmployeeBasicInfoRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeBasicInfoRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        public async Task<(string message, bool isSuccessful)> CreateEmpBasicInfo(EmployeeBasicInfoDto empdto)
        {
            bool succ = false;

            var Exist = await _context.EmployeeBasicInfos.Where(x => x.StaffId == empdto.StaffId).FirstOrDefaultAsync();
            var model= _mapper.Map<EmployeeBasicInfo>(empdto);

            if(Exist == null)
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                succ = true;

            }

            if (succ == true)
            {
                return await Task.FromResult(("Employee basic info successfully created", succ));
            }
            else
            {
                return await Task.FromResult(("Employee basic info not created", succ));

            }

        }

        public async Task<(string message, bool isSuccessful)> DelEmpBasicInfoById(int id)
        {
            bool succ = false;

            var Exist = await _context.EmployeeBasicInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
            //var model = _mapper.Map<EmployeeBasicInfo>(emptdto);

            if (Exist != null)
            {
                Exist.IsDeleted = true;

                _context.Update(Exist);//soft delete
                //_context.Remove(Exist);//hard delete
                await _context.SaveChangesAsync();
                succ = true;

            }

            if (succ == true)
            {
                return await Task.FromResult(("Employee deleted successfully", succ));
            }
            else
            {
                return await Task.FromResult(("Employee not deleted", succ));

            }
        }

        public async Task<IEnumerable<EmployeeBasicInfoDto>> GetAllEmpBasicInfo()
        {
            var emp = await _context.EmployeeBasicInfos.Where(x=>x.IsDeleted==false).ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeBasicInfoDto>>(emp);
        }

        public async Task<EmployeeBasicInfoDto> GetEmpBasicInfoById(int id)
        {
            var emp = await _context.EmployeeBasicInfos.Where(x => x.IsDeleted == false && x.Id==id).FirstOrDefaultAsync();
            return _mapper.Map<EmployeeBasicInfoDto>(emp);
        }

        public async Task<(string message, bool isSuccessful)> UpdateEmpBasicInfo(EmployeeBasicInfoDto emptdto)
        {
            bool succ = false;

            var Exist = await _context.EmployeeBasicInfos.Where(x => x.Id == emptdto.Id).FirstOrDefaultAsync();
            var model = _mapper.Map<EmployeeBasicInfo>(emptdto);

            if (Exist != null)
            {
                Exist.StaffId = model.StaffId;
                Exist.FirstName = model.FirstName;
                Exist.LastName = model.LastName;
                Exist.Email = model.Email;
                Exist.Phone = model.Phone;
                Exist.Address = model.Address;

                 _context.Update(Exist);
                await _context.SaveChangesAsync();
                succ = true;

            }

            if (succ == true)
            {
                return await Task.FromResult(("Employee basic info update successfully", succ));
            }
            else
            {
                return await Task.FromResult(("Employee basic info not updated", succ));

            }
        }
    }
}
