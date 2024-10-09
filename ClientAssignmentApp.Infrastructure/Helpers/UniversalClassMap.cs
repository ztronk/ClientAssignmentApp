using CsvHelper.Configuration;
using System.Globalization;

namespace ClientAssignmentApp.Infrastructure.Helpers
{
    /// <summary>
    /// Универсальная карта сопоставления для классов с поддержкой конвертации строковых списков.
    /// </summary>
    /// <typeparam name="T">Тип сущности, для которой создается карта.</typeparam>
    internal class UniversalClassMap<T> : ClassMap<T> where T : class
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UniversalClassMap{T}"/>.
        /// </summary>
        internal UniversalClassMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

            // Проходим по всем свойствам типа T и применяем конвертер к строковым спискам
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (typeof(IEnumerable<string>).IsAssignableFrom(property.PropertyType))
                {
                    Map(typeof(T), property).TypeConverter<SquareBracketArrayConverter>();
                }
            }
        }
    }
}
