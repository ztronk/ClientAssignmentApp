using ClientAssignmentApp.Domain.Entities;

namespace ClientAssignmentApp.Infrastructure.CsvRepository
{
    /// <summary>
    /// Репозиторий для работы с данными филиалов, загружаемыми из CSV-файла.
    /// </summary>
    public class BranchCsvRepository : CsvRepository<Branch>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BranchCsvRepository"/>.
        /// </summary>
        /// <param name="filePath">Путь к CSV-файлу, содержащему данные филиалов.</param>
        public BranchCsvRepository(string filePath) : base(filePath)
        {
        }
    }
}
