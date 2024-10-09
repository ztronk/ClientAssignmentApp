using ClientAssignmentApp.Domain.Entities;

namespace ClientAssignmentApp.Infrastructure.CsvRepository
{
    /// <summary>
    /// Репозиторий для работы с данными клиентов, загружаемыми из CSV-файла.
    /// </summary>
    public class ClientCsvRepository : CsvRepository<Client>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ClientCsvRepository"/>.
        /// </summary>
        /// <param name="filePath">Путь к CSV-файлу, содержащему данные клиентов.</param>
        public ClientCsvRepository(string filePath) : base(filePath)
        {
        }
    }
}
