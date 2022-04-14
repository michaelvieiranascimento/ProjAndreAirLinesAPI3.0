using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0Voo.Utils;
using Models;
using MongoDB.Driver;

namespace ProjAndreAirLinesAPI3._0Voo.Services
{
    public class VooService
    {
        private readonly IMongoCollection<Voo> _voos;

        public VooService(IVooDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _voos = database.GetCollection<Voo>(settings.VooCollectionName);
        }

        public List<Voo> Get() =>
            _voos.Find(cliente => true).ToList();

        public Voo Get(string id) =>
            _voos.Find<Voo>(cliente => cliente.Id == id).FirstOrDefault();

        public Voo Create(Voo cliente)
        {
            _voos.InsertOne(cliente);
            return cliente;
        }

        public void Update(string id, Voo clienteIn) =>
            _voos.ReplaceOne(cliente => cliente.Id == id, clienteIn);

        public void Remove(Voo clienteIn) =>
            _voos.DeleteOne(cliente => cliente.Id == clienteIn.Id);

        public void Remove(string id) =>
            _voos.DeleteOne(cliente => cliente.Id == id);
    }
}
