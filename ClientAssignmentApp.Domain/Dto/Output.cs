namespace ClientAssignmentApp.Domain.Dto
{
    /// <summary>
    /// Класс для представления информации о распределении клиентов между менеджерами.
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Идентификатор менеджера, ответственное за клиента.
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Текущая нагрузка менеджера.
        /// </summary>
        public int ManagerWorkload { get; set; }
    }
}
