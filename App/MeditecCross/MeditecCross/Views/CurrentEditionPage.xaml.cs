using MeditecCross.Views.Events;
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
	public partial class CurrentEditionPage : ContentPage
	{
		public CurrentEditionPage()
		{
			InitializeComponent ();
		}

        private void OnButtonEventsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventsTabbedPage());
        }
        private void OnButtonInscriptionClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MeditecWebPage("http://utfpr.jacad.com.br:8080/academico/eventos/"));
        }
    }
}