using System.Collections.ObjectModel;
using PRG2_MAUI_MediaLibrary.Model;

namespace PRG2_MAUI_MediaLibrary.View
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Media> MediaItems => MediaService.Instance.MediaItems;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
