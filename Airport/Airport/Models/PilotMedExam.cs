using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class PilotMedExam
    {
        [BsonId]

        public int ExamId { get; set; }

        [BsonElement("result")]
        public string Result { get; set; }

        [BsonElement("pilotId")]
        public int PilotId { get; set; }

        [BsonElement("doctorId")]
        public int DoctorId { get; set; }

        [BsonElement("dateExamination")]
        public DateTime DateExamination { get; set; }

    }

}
