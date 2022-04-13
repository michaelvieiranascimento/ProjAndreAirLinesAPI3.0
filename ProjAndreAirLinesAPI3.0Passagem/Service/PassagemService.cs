using MongoDB.Driver;

namespace ProjAndreAirLinesAPI3._0Passagem.Service
{
    public class PassagemService
    {
        private readonly IMongoCollection<PassagemService> _passagems;

        public AeropoService(IProjAeroportoAPI settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _aeroportos = database.GetCollection<Aeroporto>(settings.AeroportoCollectionName);
        }

        public List<Aeroporto> Get() =>
            _aeroportos.Find(aeroporto => true).ToList();

        public Aeroporto Get(string id) =>
            _aeroportos.Find<Aeroporto>(aeroporto => aeroporto.Id == id).FirstOrDefault();

        public Aeroporto Create(Aeroporto aeroporto)
        {
            _aeroportos.InsertOne(aeroporto);
            return aeroporto;
        }

        public void Update(string id, Aeroporto aeroportoIn) =>
            _aeroportos.ReplaceOne(aeroporto => aeroporto.Id == id, aeroportoIn);

        public void Remove(Aeroporto aeroportoIn) =>
            _aeroportos.DeleteOne(aeroporto => aeroporto.Id == aeroportoIn.Id);

        public void Remove(string id) =>
            _aeroportos.DeleteOne(aeroporto => aeroporto.Id == id);
    }
}
