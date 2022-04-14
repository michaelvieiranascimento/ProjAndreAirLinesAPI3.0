namespace ProjAndreAirLinesAPI3._0Passageiro.Utils
{
    public class PassageiroDatabaseSettings : IPassageiroDatabaseSettings
    {
        public string PassageiroCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
