using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeditecCross.Models
{
    public class Agenda
    {
        [JsonProperty("agendaPK")]
        public AgendaPK AgendaPK { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("eventList")]
        public List<Event> Events { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Agenda agenda))
                return false;
            return AgendaPK.Equals(agenda.AgendaPK) &&
                Title.Equals(agenda.Title);

        }

        public override int GetHashCode()
        {
            return AgendaPK.GetHashCode() + Title.GetHashCode();
        }
    }
}
