using System.Collections.Generic;
using System.Threading.Tasks;
using WebPlatform.Entities;

namespace WebPlatform.Business
{
    public interface IAreaBL
    {
        Task<RSV_Global<List<Area>>> GetByID(int IDArea);
        Task<RSV_Global<List<Area>>> GetAll();
        Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea);

    }
}