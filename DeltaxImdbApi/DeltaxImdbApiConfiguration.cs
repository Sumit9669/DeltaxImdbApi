using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaxImdbApi
{
    public static class DeltaxImdbApiConfiguration
    {
        private static string _customConnectionString;
        public static string ConnectionString 
        {
            get
            {
                var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                
                if (!string.IsNullOrEmpty(_customConnectionString))
                    databaseUrl = _customConnectionString;

                if (string.IsNullOrEmpty(databaseUrl))
                    return string.Empty;

                var databaseUri = new Uri(databaseUrl);
                var userInfo = databaseUri.UserInfo.Split(':');

                var builder = new Npgsql.NpgsqlConnectionStringBuilder
                {
                    Host = databaseUri.Host,
                    Port = databaseUri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = databaseUri.LocalPath.TrimStart('/'),
                    SslMode = Npgsql.SslMode.Require,
                    TrustServerCertificate = true
                };

                return builder.ToString();

            }
            set
            {
                _customConnectionString = value;
            }
        }

        public static Npgsql.NpgsqlConnection GetConnection()
        {
            return new Npgsql.NpgsqlConnection(ConnectionString);
        }
    }
}
