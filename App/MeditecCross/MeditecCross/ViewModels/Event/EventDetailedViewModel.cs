using MeditecCross.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeditecCross.ViewModels.Event
{
    public class EventDetailedViewModel : BaseViewModel
    {
        private Models.Event _evt;
        public EventDetailedViewModel(Models.Event evt)
        {
            _evt = evt;
        }

        public string EventTitle
        {
            get { return _evt.Title; }
            set { _evt.Title = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return _evt.Description; }
            set { _evt.Description = value; OnPropertyChanged(); }
        }
        public string Place
        {
            get { return _evt.Place; }
            set { _evt.Place = value; OnPropertyChanged(); }
        }
        public List<Trainer> Trainers
        {
            get { return _evt.Trainers; }
            set { _evt.Trainers = value; OnPropertyChanged(); }
        }

        
        /*
        int _contactsSelectedIndex;
        public int ContactsSelectedIndex
        {
            get
            {
                return _contactsSelectedIndex;
            }
            set
            {
                if (_contactsSelectedIndex != value)
                {
                    _contactsSelectedIndex = value;
                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(ContactsSelectedIndex));
                    SelectedContact = _evt.Trainers.. [countriesSelectedIndex];
                }
            }
        }*/

        public List<Trainer> Trainers1 => _evt.Trainers;


    }
}
