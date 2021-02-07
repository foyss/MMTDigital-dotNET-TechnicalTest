using Microsoft.Extensions.Configuration;
using SSETechnicalTest.API.Constants;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SSETechnicalTest.API.Dapper
{
    public class MmtSqlConnectionFactory
    {
        private readonly IConfiguration _config;

        public MmtSqlConnectionFactory(IConfiguration configuration) => _config = configuration
            ?? throw new ArgumentNullException(nameof(configuration));

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_config[AppSettings.SqlMmtShop]);

            await sqlConnection.OpenAsync().ConfigureAwait(false);
            return sqlConnection;
        }
    }
}
