using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Linq;

namespace ClientAssignmentApp.Infrastructure.Helpers
{
    /// <summary>
    /// Конвертер для преобразования строк с массивами, заключенными в квадратные скобки.
    /// </summary>
    internal class SquareBracketArrayConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Преобразует строку в массив значений.
        /// </summary>
        /// <param name="text">Строка для преобразования.</param>
        /// <param name="row">Текущая строка CSV.</param>
        /// <param name="memberMapData">Метаданные о сопоставлении.</param>
        /// <returns>Массив строк, полученный из входной строки.</returns>
        public override object? ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;

            if (text.StartsWith("[") && text.EndsWith("]"))
            {
                // Убираем квадратные скобки и разделяем строку по запятой
                var values = text.Trim('[', ']').Split(',')
                    .Select(x => x.Trim()).ToArray();

                return values;
            }

            // Если текст не в квадратных скобках, возвращаем его как одиночный элемент списка
            return new[] { text.Trim() };
        }
    }
}
