using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditecCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeditecWebPage : ContentPage
    {
        string _url;
        public MeditecWebPage(string url)
        {
            InitializeComponent();
            _url = url;
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
            {
                DisplayAlert("Informação", "Percebemos que você está sem conexão com a Internet, infelizmente, para acessar esse conteúdo, nós precisamos" +
                    "de conexão com a Internet.", "Entendi");
                webview.Source = "";
            }
            else
            {
                webview.Source = _url;

            }

        }
    }
}