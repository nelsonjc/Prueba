using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WebPlatform.Business;
using WebPlatform.Entities;

namespace WebPlatform.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL _employeeBL;

        public EmployeeController(IEmployeeBL employee)
        {
            _employeeBL = employee;
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<RSV_Global<Employee>>> GetByID(int IDEmployee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                infoResult = await _employeeBL.GetByID(IDEmployee);

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }

        [HttpPost("Create")]
        public async Task<ActionResult<RSV_Global<Employee>>> Create([FromBody]Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                infoResult = await _employeeBL.Create(employee);

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }


        [HttpPost("Update")]
        public async Task<ActionResult<RSV_Global<Employee>>> Update([FromBody]Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                infoResult = await _employeeBL.Update(employee);

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;
        }

        [HttpGet("Autocomplete")]
        public async Task<ActionResult<RSV_Global<List<Employee>>>> Autocomplete(Employee employee)
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();

            try
            {
                infoResult = await _employeeBL.Autocomplete(employee);

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<RSV_Global<List<Employee>>>> GetAll()
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();

            try
            {
                infoResult = await _employeeBL.GetAll();

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }

    }
}