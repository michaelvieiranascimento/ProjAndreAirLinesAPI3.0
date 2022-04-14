namespace ProjAndreAirLinesAPI3._0Voo.Utils
{
    public interface IVooDatabaseSettings
    {
        string VooCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
