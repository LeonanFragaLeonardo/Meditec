using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditecCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            Children.Add(new CurrentEditionPage() { Title = "Edição Atual" });
            Children.Add(new MeditecWebPage("http://meditec.md.utfpr.edu.br/edicoes-anteriores") { Title = "Edições Anteriores" });
            Children.Add(new MeditecWebPage("http://meditec.md.utfpr.edu.br/contato") { Title = "Contato" });
            Children.Add(new MeditecWebPage("http://meditec.md.utfpr.edu.br/certificados") { Title = "Certificados" });
            BarTextColor = Color.FromHex("#273238");
            CheckFirstTime();
        }


        private async void CheckFirstTime()
        {
            var events = await App.EventManager.GetDataListAsync("event");
            var current = Connectivity.NetworkAccess;
            if (!(Preferences.ContainsKey("fst_time_key")) && (current == NetworkAccess.Internet))
            {
                Preferences.Set("fst_time_key", false);
                var serializedEvents = JsonConvert.SerializeObject(events, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                Preferences.Set("events_key", serializedEvents);
            }
        }
    }
}