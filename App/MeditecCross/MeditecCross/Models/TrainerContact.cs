using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeditecCross.Models
{
    public class TrainerContact
    {
        [JsonProperty("trainerContactPK")]
        public TrainerContactPK TrainerContactPK { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("socialNetwork")]
        public SocialNetwork SocialNetwork { get; set; }
        [JsonProperty("trainer")]
        public Trainer Trainer { get; set; }


        TrainerContact _selectedContact;
        public TrainerContact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (value.Link.Contains("http://") &&
                    value.Link.Contains(".com"))
                        Device.OpenUri(new Uri(value.Link));
                });

            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TrainerContact trainerContact))
                return false;
            return TrainerContactPK.Equals(trainerContact.TrainerContactPK);
        }
        public override int GetHashCode()
        {
            return Trainer.GetHashCode() + SocialNetwork.GetHashCode() + TrainerContactPK.GetHashCode() + Link.GetHashCode();
        }

        public override string ToString()
        {
            return SocialNetwork.Title + " - " + Link;
        }

    }
}
