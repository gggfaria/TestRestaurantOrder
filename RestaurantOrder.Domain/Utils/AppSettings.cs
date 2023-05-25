namespace RestaurantOrder.Domain.Utils
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

    }

    public class ConnectionStrings
    {
        public string SQLServerConnection { get; set; }
    }
}
