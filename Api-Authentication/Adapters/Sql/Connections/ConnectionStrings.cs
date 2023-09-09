namespace Api_Authentication.Adapters.Sql.Connections
{
    public class ConnectionStrings
    {
        public Dictionary<string, ConnectString> Connect { get; set; }

        public string GetConnectString(string name, string dataBase)
        {
            return Connect.First(x => x.Key == name ).Value.GetConnectString(dataBase);
        }


    }
    public class ConnectString
    {
        public string? Server { get; set; }
        public string? user { get; set; }
        public string? Password { get; set; }

        public string GetConnectString(string dataBase)
        {
            return $"Server={Server};Database={dataBase};User Id={user};Password={Password};TrustServerCertificate=True;";
        }

    }
}
