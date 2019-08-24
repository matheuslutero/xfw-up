using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xfw.Models;

namespace Xfw.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Movie movie)
        {
            InitializeComponent();
            BindingContext = movie;
        }
    }
}
