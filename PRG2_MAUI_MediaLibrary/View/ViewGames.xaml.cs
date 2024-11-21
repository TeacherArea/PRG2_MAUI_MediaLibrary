using System.Collections.ObjectModel;

namespace PRG2_MAUI_MediaLibrary.View
{
    public partial class ViewGames : ContentPage
    {
        public ObservableCollection<Media> MediaItems { get; set; }

        public ViewGames()
        {
            InitializeComponent();
            MediaItems = new ObservableCollection<Media>();
            BindingContext = this;
        }

        private void OnSaveGameClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(gameReleaseYearEntry.Text, out int releaseYear))
            {
                DisplayAlert("Fel", "Skriv in att korrekt årtal, i formatet fyra heltal.", "OK");
                return;
            }
            var title = gameTitleEntry.Text;
            var genre = gameGenreEntry.Text;
            var manufacturer = gameManufacturerEntry.Text;
            var language = gameLanguageEntry.Text;
            var platforms = gamePlatformsEntry.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre) || string.IsNullOrWhiteSpace(manufacturer) || string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(platforms))
            {
                DisplayAlert("Fel", "Alla fält måste fyllas i.", "OK");
                return;
            }

            var game = new Games(title, genre, releaseYear, manufacturer, language, platforms);
            MediaItems.Add(game);
            ClearGameEntries();
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
    }
}
