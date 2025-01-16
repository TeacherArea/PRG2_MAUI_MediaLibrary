using PRG2_MAUI_MediaLibrary.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PRG2_MAUI_MediaLibrary.View
{
    public partial class ViewBooks : ContentPage, INotifyPropertyChanged
    {
        // MediaService.Instance.MediaItems beh�vs egentligen inte. Det �r en istans till listan f�r att f�rkorta koden,
        // t ex vid MediaItems.Add(book), som annars skulle bli MediaService.Instance.MediaItems.Add(book)
        public ObservableCollection<Media> MediaItems => MediaService.Instance.MediaItems;

        // h�r lagras listan lokalt med enbart b�cker
        private IEnumerable<Books> _booksOnly;

        // privat egenskap. En IEnumerable �r en lista
        public IEnumerable<Books> BooksOnly
        {
            get => _booksOnly;
            set
            {
                _booksOnly = value;
                OnPropertyChanged(nameof(BooksOnly));
            }
        }

        public ViewBooks()
        {
            InitializeComponent();
            MediaItems.CollectionChanged += OnMediaItemsChanged;
            BindingContext = this;
                BooksOnly = MediaItems.OfType<Books>().ToList(); // sj�lva filtrering av b�cker.
                                                                 // OfType<Books>() �r en LINQ-metod. Skulle kunna vara en if-sats om man vill det,
                                                                 // ex
                                                                 // foreach (var item in mediaList)
                                                                 // {
                                                                 //    if (item is Books book)
                                                                 //    {
                                                                 //        Console.WriteLine($"Detta �r en bok: {book.Title}");
                                                                 //    }
                                                                 // }
        }

        private void OnMediaItemsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            BooksOnly = MediaItems.OfType<Books>().ToList();
        }

        private void OnSaveBookClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(bookReleaseYearEntry.Text, out var releaseYear))
            {
                DisplayAlert("Fel", "Publicerings�r m�ste vara ett nummer.", "OK");
                return;
            }

            if (!int.TryParse(bookPagesEntry.Text, out var pages))
            {
                DisplayAlert("Fel", "Antal sidor m�ste vara ett nummer.", "OK");
                return;
            }

            var title = bookTitleEntry.Text;
            var genre = bookGenreEntry.Text;
            var author = bookAuthorEntry.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre) || string.IsNullOrWhiteSpace(author))
            {
                DisplayAlert("Fel", "Alla f lt m ste fyllas i.", "OK");
                return;
            }

            var book = new Books(title, genre, releaseYear, author, pages);
            MediaItems.Add(book);
            ClearBookEntries();
        }


        private void ClearBookEntries()
        {
            bookTitleEntry.Text = "";
            bookGenreEntry.Text = "";
            bookReleaseYearEntry.Text = "";
            bookAuthorEntry.Text = "";
            bookPagesEntry.Text = "";
        }
    }
}
