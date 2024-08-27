using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

    namespace Airport.Models
    {
        public class PassengerCompletedFlight
    {
            [BsonId]            
            public ObjectId Id { get; set; }

            [BsonElement("passengerCompletedFlightId")]
            public int PassengerId { get; set; }

            [BsonElement("age")]
            public int Age { get; set; }

            [BsonElement("gender")]
            public string Gender { get; set; }

            [BsonElement("passportNumber")]
            public string PassportNumber { get; set; }

            [BsonElement("internPassportNumber")]
            public string InternPassportNumber { get; set; }

            [BsonElement("baggageStatus")]
            public string BaggageStatus { get; set; }

            [BsonElement("phoneNumber")]
            public string PhoneNumber { get; set; }

            [BsonElement("email")]
            public string Email { get; set; }

            [BsonElement("fullname")]
            public string FullName { get; set; }

            [BsonElement("completedFlightId")]
            public int CompletedFlightId { get; set; }
        }
   }

