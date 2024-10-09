using ClientAssignmentApp.Domain.Entities;

namespace ClientAssignmentApp.Infrastructure.CsvRepository
{
    /// <summary>
    /// Репозиторий для работы с данными сотрудников, загружаемыми из CSV-файла.
    /// </summary>
    public class EmployeeCsvRepository : CsvRepository<Employee>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="EmployeeCsvRepository"/>.
        /// </summary>
        /// <param name="filePath">Путь к CSV-файлу, содержащему данные сотрудников.</param>
        public EmployeeCsvRepository(string filePath) : base(filePath)
        {
        }
    }
}
