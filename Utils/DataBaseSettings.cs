namespace POntheFly.Utils
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string FlightsCollectionName { get; set; }
    }
}
