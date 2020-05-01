using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPlatform.Front.Models
{
    public interface ISubAreaService
    {
        Task<RSV_Global<List<Area>>> GetAll();
        Task<RSV_Global<List<Area>>> GetByID(int IDArea);
        Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea);
    }
}