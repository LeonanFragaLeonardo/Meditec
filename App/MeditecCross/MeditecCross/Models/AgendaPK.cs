using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeditecCross.Models
{
    public class AgendaPK
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is AgendaPK agendaPK))
                return false;
            return Id.Equals(agendaPK.Id) &&
                User.Equals(agendaPK.User);

        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + User.GetHashCode();
        }

    }
}
