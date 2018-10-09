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
	public partial class CertificatesPage : ContentPage
	{
        public CertificatesPage()
        {
            InitializeComponent();
            if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
            {
                DisplayAlert("Informação", "Percebemos que você está sem conexão com a Internet, infelizmente, para acessar esse conteúdo, nós precisamos" +
                    "de conexão com a Internet.", "Entendi");
            }
            //var browser = new WebView();
            //browser.Source = "http://meditec.md.utfpr.edu.br/certificados";
            //Content = browser;
            //webview.Source = "http://meditec.md.utfpr.edu.br/edicoes-anteriores";

        }
	}
}