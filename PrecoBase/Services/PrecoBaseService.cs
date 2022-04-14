using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0PrecoBase.Utils;
using Models;
using MongoDB.Driver;

namespace ProjAndreAirLinesAPI3._0PrecoBase.Services
{
    public class PrecoBaseService
    {
        private readonly IMongoCollection<PrecoBase> _precosbase;

        public PrecoBaseService(IPrecoBaseDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _precosbase = database.GetCollection<PrecoBase>(settings.PrecoBaseCollectionName);
        }

        public List<PrecoBase> Get() =>
            _precosbase.Find(precobase => true).ToList();

        public PrecoBase Get(string id) =>
            _precosbase.Find<PrecoBase>(precobase => precobase.Id == id).FirstOrDefault();

        public PrecoBase Create(PrecoBase precobase)
        {
            _precosbase.InsertOne(precobase);
            return precobase;
        }

        public void Update(string id, PrecoBase precobaseIn) =>
            _precosbase.ReplaceOne(cliente => cliente.Id == id, precobaseIn);

        public void Remove(PrecoBase passageiroIn) =>
            _precosbase.DeleteOne(passageiro => passageiro.Id == passageiroIn.Id);

        public void Remove(string id) =>
            _precosbase.DeleteOne(precobase => precobase.Id == id);
    }
}
