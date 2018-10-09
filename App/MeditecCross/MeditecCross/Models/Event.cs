using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeditecCross.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("place")]
        public string Place { get; set; }
        [JsonProperty("startDatetime")]
        public DateTime StartDatetime { get; set; }
        [JsonProperty("endDatetime")]
        public DateTime EndDatetime { get; set; }
        [JsonProperty("trainerList")]
        public List<Trainer> Trainers { get; set; }

        [JsonIgnore]
        public string Date
        {
            
            get { return StartDatetime.Date.ToString("dd/MM"); }
        }
        [JsonIgnore]
        public string STime
        {
            get { return StartDatetime.TimeOfDay.ToString(); }
        }
        [JsonIgnore]
        public string ETime
        {
            get { return EndDatetime.TimeOfDay.ToString(); }
        }
        [JsonIgnore]
        public Trainer FirstTrainer
        {
            get { return Trainers.Count > 0 ? Trainers[0] : new Trainer() { Name = "Instrutor não definido"}; }
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Event evt))
                return false;
            return Id.Equals(evt.Id) &&
                Title.Equals(evt.Title) &&
                Description.Equals(evt.Description) &&
                Type.Equals(evt.Type) &&
                Place.Equals(evt.Place) &&
                StartDatetime.Equals(evt.StartDatetime) &&
                EndDatetime.Equals(evt.EndDatetime);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Title.GetHashCode() + Type.GetHashCode();
        }

    }
}
