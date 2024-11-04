using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class PilotMedExam : INotifyPropertyChanged
    {
        private int _examId;
        private string _result;
        private int _pilotId;
        private int _doctorId;
        private DateTime? _dateExamination;

        [BsonId]
        public int ExamId
        {
            get => _examId;
            set
            {
                if (_examId != value)
                {
                    _examId = value;
                    OnPropertyChanged(nameof(ExamId));
                }
            }
        }

        [BsonElement("result")]
        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        [BsonElement("pilotId")]
        public int PilotId
        {
            get => _pilotId;
            set
            {
                if (_pilotId != value)
                {
                    _pilotId = value;
                    OnPropertyChanged(nameof(PilotId));
                }
            }
        }

        [BsonElement("doctorId")]
        public int DoctorId
        {
            get => _doctorId;
            set
            {
                if (_doctorId != value)
                {
                    _doctorId = value;
                    OnPropertyChanged(nameof(DoctorId));
                }
            }
        }

        [BsonElement("dateExamination")]
        public DateTime? DateExamination
        {
            get => _dateExamination;
            set
            {
                if (_dateExamination != value)
                {
                    _dateExamination = value;
                    OnPropertyChanged(nameof(DateExamination));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

