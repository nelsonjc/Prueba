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
    public class DataListController : ControllerBase
    {
        private readonly IDataListBL _dataListBL;

        public DataListController(IDataListBL dataList)
        {
            _dataListBL = dataList;
        }

        [HttpGet("GetByType")]
        public async Task<ActionResult<RSV_Global<List<DataList>>>> GetByType(string NameDateListType)
        {
            RSV_Global<List<DataList>> infoResult = new RSV_Global<List<DataList>>();

            try
            {
                infoResult = await _dataListBL.GetByType(NameDateListType);

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