using System.Collections.Generic;
using System.Threading.Tasks;
using WebPlatform.Entities;

namespace WebPlatform.Data
{
    public interface IAreaDAC
    {
        Task<RSV_Global<List<Area>>> Get(int IDArea);

        Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea);
    }
}