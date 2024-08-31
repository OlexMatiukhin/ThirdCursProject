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
        private string type;
        [BsonElement("weight")]
        private double weight;
        [BsonElement("payment")]
        private decimal payment;
        [BsonElement("passangerId")]
        private int passangerId;

        /*public Baggage(int baggageId, string type, double weight, decimal payment, int passengerId)
        {
            this.baggageId = baggageId;
            this.type = type;
            this.weight = weight;
            this.payment = payment;
            this.passengerId = passengerId;
        }*/

        public int BaggageId { get => baggageId; set => baggageId = value; }
        public string Type { get => type; set => type = value; }
        public double Weight { get => weight; set => weight = value; }
        public decimal Payment { get => payment; set => payment = value; }
        public int PassangerId { get => passangerId; set => passangerId = value; }
    }
    
}
