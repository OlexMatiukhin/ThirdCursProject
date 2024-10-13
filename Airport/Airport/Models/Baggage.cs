using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Airport.Models
{
   
    public class Baggage
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)] // Если вы используете int для идентификатора
        public int BaggageId { get; set; } // Публичное свойство для доступа и сериализации

        [BsonElement("type")]
        public string BaggageType { get; set; }

        [BsonElement("weight")]
        public double Weight { get; set; }

        [BsonElement("payment")]
        public decimal Payment { get; set; }

        [BsonElement("passangerId")]
        public int PassangerId { get; set; }
    }
}
 
