using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeditecCross.Models
{
    public class Trainer
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("resume")]
        public string Resume { get; set; }
        [JsonProperty("trainerContactList")]
        public List<TrainerContact> TrainerContacts { get; set; }

        TrainerContact _selectedContact;
        public TrainerContact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                bool result = Uri.TryCreate(value.Link, UriKind.Absolute, out Uri uriResult);
                if (result)
                    Device.OpenUri(new Uri(value.Link));
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Trainer trainer))
                return false;
            return Id.Equals(trainer.Id) &&
                Name.Equals(trainer.Name) &&
                Resume.Equals(trainer.Resume);
        }
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }
    }
}
