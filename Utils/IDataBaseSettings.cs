namespace POntheFly.Utils
{
    public interface IDataBaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string FlightsCollectionName { get; set; }
    }
}
