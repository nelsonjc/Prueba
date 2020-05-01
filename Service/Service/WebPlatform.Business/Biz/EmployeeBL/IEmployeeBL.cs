using System.Collections.Generic;
using System.Threading.Tasks;
using WebPlatform.Entities;

namespace WebPlatform.Business
{
    public interface IEmployeeBL
    {
        Task<RSV_Global<Employee>> GetByID(int IDEmployee);
        Task<RSV_Global<Employee>> Create(Employee employee);
        Task<RSV_Global<Employee>> Update(Employee employee);
        Task<RSV_Global<List<Employee>>> Autocomplete(Employee employee);
        Task<RSV_Global<List<Employee>>> GetAll();

    }
}
