namespace PRG2_MAUI_MediaLibrary
{
    public abstract class Media
    {
        private string title;
        private string genre;
        private int releaseYear;
        public virtual string DisplayText => GetMedia();

        public Media(string title, string genre, int releaseYear)
        {
            this.title = title;
            this.genre = genre;
            this.releaseYear = releaseYear;
        }

        protected virtual string GetMedia()
        {
            return $"Titel: {title}, genre: {genre}, utgiven år: {releaseYear}";
        }
    }
}
