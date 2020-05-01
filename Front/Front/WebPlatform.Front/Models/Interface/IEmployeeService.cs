using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPlatform.Front.Models
{
    public interface IEmployeeService
    {
        public Task<RSV_Global<Employee>> Create(Employee employee);
        public Task<RSV_Global<List<Employee>>> Autocomplete(Employee employee);
        public Task<RSV_Global<Employee>> Update(Employee employee);
        public Task<RSV_Global<Employee>> GetByID(int IDEmployee);
        public Task<RSV_Global<List<Employee>>> GetAll();
    }
}