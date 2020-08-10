using System.ComponentModel;
using Xamarin.Forms;
using VirtualJourney.ViewModels;

namespace VirtualJourney.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}