using System.Windows;
using Currency_Watcher.Clients;
using Currency_Watcher.Parsers;
using Currency_Watcher.Utils;

namespace Currency_Watcher
{
    public partial class MainPage
    {
        private readonly IRateUtils _rateUtils;

        // Constructor
        public MainPage()
        {
            _rateUtils = new RateUtils(new YahooApiClient(), new XchangeJsonParser());
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Dispatcher нужен, потому что доступ к UI-элементам может иметь только поток, в котором вызвали событие Button_Click. Типа, такая безопасность.
            _rateUtils.GetXchangeRate(
                "USDRUB",
                rate => Dispatcher.BeginInvoke(
                    () => RateTextBox.Text = rate));
        }
    }
}