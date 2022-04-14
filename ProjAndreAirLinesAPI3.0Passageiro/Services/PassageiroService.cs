using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0Passageiro.Utils;
using Models;
using MongoDB.Driver;


namespace ProjAndreAirLinesAPI3._0Passageiro.Service
{
    public class PassageiroService
    {
        private readonly IMongoCollection<Passageiro> _passageiros;

        public PassageiroService(IPassageiroDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _passageiros = database.GetCollection<Passageiro>(settings.PassageiroCollectionName);
        }

        public List<Passageiro> Get() =>
            _passageiros.Find(passageiro => true).ToList();

        public Passageiro Get(string id) =>
            _passageiros.Find<Passageiro>(passageiro => passageiro.Id == id).FirstOrDefault();

        public Passageiro Create(Passageiro passageiro)
        {
            _passageiros.InsertOne(passageiro);
            return passageiro;
        }

        public void Update(string id, Passageiro passageiroIn) =>
            _passageiros.ReplaceOne(cliente => cliente.Id == id, passageiroIn);

        public void Remove(Passageiro passageiroIn) =>
            _passageiros.DeleteOne(passageiro => passageiro.Id == passageiroIn.Id);

        public void Remove(string id) =>
            _passageiros.DeleteOne(passageiro => passageiro.Id == id);
    
    }
}
