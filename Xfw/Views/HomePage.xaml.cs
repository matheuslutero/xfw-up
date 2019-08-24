using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xfw.Models;
using Xfw.ViewModels;

namespace Xfw.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel ViewModel;

        public HomePage()
        {
            InitializeComponent();

            ViewModel = new HomeViewModel();
            BindingContext = ViewModel;
        }

        protected override async void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            await ViewModel.Initialize();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var movie = e.Item as Movie;

            await Navigation.PushAsync(new DetailPage(movie));
        }
    }
}
