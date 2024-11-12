namespace PRG2_MAUI_MediaLibrary
{
    public abstract class Views : Media
    {
        private string manufacturer;
        private string language;

        public Views(string title, string genre, int releaseYear, string manufacturer, string language) : base(title, genre, releaseYear)
        {
            this.manufacturer = manufacturer;
            this.language = language;
        }

        protected override string GetMedia()
        {
            return $"{base.GetMedia()}, studio: {manufacturer}, språk: {language}";
        }
    }
}
