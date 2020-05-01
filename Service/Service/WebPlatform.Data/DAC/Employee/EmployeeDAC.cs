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

    public class EmployeeDAC : Context, IEmployeeDAC
    {
        public async Task<RSV_Global<Employee>> GetByID(int IDEmployee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pIDEmployee", SqlDbType.Int, 10, ParameterDirection.Input, IDEmployee),
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[EmployeeByIDGet]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResult.Data = reader.Translate<Employee>().ToList().FirstOrDefault();
            }
            command.Connection.Close();
            return infoResult;
        }

        public async Task<RSV_Global<Employee>> Create(Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee> { Data = employee };
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pIDDocumentType", SqlDbType.Int, 10, ParameterDirection.Input, employee.IDDocumentType),
                ParameterHelper.NewParameter("@pDocumentNumber", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.DocumentNumber),
                ParameterHelper.NewParameter("@pName", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.Name),
                ParameterHelper.NewParameter("@pSecondName", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.SecondName),
                ParameterHelper.NewParameter("@pSurname", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.Surname),
                ParameterHelper.NewParameter("@pSecondSurname", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.SecondSurname),
                ParameterHelper.NewParameter("@pIDSubArea", SqlDbType.Int, 10, ParameterDirection.Input, employee.IDSubArea),
                ParameterHelper.NewParameter("@pURLImage", SqlDbType.VarChar, 255, ParameterDirection.Input, employee.URLImage),
                ParameterHelper.NewParameter("@pIDUserCreation", SqlDbType.Int, 10, ParameterDirection.Input, employee.IDUserCreation)
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[EmployeeCreate]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            infoResult.Data.IDEmployee = (int)await command.ExecuteScalarAsync();
            command.Connection.Close();
            return infoResult;
        }

        public async Task<RSV_Global<Employee>> Update(Employee employee)
        {
            RSV_Global<Employee> infoResult = new RSV_Global<Employee> { Data = employee };
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pIDEmployee", SqlDbType.Int, 10, ParameterDirection.Input, employee.IDEmployee),
                ParameterHelper.NewParameter("@pIDDocumentType", SqlDbType.Int, 10, ParameterDirection.Input, employee.IDDocumentType),
                ParameterHelper.NewParameter("@pDocumentNumber", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.DocumentNumber),
                ParameterHelper.NewParameter("@pName", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.Name),
                ParameterHelper.NewParameter("@pSecondName", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.SecondName),
                ParameterHelper.NewParameter("@pSurname", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.Surname),
                ParameterHelper.NewParameter("@pSecondSurname", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.SecondSurname),
                ParameterHelper.NewParameter("@pIDSubArea", SqlDbType.Int, 10, ParameterDirection.Input, employee.IDSubArea),
                ParameterHelper.NewParameter("@pURLImage", SqlDbType.VarChar, 255, ParameterDirection.Input, employee.URLImage),
                ParameterHelper.NewParameter("@pActive", SqlDbType.Bit, 4, ParameterDirection.Input, employee.Active)
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[EmployeeUpdate]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            infoResult.Data.IDEmployee = (int)await command.ExecuteScalarAsync();
            command.Connection.Close();
            return infoResult;
        }

        public async Task<RSV_Global<List<Employee>>> AutoComplete(Employee employee)
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pName", SqlDbType.VarChar, 200, ParameterDirection.Input, employee.FullName),
                ParameterHelper.NewParameter("@pNit", SqlDbType.VarChar, 50, ParameterDirection.Input, employee.DocumentNumber),
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[EmployeeAutocomplete]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResult.Data = reader.Translate<Employee>().ToList();
            }
            command.Connection.Close();
            return infoResult;
        }

        public async Task<RSV_Global<List<Employee>>> GetAll()
        {
            RSV_Global<List<Employee>> infoResult = new RSV_Global<List<Employee>>();
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[General].[EmployeeGetAll]";
            command.CommandType = CommandType.StoredProcedure;
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResult.Data = reader.Translate<Employee>().ToList();
            }
            command.Connection.Close();
            return infoResult;
        }
    }
}
