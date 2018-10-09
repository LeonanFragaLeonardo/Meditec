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
    public partial class EventsTabbedPage : TabbedPage
    {
        public EventsTabbedPage ()
        {
            InitializeComponent();
            Children.Add(new EventsListPage(1) { Title = "Minicursos"});
            Children.Add(new EventsListPage(2) { Title = "Palestras" });
            Children.Add(new EventsListPage(3) { Title = "Apresentações" });
            BarTextColor = Color.FromHex("#273238");
        }
    }
}