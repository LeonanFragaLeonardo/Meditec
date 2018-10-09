using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeditecCross.Models
{
    public class TrainerContactPK
    {
        [JsonProperty("trainer")]
        public int Trainer { get; set; }
        [JsonProperty("socialNetwork")]
        public int SocialNetwork { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is TrainerContactPK trainerContactPK))
                return false;
            return Trainer.Equals(trainerContactPK.Trainer) && SocialNetwork.Equals(trainerContactPK.SocialNetwork);
        }
        public override int GetHashCode()
        {
            return Trainer.GetHashCode() + SocialNetwork.GetHashCode();
        }
    }
}
