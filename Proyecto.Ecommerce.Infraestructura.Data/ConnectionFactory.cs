using System;
using Proyecto.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Ecommerce.Infraestructura.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if(sqlConnection == null) { return null; }

                sqlConnection.ConnectionString = _configuration.GetConnectionString("DevConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
