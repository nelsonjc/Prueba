using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebPlatform.Front.Models;

namespace WebPlatform.Front.Controllers
{
    public class DataListController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAppsettingsConfigure _appsettingsConfigure;
        private readonly Appsettings _appsettings;
        private IDataListService _Service;
        public DataListController(IConfiguration configuration)
        {
            _configuration = configuration;
            _appsettingsConfigure = new AppsettingsConfigure(_configuration);
            _appsettings = _appsettingsConfigure.GetAppsettings();
        }

        [HttpGet]
        public async Task<RSV_Global<List<DataList>>> GetByType(string nameTypeList)
        {
            RSV_Global<List<DataList>> infoResult = new RSV_Global<List<DataList>>();
            _Service = new DataListService(_appsettings);

            try
            {
                var infoResulAPI = await _Service.GetByType(nameTypeList);
                infoResult = infoResulAPI.Response;
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }
    }
}