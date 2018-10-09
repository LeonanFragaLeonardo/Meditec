using MeditecCross.Models;
using MeditecCross.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeditecCross.Views.Events
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailedPage : ContentPage
	{
		public EventDetailedPage (Event evt)
		{
			InitializeComponent ();
            this.BindingContext = new EventDetailedViewModel(evt);
		}

       
    }
}