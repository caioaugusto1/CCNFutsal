using System.Configuration;

namespace ColaComNois.Context
{
    public class ConnectionString
    {
        static public string Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ColaComNoisContext"].ConnectionString;
            return connectionString;
        }
    }
}