namespace ClientAssignmentApp.Infrastructure.GeolocationService
{
    /// <summary>
    /// Интерфейс для сервиса геолокации.
    /// </summary>
    public interface IGeolocationService
    {
        /// <summary>
        /// Асинхронно получает координаты (широту и долготу) по указанному адресу.
        /// </summary>
        /// <param name="address">Адрес, для которого необходимо получить координаты.</param>
        /// <returns>Асинхронная задача, возвращающая кортеж с широтой и долготой.</returns>
        Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address);
    }
}
