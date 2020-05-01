using System.Collections.Generic;
using System.Threading.Tasks;
using WebPlatform.Entities;

namespace WebPlatform.Data
{
    public interface IDataListDAC
    {
        Task<RSV_Global<List<DataList>>> GetByType(string NameDateListType);
    }
}
