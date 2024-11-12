namespace PRG2_MAUI_MediaLibrary
{
    public class Movies : Views
    {
        private string platforms;
        private string format;
        public override string DisplayText => GetMedia();

        public Movies(string title, string genre, int releaseYear, string manufacturer, string language, string resolution, string format) : base(title, genre, releaseYear, manufacturer, language)
        {
            this.platforms = platforms;
            this.format = format;
        }

        protected override string GetMedia()
        {
            return $"{base.GetMedia()}, platform: {platforms}";
        }
    }
}
