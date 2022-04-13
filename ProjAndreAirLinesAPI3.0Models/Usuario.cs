using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjAndreAirLinesAPI3._0Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Setor { get; set; }
        public Funcao Funcao { get; set; }
    }
}
