using ClientAssignmentApp.Infrastructure.Helpers;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ClientAssignmentApp.Infrastructure.CsvRepository
{
    /// <summary>
    /// Абстрактный класс для работы с CSV-файлами.
    /// </summary>
    /// <typeparam name="T">Тип сущности, которая будет представлять записи из CSV.</typeparam>
    public abstract class CsvRepository<T> where T : class
    {
        private readonly string _filePath;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CsvRepository{T}"/>.
        /// </summary>
        /// <param name="filePath">Путь к CSV-файлу.</param>
        protected CsvRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Получает все записи из CSV-файла.
        /// </summary>
        /// <returns>Список записей типа <typeparamref name="T"/> из CSV-файла.</returns>
        public IList<T> GetAll()
        {
            using var reader = new StreamReader(_filePath);

            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "\t", // Устанавливаем разделитель табуляцию
            });

            csv.Context.RegisterClassMap<UniversalClassMap<T>>();

            return csv.GetRecords<T>().ToList();
        }
    }
}
