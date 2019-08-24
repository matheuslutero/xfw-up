using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xfw.Models;
using Xfw.Services;

namespace Xfw.ViewModels
{
    public sealed class HomeViewModel : BaseViewModel
    {
        private readonly IMovieService movieService;

        public HomeViewModel()
        {
            movieService = new MovieService();
        }

        private ObservableCollection<Movie> _movies
            = new ObservableCollection<Movie>();

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set { _movies = value; OnPropertyChanged(); }
        }

        public override async Task Initialize()
        {
            await ExecuteBusyAction(async () =>
            {
                (var error, var upcomingMovies) =
                    await movieService.GetUpcoming();

                if (error != null)
                {
                    await Application
                    .Current
                    .MainPage.DisplayAlert("Error", error, "OK");

                    return;
                }

                Movies = new ObservableCollection<Movie>(upcomingMovies);
            });
        }
    }
}
