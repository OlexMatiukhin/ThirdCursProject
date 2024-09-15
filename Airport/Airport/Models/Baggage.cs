using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Baggage
    {

        [BsonId]
        [BsonElement("baggageId")]
        private int baggageId;
        [BsonElement("type")]
        private string baggageType;
        [BsonElement("weight")]
        private double weight;
        [BsonElement("payment")]
        private decimal payment;
        [BsonElement("passangerId")]
        private int passangerId;


        public int BaggageId { get => baggageId; set => baggageId = value; }
        public string BaggageType { get => baggageType; set => baggageType = value; }
        public double Weight { get => weight; set => weight = value; }
        public decimal Payment { get => payment; set => payment = value; }
        public int PassangerId { get => passangerId; set => passangerId = value; }
    }
    
}
