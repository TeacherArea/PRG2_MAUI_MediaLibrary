namespace PRG2_MAUI_MediaLibrary
{
    public abstract class Media
    {
        protected string title;
        protected string genre;
        protected int releaseYear;
        public virtual string DisplayText => GetMedia();

        public Media(string title, string genre, int releaseYear)
        {
            this.title = title;
            this.genre = genre;
            this.releaseYear = releaseYear;
        }

        public string Title => title;
        public string Genre => genre;
        public int ReleaseYear => releaseYear;
        public abstract string GetMedia();
    }
}