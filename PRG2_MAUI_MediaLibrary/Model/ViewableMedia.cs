namespace PRG2_MAUI_MediaLibrary
{
    public abstract class ViewableMedia : Media
    {
        protected string manufacturer;
        protected string language;

        public ViewableMedia(string title, string genre, int releaseYear, string manufacturer, string language) : base(title, genre, releaseYear)
        {
            this.manufacturer = manufacturer;
            this.language = language;
        }
    }
}