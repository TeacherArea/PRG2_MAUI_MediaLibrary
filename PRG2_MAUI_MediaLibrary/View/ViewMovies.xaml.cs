using System.Collections.ObjectModel;

namespace PRG2_MAUI_MediaLibrary.View
{
    public partial class ViewMovies : ContentPage
    {
        public ObservableCollection<Media> MediaItems { get; set; }

        public ViewMovies()
        {
            InitializeComponent();
            MediaItems = new ObservableCollection<Media>();
            BindingContext = this;
        }

        private void OnSaveMovieClicked(object sender, EventArgs e)
        {
            if (int.TryParse(movieReleaseYearEntry.Text, out int releaseYear))
            {
                DisplayAlert("Fel", "Skriv in att korrekt årtal, i formatet fyra heltal.", "OK");
                return;
            }

            var title = movieTitleEntry.Text;
            var genre = movieGenreEntry.Text;
            var manufacturer = movieManufacturerEntry.Text;
            var language = movieLanguageEntry.Text;
            var resolution = movieResolutionEntry.Text;
            var format = movieFormatEntry.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre) || string.IsNullOrWhiteSpace(manufacturer) || string.IsNullOrWhiteSpace(format))
            {
                DisplayAlert("Fel", "Alla fält måste fyllas i.", "OK");
                return;
            }

            var movie = new Movies(title, genre, releaseYear, manufacturer, language, resolution, format);
            MediaItems.Add(movie);
            ClearMovieEntries();
        }
        private void ClearMovieEntries()
        {
            movieTitleEntry.Text = "";
            movieGenreEntry.Text = "";
            movieReleaseYearEntry.Text = "";
            movieManufacturerEntry.Text = "";
            movieLanguageEntry.Text = "";
            movieResolutionEntry.Text = "";
            movieFormatEntry.Text = "";
        }
    }
}
