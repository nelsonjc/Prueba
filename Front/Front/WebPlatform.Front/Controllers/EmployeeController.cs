using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebPlatform.Front.Models;

namespace WebPlatform.Front.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAppsettingsConfigure _appsettingsConfigure;
        private readonly Appsettings _appsettings;
        private IEmployeeService _employeeService;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _appsettingsConfigure = new AppsettingsConfigure(_configuration);
            _appsettings = _appsettingsConfigure.GetAppsettings();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<RSV_Global<Employee>> Create(Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                _employeeService = new EmployeeService(_appsettings);
                infoResult = await _employeeService.Create(employee);
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        [HttpPost]
        public async Task<RSV_Global<Employee>> Update(Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                _employeeService = new EmployeeService(_appsettings);
                infoResult = await _employeeService.Update(employee);
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        [HttpGet]
        public async Task<RSV_Global<List<Employee>>> Autocomplete(Employee employee)
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();

            try
            {
                _employeeService = new EmployeeService(_appsettings);
                infoResult = await _employeeService.Autocomplete(employee);
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        [HttpGet]
        public async Task<RSV_Global<Employee>> GetByID(int IDEmployee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                _employeeService = new EmployeeService(_appsettings);
                infoResult = await _employeeService.GetByID(IDEmployee);
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        [HttpGet]
        public async Task<RSV_Global<List<Employee>>> GetAll()
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();

            try
            {
                _employeeService = new EmployeeService(_appsettings);
                infoResult = await _employeeService.GetAll();
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }
    }
}