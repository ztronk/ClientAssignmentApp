using ClientAssignmentApp.Infrastructure.CsvRepository;

namespace ClientAssignmentApp.Infrastructure.RepositoryFactory
{
    /// <summary>
    /// Интерфейс для фабрики репозиториев.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Создает экземпляр репозитория для указанного типа сущности.
        /// </summary>
        /// <typeparam name="T">Тип сущности, для которой создается репозиторий.</typeparam>
        /// <returns>Экземпляр репозитория для указанного типа.</returns>
        CsvRepository<T> CreateRepository<T>() where T : class;
    }
}
