using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeditecCross.Models
{
    public class SocialNetwork
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("iconCode")]
        public string IconCode { get; set; }
        [JsonProperty("htmlIcon")]
        public string HtmlIcon { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is SocialNetwork socialNetwork))
                return false;
            return Id.Equals(socialNetwork.Id) &&
                Title.Equals(socialNetwork.Title);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Title.GetHashCode();
        }
    }
}
