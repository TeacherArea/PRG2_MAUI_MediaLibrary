using System.Collections.ObjectModel;

namespace PRG2_MAUI_MediaLibrary.Model
{
    class MediaService
    {
        private static MediaService _instance;
        public static MediaService Instance => _instance ??= new MediaService();

        public ObservableCollection<Media> MediaItems { get; set; }

        public IEnumerable<string> GetFormattedMedia(Func<Media, string> formatter)
        {
            return MediaItems.Select(formatter);
        }


        private MediaService()
        {
            MediaItems = new ObservableCollection<Media>
            {
            new Books("1984", "Dystopian", 1949, "George Orwell", 328),
            new Books("To Kill a Mockingbird", "Drama", 1960, "Harper Lee", 281),
            new Games("The Witcher 3", "RPG", 2015, "CD Projekt", "English", "PC, PS4, Xbox One"),
            new Movies("Inception", "Sci-Fi", 2010, "Warner Bros", "English", "1080p", "Blu-ray"),
            };
        }
    }
}
