namespace WebPlatform.Front.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;

    public class DataList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int idDataListType { get; set; }
        public string nameDataListType { get; set; }
        public bool active { get; set; }
    }

    public class DataListService : IDataListService
    {
        private readonly Appsettings _appsettings;

        public DataListService(Appsettings appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task<DataListResult> GetByType(string nameTypeList)
        {
            var DataListRequest = new DataListRequest();
            DataListRequest.NameDateListType = nameTypeList;
            DataListRequest.BaseAddress = _appsettings.APIContextPaht;
            return await DataListRequest.GetByType();
        }
    }

    public class DataListRequest
    {
        public string BaseAddress { get; set; }
        public string NameDateListType { get; set; }
        private HttpClient client = new HttpClient();

        public async Task<DataListResult> GetByType()
        {
            DataListResult DataListResponse = new DataListResult();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                DataListResponse = DataListValidator.Validation(NameDateListType);
                if (DataListResponse.IsValid)
                {
                    using (var httpClient = new HttpClient())
                    {
                        response = await httpClient.GetAsync(BuildRequest());
                    }

                    DataListResponse.Response = new RSV_Global<List<DataList>>();


                    if (response.IsSuccessStatusCode)
                    {
                        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        DataListResponse.Response = JsonConvert.DeserializeObject<RSV_Global<List<DataList>>>(dataAsString);
                    }

                    else
                        DataListResponse.Response.error = new Error(new Exception(), "Se presentó un error al registrar la información");
                }
            }
            catch (Exception ex)
            {
                DataListResponse.Response.error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }


            return DataListResponse;
        }

        public string BuildRequest() => $"{BaseAddress}DataList/GetByType?NameDateListType={NameDateListType}";
    }

    public class DataListResult
    {
        public RSV_Global<List<DataList>> Response { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsValid { get { return string.IsNullOrWhiteSpace(ErrorMessage); } }
    }

    public static class DataListValidator
    {
        public static DataListResult Validation(string NameDateListType)
        {
            DataListResult DataListResult = new DataListResult();

            if (string.IsNullOrEmpty(NameDateListType))
                DataListResult.ErrorMessage = $"No se envío el nombre de tipo de Lista para la búsqueda.";



            if (!string.IsNullOrEmpty(DataListResult.ErrorMessage))
            {
                DataListResult.Response = new RSV_Global<List<DataList>>();
                DataListResult.Response.error = new Error(new Exception(), DataListResult.ErrorMessage);
            }

            return DataListResult;
        }
    }
}
