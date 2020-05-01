namespace WebPlatform.Service.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using WebPlatform.Business;
    using WebPlatform.Entities;

    [Route("[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaBL _subAreaBL;

        public AreaController(IAreaBL subAreaBL)
        {
            _subAreaBL = subAreaBL;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<RSV_Global<List<Area>>>> GetAll()
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();

            try
            {
                infoResult = await _subAreaBL.GetAll();

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<RSV_Global<List<Area>>>> GetByID(int IDArea)
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();

            try
            {
                infoResult = await _subAreaBL.GetByID(IDArea);

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }

        [HttpGet("GetSubAreaByIDArea")]
        public async Task<ActionResult<RSV_Global<List<SubArea>>>> GetSubAreaByIDArea(int IDArea)
        {
            RSV_Global<List<SubArea>> infoResult = new RSV_Global<List<SubArea>>();

            try
            {
                infoResult = await _subAreaBL.GetSubAreaByIDArea(IDArea);

                if (infoResult == null)
                    return BadRequest(new { message = "error" });

                return Ok(infoResult);
            }
            catch (Exception ex)
            {
                infoResult.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResult.Success = false;
            }
            return infoResult;

        }
    }
}