namespace ProjAndreAirLinesAPI3._0Usuario.Utils
{
    public interface IUsuarioDatabaseSettings
    {
        string UsuarioCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
