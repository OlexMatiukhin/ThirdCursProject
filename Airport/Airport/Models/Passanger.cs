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
        private int passengerId;
        private int age;
        private string gender;
        private string passportNumber;
        private string internPassportNumber;
        private string baggageStatus;
        private string phoneNumber;
        private string email;
        private string fullname;

        public Passenger(int passengerId, int age, string gender, string passportNumber, string internPassportNumber, string baggageStatus, string phoneNumber, string email, string fullname)
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
    }
}



