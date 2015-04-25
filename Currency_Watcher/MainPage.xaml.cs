using System.Windows;
using Currency_Watcher.Clients;

namespace Currency_Watcher
{
    public partial class MainPage
    {
        private readonly RateClient _rateClient;

        // Constructor
        public MainPage()
        {
            _rateClient = new RateClient();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Dispatcher нужен, потому что доступ к UI-элементам может иметь только поток, в котором вызвали событие Button_Click. Типа, такая безопасность.
            _rateClient.UsdRub(rate =>
                Dispatcher.BeginInvoke(() =>
                    RateTextBox.Text = rate));
        }
    }
}