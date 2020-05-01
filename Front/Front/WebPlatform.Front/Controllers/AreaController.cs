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
    public class AreaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAppsettingsConfigure _appsettingsConfigure;
        private readonly Appsettings _appsettings;
        private ISubAreaService _Service;

        public AreaController(IConfiguration configuration)
        {
            _configuration = configuration;
            _appsettingsConfigure = new AppsettingsConfigure(_configuration);
            _appsettings = _appsettingsConfigure.GetAppsettings();
        }

        [HttpGet]
        public async Task<RSV_Global<List<Area>>> GetAll()
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();
            _Service = new SubAreaService(_appsettings);

            try
            {
                infoResult = await _Service.GetAll();
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }


        [HttpGet]
        public async Task<RSV_Global<List<Area>>> GetByID(int IDArea)
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();
            _Service = new SubAreaService(_appsettings);

            try
            {
                infoResult = await _Service.GetByID(IDArea);
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }

        [HttpGet]
        public async Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea)
        {
            RSV_Global<List<SubArea>> infoResult = new RSV_Global<List<SubArea>>();
            _Service = new SubAreaService(_appsettings);

            try
            {
                infoResult = await _Service.GetSubAreaByIDArea(IDArea);
            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResult;
        }
    }
}