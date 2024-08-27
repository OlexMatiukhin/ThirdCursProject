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
        public ObjectId Id { get; set; }    

        [BsonElement("examId")]
        public int ExamId { get; set; }

        [BsonElement("result")]
        public string Result { get; set; }

        [BsonElement("pilotId")]
        public int PilotId { get; set; }

        [BsonElement("doctorId")]
        public int DoctorId { get; set; }

        /*public PilotMedExam(int examId, string result, int pilotId, int doctorId)
        {
            this.examId = examId;
            this.result = result;
            this.pilotId = pilotId;
            this.doctorId = doctorId;
        }

        public int ExamId { get => examId; set => examId = value; }
        public string Result { get => result; set => result = value; }
        public int PilotId { get => pilotId; set => pilotId = value; }
        public int DoctorId { get => doctorId; set => doctorId = value; */
    }

}
