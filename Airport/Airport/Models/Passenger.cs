using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Airport.Models
{
    public class Passenger
    {
        [BsonId]

    
        public int PassengerId { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("passportNumber")]
        public string PassportNumber { get; set; }

        [BsonElement("internPassportNumber")]
        public string InternPassportNumber { get; set; }

        [BsonElement("bagageStatus")]
        public string BaggageStatus { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("fullname")]
        public string FullName { get; set; }
        public override string ToString()
        {
            return $"PassengerId: {PassengerId}, Fullname: { FullName}, Age: {Age}, Gender: {Gender}, PassportNumber: {PassportNumber}, " +
                   $"InternPassportNumber: {InternPassportNumber}, BaggageStatus: {BaggageStatus}, PhoneNumber: {PhoneNumber}, Email: {Email}";
        }

        /* public Passenger(int passengerId, int age, string gender, string passportNumber, string internPassportNumber, string baggageStatus, string phoneNumber, string email, string fullname)
         {
             this.passengerId = passengerId;
             this.age = age;
             this.gender = gender;
             this.passportNumber = passportNumber;
             this.internPassportNumber = internPassportNumber;
             this.baggageStatus = baggageStatus;
             this.phoneNumber = phoneNumber;
             this.email = email;
             this.fullname = fullname;
         }

         public int PassengerId { get => passengerId; set => passengerId = value; }
         public int Age { get => age; set => age = value; }
         public string Gender { get => gender; set => gender = value; }
         public string PassportNumber { get => passportNumber; set => passportNumber = value; }
         public string InternPassportNumber { get => internPassportNumber; set => internPassportNumber = value; }
         public string BaggageStatus { get => baggageStatus; set => baggageStatus = value; }
         public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
         public string Email { get => email; set => email = value; }
         public string Fullname { get => fullname; set => fullname = value; }
        */
    }
}



