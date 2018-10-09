using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MeditecCross.ViewModels.Event
{
    public class EventListViewModel : BaseViewModel
    {
        private CancellationTokenSource cts;
        private int _type;
        public EventListViewModel(int type)
        {
            this.EventsCollection = new ObservableCollection<Models.Event>();
            cts = new CancellationTokenSource();
            CreateCommands();
            _type = type;
            LoadEvents(type, false);
        }

        #region Properties
        public ObservableCollection<Models.Event> EventsCollection { get; set; }

        private Models.Event _selectedEvent;
        public Models.Event SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand RefreshEventsCommand { get; set; }

        private void CreateCommands()
        {
            RefreshEventsCommand = new Command( () =>
            {
                try
                {
                    IsBusy = true;
                    EventsCollection.Clear();
                    cts.Cancel();
                    cts.Dispose();
                    cts = new CancellationTokenSource();
                    LoadEvents(_type, true);
                }
                catch (Exception){}
                finally
                {
                    IsBusy = false;
                }
            });
        }

        #endregion
        #region Populate Methods
        private void LoadEvents(int type, bool updateRequested)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                try
                {
                    cts.Token.ThrowIfCancellationRequested();   
                    List<Models.Event> events = new List<Models.Event>();
                    if (Preferences.ContainsKey("events_key"))
                    {
                        var eventsSerialized = Preferences.Get("events_key", "null");
                        if (eventsSerialized is null || eventsSerialized.Length <= 0 || updateRequested)
                        {
                            //events = await App.EventManager.GetDataListAsync("event/type=" + type);

                            events = await App.EventManager.GetDataListAsync("event");
                            eventsSerialized = JsonConvert.SerializeObject(events, Newtonsoft.Json.Formatting.None,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                });
                            Preferences.Set("events_key", eventsSerialized);
                            events = events.FindAll(x => x.Type == type);

                        }
                        else
                        {
                            events = JsonConvert.DeserializeObject<List<Models.Event>>(eventsSerialized);
                            events = events.FindAll(x => x.Type == type);
                        }

                        foreach (var item in events)
                        {
                            EventsCollection.Add(item);
                        }
                        //EventsCollection = new ObservableCollection<Models.Event>(events);
                    }
                    IsBusy = false;
                } catch (OperationCanceledException) { IsBusy = false; }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Lamentamos!", "R.I.P Servidor :(", "Meus Pêsames!");
                    IsBusy = false;
                }
            });

            //EventsCollection = new ObservableCollection<Models.Event>(events);
        }


        #endregion


    }
}
