using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WebPlatform.Data;
using WebPlatform.Entities;

namespace WebPlatform.Business
{
    public class DataListBL : IDataListBL
    {
        private readonly IDataListDAC _dataListDAC;
        public DataListBL(IOptions<AppSettings> appSettings)
        {
            _dataListDAC = new DataListDAC { ConnectionString = appSettings.Value.ConnectionString };
        }
        public async Task<RSV_Global<List<DataList>>> GetByType(string NameDateListType)
        {
            var infoResult = new RSV_Global<List<DataList>>();
            try
            {
                infoResult = await _dataListDAC.GetByType(NameDateListType);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;

        }
    }
}
