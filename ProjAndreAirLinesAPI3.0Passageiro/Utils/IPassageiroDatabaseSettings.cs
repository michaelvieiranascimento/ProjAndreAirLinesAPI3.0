namespace ProjAndreAirLinesAPI3._0Passageiro.Utils
{
    public interface IPassageiroDatabaseSettings
    {
        string PassageiroCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
