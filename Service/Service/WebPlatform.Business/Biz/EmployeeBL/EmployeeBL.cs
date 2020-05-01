using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WebPlatform.Data;
using WebPlatform.Entities;

namespace WebPlatform.Business
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly AppSettings _appSettings;
        private readonly IEmployeeDAC _employeeDAC;

        public EmployeeBL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _employeeDAC = new EmployeeDAC { ConnectionString = this._appSettings.ConnectionString };
        }

        public async Task<RSV_Global<Employee>> GetByID(int IDEmployee)
        {
            var infoResult = new RSV_Global<Employee>();
            try
            {
                infoResult = await _employeeDAC.GetByID(IDEmployee);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;
        }

        public async Task<RSV_Global<Employee>> Create(Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            try
            {
                EmployeeValidatioResult validation = EmployeeValidator.Validate(employee);

                if (!validation.ISValid)
                {
                    infoResult.Error = validation.Error;
                    return infoResult;
                }

                infoResult = await _employeeDAC.Create(employee);
            }
            catch (SqlException ex)
            {
                infoResult.Error = new Error(ex, SqlMessageErrorGenerator.GetMessageError(ex.Number));
                infoResult.Success = false;
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;
        }

        public async Task<RSV_Global<Employee>> Update(Employee employee)
        {
            EmployeeValidatioResult employeeValidatioResult = null;
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();


            try
            {
                employeeValidatioResult = Validate(employee);
                if (!employeeValidatioResult.ISValid)
                {
                    infoResult.Error = employeeValidatioResult.Error;
                    return infoResult;
                }

                infoResult = await _employeeDAC.Update(employee);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            finally
            {
                employeeValidatioResult = null;
            }

            return infoResult;
        }

        public async Task<RSV_Global<List<Employee>>> Autocomplete(Employee employee)
        {
            var infoResult = new RSV_Global<List<Employee>>();
            try
            {
                if (ValidateAutoComplete(employee).ISValid)
                {
                    infoResult = await _employeeDAC.AutoComplete(SetStringEmpty(employee));
                }
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;
        }

        private EmployeeValidatioResult Validate(Employee employee)
        {
            EmployeeValidatioResult validation = EmployeeValidator.Validate(employee);
            return validation;
        }

        private EmployeeValidatioResult ValidateAutoComplete(Employee employee)
        {
            EmployeeValidatioResult validation = EmployeeValidator.ValidateAutoComplete(employee);
            return validation;
        }

        public async Task<RSV_Global<List<Employee>>> GetAll()
        {
            var infoResult = new RSV_Global<List<Employee>>();
            try
            {
                infoResult = await _employeeDAC.GetAll();
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;
        }

        private Employee SetStringEmpty(Employee employee)
        {
            employee.FullName = string.IsNullOrEmpty(employee.FullName) ? string.Empty : employee.FullName;
            employee.DocumentNumber = string.IsNullOrEmpty(employee.DocumentNumber) ? string.Empty : employee.DocumentNumber;
            return employee;
        }

    }
}
