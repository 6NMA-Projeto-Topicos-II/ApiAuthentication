namespace Api_Authentication.Adapters.Sql.Connections
{
    public class ConnectionStrings
    {
        public Dictionary<string, ConnectString> Connect { get; set; }


    }
    public class ConnectString
    {
        public string? Server { get; set; }
        public string? user { get; set; }
        public string? Password { get; set; }

    }
}
