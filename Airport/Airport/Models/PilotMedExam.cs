using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class PilotMedExam : INotifyPropertyChanged
    {
        private ObjectId _examId;
        private string _result;
        private ObjectId? _pilotId; 
        private ObjectId? _doctorId;
        private DateTime? _dateExamination;

        [BsonId]
        public ObjectId ExamId
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
        public ObjectId? PilotId
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
        public ObjectId? DoctorId
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

