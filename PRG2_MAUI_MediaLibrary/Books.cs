namespace PRG2_MAUI_MediaLibrary
{
    internal class Books : Media
    {
        private string author;
        private int pages;
        public override string DisplayText => GetBook();

        public Books(string title, string genre, int releaseYear, string author, int pages) : base(title, genre, releaseYear)
        {
            this.author = author;
            this.pages = pages;
        }

        protected string GetBook()
        {
            return $"{GetMedia()}, författare: {author}, sidor: {pages}";
        }
    }
}
