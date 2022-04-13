using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjAndreAirLinesAPI3._0Models
{
    public class Passageiro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CodPassaporte { get; set; }
    }
}
