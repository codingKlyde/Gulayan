using Gulayan.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Gulayan.ViewModels
{
    public class ViewModelDashboard : ViewModelBase
    {
        private readonly DispatcherTimer _timer;

        private string? _quote;
        public string? Quote
        {
            get { return _quote; }
            set
            {
                _quote = value;
                OnPropertyChanged(nameof(Quote));
            }
        }

        public ICommand FetchQuoteCommand { get; }

        public ViewModelDashboard()
        {
             // Initialize and configure the timer
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(15) // Interval to 15 minutes
            };
            _timer.Tick += async (sender, args) => await FetchQuoteAsync();
            _timer.Start();

            // Fetch the initial quote
            FetchQuoteAsync().ConfigureAwait(false);
        }

        private async Task FetchQuoteAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://zenquotes.io/api/random";
                    // Asynchronously get the response from the API
                    var response = await client.GetStringAsync(url);
                    // Deserialize the JSON response into a list of ZenQuote(Model) objects
                    var quotes = JsonConvert.DeserializeObject<List<ZenQuote>>(response);
                    // Update the Quote property with the fetched quote
                    if (quotes != null && quotes.Count > 0)
                        Quote = quotes[0].q + " - " + quotes[0].a;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error fetching quote: {ex.Message}");
            }
        }
    }
}