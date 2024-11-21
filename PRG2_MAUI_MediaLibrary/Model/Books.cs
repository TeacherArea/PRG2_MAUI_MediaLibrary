namespace PRG2_MAUI_MediaLibrary
{
    public class Books : Media
    {
        private string author;
        private int pages;
        public override string DisplayText => GetMedia();

        public Books(string title, string genre, int releaseYear, string author, int pages) : base(title, genre, releaseYear)
        {
            this.author = author;
            this.pages = pages;
        }

        public override string GetMedia()
        {
            return $"Titel: {Title}, Genre: {Genre}, Utgivningsår: {ReleaseYear}, Författare: {author}, Sidor: {pages}";
        }
    }
}