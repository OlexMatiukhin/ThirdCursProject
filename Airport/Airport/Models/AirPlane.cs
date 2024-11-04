﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class AirPlane : INotifyPropertyChanged
    {
        [BsonId]
        public int PlaneId { get; set; }

        private string _type;
        [BsonElement("type")]
        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        private string _techCondition;
        [BsonElement("techCondition")]
        public string TechCondition
        {
            get => _techCondition;
            set
            {
                if (_techCondition != value)
                {
                    _techCondition = value;
                    OnPropertyChanged(nameof(TechCondition));
                }
            }
        }

        private string _interiorReadiness;
        [BsonElement("interiorReadiness")]
        public string InteriorReadiness
        {
            get => _interiorReadiness;
            set
            {
                if (_interiorReadiness != value)
                {
                    _interiorReadiness = value;
                    OnPropertyChanged(nameof(InteriorReadiness));
                }
            }
        }

        private string _planeFuelStatus;
        [BsonElement("planeFuelStatus")]
        public string PlaneFuelStatus
        {
            get => _planeFuelStatus;
            set
            {
                if (_planeFuelStatus != value)
                {
                    _planeFuelStatus = value;
                    OnPropertyChanged(nameof(PlaneFuelStatus));
                }
            }
        }

        private int _numberFlightsBeforeRepair;
        [BsonElement("numberFlightsBeforeRepair")]
        public int NumberFlightsBeforeRepair
        {
            get => _numberFlightsBeforeRepair;
            set
            {
                if (_numberFlightsBeforeRepair != value)
                {
                    _numberFlightsBeforeRepair = value;
                    OnPropertyChanged(nameof(NumberFlightsBeforeRepair));
                }
            }
        }

        private DateTime _techInspectionDate;
        [BsonElement("techInspectionDate")]
        public DateTime TechInspectionDate
        {
            get => _techInspectionDate;
            set
            {
                if (_techInspectionDate != value)
                {
                    _techInspectionDate = value;
                    OnPropertyChanged(nameof(TechInspectionDate));
                }
            }
        }

        private bool _assigned;
        [BsonElement("assigned")]
        public bool Assigned
        {
            get => _assigned;
            set
            {
                if (_assigned != value)
                {
                    _assigned = value;
                    OnPropertyChanged(nameof(Assigned));
                }
            }
        }

        private int _numberRepairs;
        [BsonElement("numberRepairs")]
        public int NumberRepairs
        {
            get => _numberRepairs;
            set
            {
                if (_numberRepairs != value)
                {
                    _numberRepairs = value;
                    OnPropertyChanged(nameof(NumberRepairs));
                }
            }
        }

        private DateTime _exploitationDate;
        [BsonElement("explotationDate")]
        public DateTime ExploitationDate
        {
            get => _exploitationDate;
            set
            {
                if (_exploitationDate != value)
                {
                    _exploitationDate = value;
                    OnPropertyChanged(nameof(ExploitationDate));
                }
            }
        }

        public override string ToString()
        {
            return $"Id: {PlaneId}, Тип: {Type}, Технічний стан: {TechCondition}, Готовність салону: {InteriorReadiness}, " +
                   $"Кількість польотів до ремонту: {NumberFlightsBeforeRepair}, Дата техінспекції: {TechInspectionDate.ToShortDateString()}, " +
                   $"Приписка: {Assigned}, Кількість ремонтів: {NumberRepairs}, Дата експлуатацї: {ExploitationDate.ToShortDateString()}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}