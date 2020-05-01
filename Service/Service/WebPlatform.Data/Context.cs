namespace WebPlatform.Data
{
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        private string _connectionString;
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        public Context()
        {

        }

        public Context(string strConexion)
        {
            this._connectionString = strConexion;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(this._connectionString);
        }
    }
}
