namespace WebPlatform.Front.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;

    public class SubArea
    {
        public int idArea { get; set; }
        public string nameArea { get; set; }
        public int idSubArea { get; set; }
        public string nameSubArea { get; set; }
        public string description { get; set; }
    }

    public class SubAreaService : ISubAreaService
    {
        private readonly Appsettings _appsettings;

        public SubAreaService(Appsettings appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task<RSV_Global<List<Area>>> GetAll()
        {
            var SubAreaRequest = new AreaRequest();
            SubAreaRequest.BaseAddress = _appsettings.APIContextPaht;
            return await SubAreaRequest.GetAllArea();
        }

        public async Task<RSV_Global<List<Area>>> GetByID(int IDArea)
        {
            var SubAreaRequest = new AreaRequest();
            SubAreaRequest.IDArea = IDArea;
            SubAreaRequest.BaseAddress = _appsettings.APIContextPaht;
            return await SubAreaRequest.GetByIDArea();
        }

        public async Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea)
        {
            var SubAreaRequest = new AreaRequest();
            SubAreaRequest.IDArea = IDArea;
            SubAreaRequest.BaseAddress = _appsettings.APIContextPaht;
            return await SubAreaRequest.GetSubArea();
        }
    }

    public class AreaRequest
    {
        public string BaseAddress { get; set; }
        public int IDArea { get; set; }
        private HttpClient client = new HttpClient();

        public async Task<RSV_Global<List<SubArea>>> GetSubArea()
        {
            RSV_Global<List<SubArea>> infoResult = new RSV_Global<List<SubArea>>();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.GetAsync(GetSubAreaByIDAreaRequest());
                }

                if (response.IsSuccessStatusCode)
                {
                    var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    infoResult = JsonConvert.DeserializeObject<RSV_Global<List<SubArea>>>(dataAsString);
                }

                else
                    infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");

            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }


            return infoResult;
        }

        public async Task<RSV_Global<List<Area>>> GetAllArea()
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.GetAsync(GetAllRequest());
                }

                if (response.IsSuccessStatusCode)
                {
                    var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    infoResult = JsonConvert.DeserializeObject<RSV_Global<List<Area>>>(dataAsString);
                }

                else
                    infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");

            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }


            return infoResult;
        }

        public async Task<RSV_Global<List<Area>>> GetByIDArea()
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.GetAsync(GetByIDRequest());
                }

                if (response.IsSuccessStatusCode)
                {
                    var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    infoResult = JsonConvert.DeserializeObject<RSV_Global<List<Area>>>(dataAsString);
                }

                else
                    infoResult.error = new Error(new Exception(), "Se presentó un error al registrar la información");

            }
            catch (Exception ex)
            {
                infoResult.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }


            return infoResult;
        }
        public string GetAllRequest()
        {
            return $"{BaseAddress}Area/GetAll";
        }

        public string GetByIDRequest()
        {
            return $"{BaseAddress}Area/GetByID?IDArea={IDArea.ToString()}";
        }

        public string GetSubAreaByIDAreaRequest()
        {
            return $"{BaseAddress}Area/GetSubAreaByIDarea?IDArea={IDArea.ToString()}";
        }
    }
}