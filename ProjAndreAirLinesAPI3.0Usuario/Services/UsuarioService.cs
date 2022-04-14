using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0Usuario.Utils;
using Models;
using MongoDB.Driver;


namespace ProjAndreAirLinesAPI3._0Usuario.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IUsuarioDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _usuarios = database.GetCollection<Usuario>(settings.UsuarioCollectionName);
        }

        public List<Usuario> Get() =>
            _usuarios.Find(usuario => true).ToList();

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();

        public Usuario GetLoginSenha(string login, string senha) =>
            _usuarios.Find<Usuario>(usuario => usuario.Login == login && usuario.Senha == senha).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuarioIn) =>
            _usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioIn);

        public void Remove(Usuario aeroportoIn) =>
            _usuarios.DeleteOne(usuario => usuario.Id == usuario.Id);

        public void Remove(string id) =>
            _usuarios.DeleteOne(usuario => usuario.Id == id);
    }
}
