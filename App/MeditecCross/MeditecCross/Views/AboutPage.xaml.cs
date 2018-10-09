using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditecCross.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
            if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
            {
                DisplayAlert("Informação", "Percebemos que você está sem conexão com a Internet, infelizmente, para acessar esse conteúdo, nós precisamos" +
                    "de conexão com a Internet.", "Entendi");
            }
        }
	}
}