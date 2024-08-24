using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class PilotMedExam
    {
        private int examId;
        private string result;
        private int pilotId;
        private int doctorId;

        public PilotMedExam(int examId, string result, int pilotId, int doctorId)
        {
            this.examId = examId;
            this.result = result;
            this.pilotId = pilotId;
            this.doctorId = doctorId;
        }

        public int ExamId { get => examId; set => examId = value; }
        public string Result { get => result; set => result = value; }
        public int PilotId { get => pilotId; set => pilotId = value; }
        public int DoctorId { get => doctorId; set => doctorId = value; }
    }

}
