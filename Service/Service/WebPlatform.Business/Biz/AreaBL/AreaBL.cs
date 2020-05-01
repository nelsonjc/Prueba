namespace WebPlatform.Business
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using WebPlatform.Data;
    using WebPlatform.Entities;

    public class AreaBL : IAreaBL
    {
        private readonly IAreaDAC _areaDAC;
        public AreaBL(IOptions<AppSettings> appSettings)
        {
            _areaDAC = new AreaDAC { ConnectionString = appSettings.Value.ConnectionString };
        }
        public async Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea)
        {
            var infoResult = new RSV_Global<List<SubArea>>();
            try
            {
                infoResult = await _areaDAC.GetSubAreaByIDArea(IDArea);

            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;

        }

        public async Task<RSV_Global<List<Area>>> GetAll()
        {
            var infoResult = new RSV_Global<List<Area>>();
            try
            {
                infoResult = await _areaDAC.Get(-1);

            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presentó un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.ToString()}");
                infoResult.Success = false;
            }

            return infoResult;
        }

        public async Task<RSV_Global<List<Area>>> GetByID(int IDArea)
        {
            var infoResult = new RSV_Global<List<Area>>();
            try
            {
                infoResult = await _areaDAC.Get(IDArea);

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
