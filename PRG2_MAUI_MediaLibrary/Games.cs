namespace PRG2_MAUI_MediaLibrary
{
    public class Games : Views
    {
        private string platforms;
        public override string DisplayText => GetMedia();

        public Games(string title, string genre, int releaseYear, string manufacturer, string language, string platforms) : base(title, genre, releaseYear, manufacturer, language)
        {
            this.platforms = platforms;
        }

        protected override string GetMedia()
        {
            return $"{base.GetMedia()}, platformer: {platforms}";
        }
    }
}
