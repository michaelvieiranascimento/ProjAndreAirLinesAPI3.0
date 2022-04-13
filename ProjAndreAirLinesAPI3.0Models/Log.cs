using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjAndreAirLinesAPI3._0Models
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string EntidadeAntes { get; set; }
        public string EntidadeDepois { get; set; }
        public string Operacao { get; set; }
        public DateTime Data { get; set; }
    }
}
