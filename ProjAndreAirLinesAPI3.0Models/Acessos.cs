﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjAndreAirLinesAPI3._0Models
{
    public class Acessos
    {
        public class Acesso
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public int Id { get; set; }
            public string Descricao { get; set; }
        }
    }
}
