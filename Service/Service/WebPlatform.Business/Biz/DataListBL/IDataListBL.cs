using System.Collections.Generic;
using System.Threading.Tasks;
using WebPlatform.Entities;

namespace WebPlatform.Business
{
    public interface IDataListBL
    {
        Task<RSV_Global<List<DataList>>> GetByType(string NameDateListType);
    }
}