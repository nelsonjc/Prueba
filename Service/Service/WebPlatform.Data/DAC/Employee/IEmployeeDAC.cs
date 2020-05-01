namespace WebPlatform.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebPlatform.Entities;

    public interface IEmployeeDAC
    {
        Task<RSV_Global<Employee>> GetByID(int IDEmployee);
        Task<RSV_Global<Employee>> Create(Employee employee);
        Task<RSV_Global<Employee>> Update(Employee employee);
        Task<RSV_Global<List<Employee>>> AutoComplete(Employee employee);
        Task<RSV_Global<List<Employee>>> GetAll();
    }
}
