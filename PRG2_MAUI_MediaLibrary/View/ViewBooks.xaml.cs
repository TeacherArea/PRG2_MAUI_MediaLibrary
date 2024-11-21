using PRG2_MAUI_MediaLibrary.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PRG2_MAUI_MediaLibrary.View
{
    public partial class ViewBooks : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Media> MediaItems => MediaService.Instance.MediaItems;

        private IEnumerable<Books> _booksOnly;
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
            BooksOnly = MediaItems.OfType<Books>().ToList();
        }

        private void OnMediaItemsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            BooksOnly = MediaItems.OfType<Books>().ToList();
        }

        private void OnSaveBookClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(bookReleaseYearEntry.Text, out var releaseYear))
            {
                DisplayAlert("Fel", "Publiceringsår måste vara ett nummer.", "OK");
                return;
            }

            if (!int.TryParse(bookPagesEntry.Text, out var pages))
            {
                DisplayAlert("Fel", "Antal sidor måste vara ett nummer.", "OK");
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
