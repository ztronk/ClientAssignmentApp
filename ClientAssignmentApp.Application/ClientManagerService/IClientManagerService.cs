using ClientAssignmentApp.Domain.Entities;

namespace ClientAssignmentApp.Domain.ClientManagerService
{
    /// <summary>
    /// Интерфейс для сервиса управления клиентами.
    /// </summary>
    public interface IClientManagerService
    {
        /// <summary>
        /// Генерирует JSON-отчет о распределении клиентов среди сотрудников.
        /// </summary>
        /// <param name="clients">Список клиентов для генерации отчета.</param>
        /// <param name="employees">Список сотрудников, участвующих в распределении клиентов.</param>
        void GenerateClientDistributionJson(IList<Client> clients, IList<Employee> employees);
    }
}
