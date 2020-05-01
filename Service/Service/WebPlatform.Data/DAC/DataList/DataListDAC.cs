namespace WebPlatform.Data
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using WebPlatform.Data.Helper;
    using WebPlatform.Entities;

    public class DataListDAC : Context, IDataListDAC
    {
        public async Task<RSV_Global<List<DataList>>> GetByType(string NameDateListType)
        {

            RSV_Global<List<DataList>> infoResult = new RSV_Global<List<DataList>>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pNameDateListType", SqlDbType.VarChar, 50, ParameterDirection.Input, NameDateListType),
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[DataListByTypeGet]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResult.Data = reader.Translate<DataList>().ToList();
            }
            command.Connection.Close();
            return infoResult;
        }
    }
}
