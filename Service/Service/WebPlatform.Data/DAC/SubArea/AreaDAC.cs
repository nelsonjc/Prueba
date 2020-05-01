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

    public class AreaDAC : Context, IAreaDAC
    {
        public async Task<RSV_Global<List<Area>>> Get(int IDArea)
        {
            RSV_Global<List<Area>> infoResult = new RSV_Global<List<Area>>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pIDArea", SqlDbType.Int, 10, ParameterDirection.Input, IDArea),
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[AreaGet]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResult.Data = reader.Translate<Area>().ToList();
            }
            command.Connection.Close();
            return infoResult;
        }

        public async Task<RSV_Global<List<SubArea>>> GetSubAreaByIDArea(int IDArea)
        {

            RSV_Global<List<SubArea>> infoResult = new RSV_Global<List<SubArea>>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pIDArea", SqlDbType.Int, 10, ParameterDirection.Input, IDArea),
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[SubAreaByIDAreaGet]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResult.Data = reader.Translate<SubArea>().ToList();
            }
            command.Connection.Close();
            return infoResult;
        }
    }
}
