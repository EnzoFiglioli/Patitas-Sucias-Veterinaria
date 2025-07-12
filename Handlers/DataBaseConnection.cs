using MySql.Data.MySqlClient;
using System;


namespace MiAppVeterinaria.handlers
{
    public class DBConnection
    {

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }

        private static DBConnection? _instance = null;

        private DBConnection()
        {
            this.Server = "localhost";
            this.DatabaseName = "veter_patas_sucias";
            this.UserName = "root";
            this.Password = "1234";
            this.Port = "3306";
        }

        public MySqlConnection CreateConnection()
        {
            MySqlConnection? uri = new MySqlConnection();
            try
            {
                uri.ConnectionString =
                    "datasource=" + this.Server +
                    ";port=" + this.Port +
                    ";username=" + this.UserName +
                    ";password=" + this.Password +
                    ";database=" + this.DatabaseName
                    ;
            }
            catch (Exception ex)
            {
                uri = null;
                throw ex;
            }
            return uri;
        }
        public static DBConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBConnection();
            }
            return _instance;
        }
    }
}
