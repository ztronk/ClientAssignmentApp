using ClientAssignmentApp.Domain.Entities;

namespace ClientAssignmentApp.Application.GeolocationService
{
    /// <summary>
    /// Интерфейс для сервиса назначения клиентов.
    /// </summary>
    public interface IClientAssignmentService
    {
        /// <summary>
        /// Позиционирует список клиентов на соответствующих сотрудников.
        /// </summary>
        /// <param name="clients">Список клиентов, которые необходимо назначить.</param>
        /// <returns>Асинхронная задача, представляющая процесс назначения клиентов.</returns>
        Task AssignClientsAsync(IList<Client> clients);
    }
}
