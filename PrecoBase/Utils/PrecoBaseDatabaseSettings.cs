namespace ProjAndreAirLinesAPI3._0PrecoBase.Utils
{
    public class PrecoBaseDatabaseSettings : IPrecoBaseDatabaseSettings
    {
        public string PrecoBaseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
