using MeditecCross.Models;
using MeditecCross.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditecCross.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsListPage : ContentPage
    {
        private EventListViewModel eventListViewModel;
        private int type;
        public EventsListPage(int type)
        {
            this.type = type;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            eventListViewModel = new EventListViewModel(type);
            this.BindingContext = eventListViewModel;
            //LoadEvents();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.BindingContext = this;
        }
        private async void OnItemTapped(object o, ItemTappedEventArgs a)
        {
            var item = a.Item as Event;

            //var x = a.Group as ListViewGrouping<string, AsCargoAttributes>;
            //var x = listViewCargos.SelectedItem as ListViewGrouping<string, AsCargoAttributes>;
            //await DisplayAlert("Ok", x.Key + " " + x.ToList(), "Ok");
            //var item = (o as ListView).SelectedItem as AsCargoAttributes;
            //await DisplayAlert("OK", item.GetCargo, "OK");
            ((ListView)o).SelectedItem = null;
            await Navigation.PushAsync(new EventDetailedPage(item), true);
        }
    }
}