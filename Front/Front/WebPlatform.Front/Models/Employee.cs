namespace WebPlatform.Front.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    
    public class Employee
    {
        public int idEmployee { get; set; }
        public int idDocumentType { get; set; }
        public string nameDocumentType { get; set; }
        public string codeDocumentType { get; set; }
        public string documentNumber { get; set; }
        public string fullName { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string surname { get; set; }
        public string secondSurname { get; set; }
        public int idSubArea { get; set; }
        public string nameSubArea { get; set; }
        public int idArea { get; set; }
        public string nameArea { get; set; }
        public bool active { get; set; }
        public string urlImage { get; set; }
        public int idUserCreation { get; set; }
        public DateTime dateCreation { get; set; }
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly Appsettings _appsettings;

        public EmployeeService(Appsettings appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task<RSV_Global<Employee>> Create(Employee employee)
        {
            var employeeRequest = new EmployeeRequest
            {
                Employee = employee,
                BaseAddress = _appsettings.APIContextPaht
            };
            return await employeeRequest.Create();
        }

        public async Task<RSV_Global<List<Employee>>> Autocomplete(Employee employee)
        {
            var employeeRequest = new EmployeeRequest
            {
                Employee = employee,
                BaseAddress = _appsettings.APIContextPaht
            };
            return await employeeRequest.Autocomplete();
        }

        public async Task<RSV_Global<Employee>> Update(Employee employee)
        {
            var employeeRequest = new EmployeeRequest
            {
                Employee = employee,
                BaseAddress = _appsettings.APIContextPaht
            };
            return await employeeRequest.Update();
        }

        public async Task<RSV_Global<Employee>> GetByID(int IDEmployee)
        {
            var employeeRequest = new EmployeeRequest
            {
                Employee = new Employee() { idEmployee = IDEmployee },
                BaseAddress = _appsettings.APIContextPaht
            };
            return await employeeRequest.GetByID();
        }

        public async Task<RSV_Global<List<Employee>>> GetAll()
        {
            var employeeRequest = new EmployeeRequest
            {
                BaseAddress = _appsettings.APIContextPaht
            };
            return await employeeRequest.GetAll();
        }
    }

    public class EmployeeRequest
    {
        public Employee Employee { get; set; }
        public string BaseAddress { get; set; }

        public async Task<RSV_Global<Employee>> Create()
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            HttpResponseMessage response;
            HttpRequestMessage request;

            try
            {
                var employeeResult = EmployeeValidator.ValidationSimple(this.Employee);
                if (employeeResult.IsValid)
                {
                    request = new HttpRequestMessage(HttpMethod.Post, $"{this.BaseAddress}Employee/Create");
                    string jsonEmployee = JsonConvert.SerializeObject(this.Employee);
                    request.Content = new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json");

                    using (var http = new HttpClient())
                    {
                        response = await http.SendAsync(request);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        infoResult.data = new Employee();
                        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        infoResult = JsonConvert.DeserializeObject<RSV_Global<Employee>>(dataAsString);
                    }

                    else
                        infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");
                }
                else
                    infoResult.error = new Error(new Exception(), string.Join(Environment.NewLine, employeeResult.ErrorMessage));
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }


            return infoResult;
        }

        public async Task<RSV_Global<Employee>> Update()
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();

            HttpResponseMessage response;
            HttpRequestMessage request;

            try
            {
                var employeeResult = EmployeeValidator.ValidationSimple(this.Employee);
                if (employeeResult.IsValid)
                {
                    request = new HttpRequestMessage(HttpMethod.Post, $"{this.BaseAddress}Employee/Update");
                    string jsonEmployee = JsonConvert.SerializeObject(this.Employee);
                    request.Content = new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json");

                    using (var http = new HttpClient())
                    {
                        response = await http.SendAsync(request);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        infoResult.data = new Employee();
                        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        infoResult = JsonConvert.DeserializeObject<RSV_Global<Employee>>(dataAsString);
                    }

                    else
                        infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");
                }
                else
                    infoResult.error = new Error(new Exception(), string.Join(Environment.NewLine, employeeResult.ErrorMessage));
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }


            return infoResult;
        }

        public async Task<RSV_Global<List<Employee>>> Autocomplete()
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();
            HttpResponseMessage response = new HttpResponseMessage();
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                var employeeResult = EmployeeValidator.ValidationAutoComplete(this.Employee);

                if (employeeResult.IsValid)
                {
                    request = new HttpRequestMessage(HttpMethod.Get, $"{this.BaseAddress}Employee/Autocomplete");
                    string jsonEmployee = JsonConvert.SerializeObject(this.Employee);
                    request.Content = new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json");

                    using (var http = new HttpClient())
                    {
                        response = await http.SendAsync(request);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        infoResult.data = new List<Employee>();
                        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        infoResult = JsonConvert.DeserializeObject<RSV_Global<List<Employee>>>(dataAsString);
                    }

                    else
                        infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");
                }
                else
                {
                    infoResult.error = new Error(new Exception(), string.Join(Environment.NewLine, employeeResult.ErrorMessage));
                }
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        public async Task<RSV_Global<Employee>> GetByID()
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();
            HttpResponseMessage response = new HttpResponseMessage();
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                if (Employee.idEmployee > 0)
                {
                    using (var httpClient = new HttpClient())
                    {
                        response = await httpClient.GetAsync(RequestByID());
                    }


                    if (response.IsSuccessStatusCode)
                    {
                        infoResult.data = new Employee();
                        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        infoResult = JsonConvert.DeserializeObject<RSV_Global<Employee>>(dataAsString);
                    }

                    else
                        infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");
                }
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        public async Task<RSV_Global<List<Employee>>> GetAll()
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();
            HttpResponseMessage response = new HttpResponseMessage();
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.GetAsync(RequestGetAll());
                }


                if (response.IsSuccessStatusCode)
                {
                    infoResult.data = new List<Employee>();
                    var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    infoResult = JsonConvert.DeserializeObject<RSV_Global<List<Employee>>>(dataAsString);
                }

                else
                    infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        public string RequestByID() => $"{this.BaseAddress}Employee/GetByID?IDEmployee={Employee.idEmployee}";

        public string RequestGetAll() => $"{this.BaseAddress}Employee/GetAll";

    }

    public class EmployeeValidateResult
    {
        public List<string> ErrorMessage { get; set; } = new List<string>();
        public bool IsValid { get { return !ErrorMessage.Any(); } }
    }

    public static class EmployeeValidator
    {
        public static EmployeeValidateResult ValidationSimple(Employee employee)
        {
            EmployeeValidateResult employeeResult = new EmployeeValidateResult();

            if (employee == default(Employee))
            {
                employeeResult.ErrorMessage.Add($"El Empleado no es valido");
                return employeeResult;
            }

            if (employee.idDocumentType == 0)
                employeeResult.ErrorMessage.Add($"El tipo documento es requerido");

            if (string.IsNullOrEmpty(employee.documentNumber))
                employeeResult.ErrorMessage.Add($"El número de documento es requerido");

            if (string.IsNullOrEmpty(employee.name))
                employeeResult.ErrorMessage.Add($"El nombre es requerido");


            if (string.IsNullOrEmpty(employee.surname))
                employeeResult.ErrorMessage.Add($"El apellido es requerido");


            if (employee.idArea == 0)
                employeeResult.ErrorMessage.Add($"El Área es requerido");

            if (employee.idSubArea == 0)
                employeeResult.ErrorMessage.Add($"El SubÁrea es requerido");

            return employeeResult;
        }

        public static EmployeeValidateResult ValidationAutoComplete(Employee employee)
        {
            EmployeeValidateResult employeeResult = new EmployeeValidateResult();

            if (employee == default(Employee))
                employeeResult.ErrorMessage.Add($"El Empleado no es valido");

            if (employee != null &&
                (string.IsNullOrEmpty(employee.fullName) && string.IsNullOrEmpty(employee.documentNumber)))
                employeeResult.ErrorMessage.Add($"para realizar la búsqueda por Autocomplete se requiere Nombre y/o Número de documento");

            return employeeResult;
        }
    }
}