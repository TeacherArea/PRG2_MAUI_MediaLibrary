namespace PRG2_MAUI_MediaLibrary
{
    public class Movies : Views
    {
        private string resolution;
        private string format;
        public override string DisplayText => GetMedia();

        public Movies(string title, string genre, int releaseYear, string manufacturer, string language, string resolution, string format) : base(title, genre, releaseYear, manufacturer, language)
        {
            this.resolution = resolution;
            this.format = format;
        }

        public override string GetMedia()
        {
            return $"Titel: {title}. Genre: {genre}. Utgivningsår: {releaseYear}. Tillverkare: {manufacturer}. Språk: {language}. Upplösning: {resolution}. Format: {format}";
        }
    }
}
