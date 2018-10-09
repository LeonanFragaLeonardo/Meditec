using System;
using Xamarin.Forms;
using MeditecCross.Views;
using Xamarin.Forms.Xaml;
using MeditecCross.Views.Events;
using MeditecCross.Services.Managers;
using MeditecCross.Models;
using MeditecCross.Services;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MeditecCross
{

    
    
    public partial class App : Application
    {
        public static GenericManager<Agenda> AgendaManager { get; private set; }
        public static GenericManager<Event> EventManager { get; private set; }


        public App()
        {
            InitializeComponent();

            AgendaManager = new GenericManager<Agenda>(new GenericService<Agenda>());
            EventManager = new GenericManager<Event>(new GenericService<Event>());
            SetupToolbar();
            //MainPage = new EventsTabbedPage();
            //MainPage = new Views.MainPage();
            var page = new NavigationPage(new MainPage());

            


            MainPage = page;
        }
        public void SetupToolbar()
        {
            //SET PRIMARY TOOLBAR COLOR
            Current.Resources = new ResourceDictionary();
            //Color xamarin_color = Color.FromHex("#3498db");
            Color xamarin_color = Color.FromHex("#263238");
            var navigationStyle = new Style(typeof(NavigationPage));
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = xamarin_color };
            navigationStyle.Setters.Add(barBackgroundColorSetter);
            Current.Resources.Add(navigationStyle);
        }
        protected override void OnStart()
        {
            
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
