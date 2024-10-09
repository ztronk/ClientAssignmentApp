using System.Text.Json;

namespace ClientAssignmentApp.Infrastructure.GeolocationService
{
    /// <inheritdoc/>
    public class GeolocationService : IGeolocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeolocationService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        /// <inheritdoc/>
        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            var requestUrl = $"https://geocode-maps.yandex.ru/1.x/?apikey={_apiKey}&format=json&geocode={Uri.EscapeDataString(address)}";
            
            var response = await _httpClient.GetStringAsync(requestUrl);

            var jsonDoc = JsonDocument.Parse(response);

            var coordinates = jsonDoc.RootElement
                .GetProperty("response")
                .GetProperty("GeoObjectCollection")
                .GetProperty("featureMember")[0]
                .GetProperty("GeoObject")
                .GetProperty("Point")
                .GetProperty("pos")
                .GetString()
                .Split(' ');

            double longitude = double.Parse(coordinates[0]);
            double latitude = double.Parse(coordinates[1]);

            return (latitude, longitude);
        }
    }
}
