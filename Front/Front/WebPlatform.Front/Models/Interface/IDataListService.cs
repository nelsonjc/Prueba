using System.Threading.Tasks;

namespace WebPlatform.Front.Models
{
    public interface IDataListService
    {
        Task<DataListResult> GetByType(string nameTypeList);
    }
}