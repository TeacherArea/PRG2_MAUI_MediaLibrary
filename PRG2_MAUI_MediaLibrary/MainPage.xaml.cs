using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace PRG2_MAUI_MediaLibrary
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Media> MediaItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
            MediaItems = new ObservableCollection<Media>();
            BindingContext = this;
            AddDefaultItems();
        }


        private void AddDefaultItems()
        {
            var defaultBook = new Books("1984", "Dystopian", 1949, "George Orwell", 328);
            MediaItems.Add(defaultBook);

            var defaultGame = new Games("The Witcher 3", "RPG", 2015, "CD Projekt", "English", "PC, PS4, Xbox One");
            MediaItems.Add(defaultGame);

            var defaultMovie = new Movies("Inception", "Sci-Fi", 2010, "Warner Bros", "English", "1080p", "Blu-ray");
            MediaItems.Add(defaultMovie);
        }

        private void OnSaveBookClicked(object sender, EventArgs e)
        {
            var title = bookTitleEntry.Text;
            var genre = bookGenreEntry.Text;
            var releaseYear = int.Parse(bookReleaseYearEntry.Text);
            var author = bookAuthorEntry.Text;
            var pages = int.Parse(bookPagesEntry.Text);

            var book = new Books(title, genre, releaseYear, author, pages);
            MediaItems.Add(book);
            ClearBookEntries();
        }

        private void OnSaveGameClicked(object sender, EventArgs e)
        {
            var title = gameTitleEntry.Text;
            var genre = gameGenreEntry.Text;
            var releaseYear = int.Parse(gameReleaseYearEntry.Text);
            var manufacturer = gameManufacturerEntry.Text;
            var language = gameLanguageEntry.Text;
            var platforms = gamePlatformsEntry.Text;

            var game = new Games(title, genre, releaseYear, manufacturer, language, platforms);
            MediaItems.Add(game);
            ClearGameEntries();
        }

        private void OnSaveMovieClicked(object sender, EventArgs e)
        {
            var title = movieTitleEntry.Text;
            var genre = movieGenreEntry.Text;
            var releaseYear = int.Parse(movieReleaseYearEntry.Text);
            var manufacturer = movieManufacturerEntry.Text;
            var language = movieLanguageEntry.Text;
            var resolution = movieResolutionEntry.Text;
            var format = movieFormatEntry.Text;

            var movie = new Movies(title, genre, releaseYear, manufacturer, language, resolution, format);
            MediaItems.Add(movie);
            ClearMovieEntries();
        }

        private void ClearBookEntries()
        {
            bookTitleEntry.Text = "";
            bookGenreEntry.Text = "";
            bookReleaseYearEntry.Text = "";
            bookAuthorEntry.Text = "";
            bookPagesEntry.Text = "";
        }

        private void ClearGameEntries()
        {
            gameTitleEntry.Text = "";
            gameGenreEntry.Text = "";
            gameReleaseYearEntry.Text = "";
            gameManufacturerEntry.Text = "";
            gameLanguageEntry.Text = "";
            gamePlatformsEntry.Text = "";
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
