using ApplicationCore.Services.DTOs.Request;
using ApplicationCore.Services.DTOs.Response;
using ApplicationCore.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpBasicController : ControllerBase
    {
        private readonly IEmployeeBasicInfoRepository _employeeBasicInfoRepository;
        public EmpBasicController(IEmployeeBasicInfoRepository employeeBasicInfoRepository)
        {
            _employeeBasicInfoRepository = employeeBasicInfoRepository;
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmp(EmployeeBasicInfoDto empinf)
        {
            if(ModelState.IsValid)
            {
                var crt = await _employeeBasicInfoRepository.CreateEmpBasicInfo(empinf);
                if(crt.isSuccessful)
                {
                    return Ok(new ApiResponse()
                    {
                        Data = null,
                        Message = crt.message,
                        StatusCode=200

                    }) ;
                }
                else
                {
                    return BadRequest(new ApiResponse()
                    {
                        Data = null,
                        Message = crt.message,
                        StatusCode = 404

                    });
                }

            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpGet("getEmployees")]
        public async Task<IActionResult> getEmps()
        {
            var emps = await _employeeBasicInfoRepository.GetAllEmpBasicInfo();
            return Ok(emps);
        }
        [HttpGet("getEmployeesbyid")]
        public async Task<IActionResult> getEmpbyId(int id)
        {
            var emps = await _employeeBasicInfoRepository.GetEmpBasicInfoById(id);
            return Ok(emps);
        }


        //update

        [HttpPatch("updateemp")]
        public async Task<IActionResult> updateempbyid(EmployeeBasicInfoDto empinf)
        {
            if (ModelState.IsValid)
            {
                var crt = await _employeeBasicInfoRepository.UpdateEmpBasicInfo(empinf);
                if (crt.isSuccessful)
                {
                    return Ok(new ApiResponse()
                    {
                        Data = null,
                        Message = crt.message,
                        StatusCode = 200

                    });
                }
                else
                {
                    return BadRequest(new ApiResponse()
                    {
                        Data = null,
                        Message = crt.message,
                        StatusCode = 404

                    });
                }

            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        //Delete

        [HttpDelete("DelEmp")]
        public async Task<IActionResult> DelEmpbyid(int id)
        {
            var crt = await _employeeBasicInfoRepository.DelEmpBasicInfoById(id);
            if (crt.isSuccessful)
            {
                return Ok(new ApiResponse()
                {
                    Data = null,
                    Message = crt.message,
                    StatusCode = 200

                });
            }
            else
            {
                return BadRequest(new ApiResponse()
                {
                    Data = null,
                    Message = crt.message,
                    StatusCode = 404

                });
            }
        }
    }
}
