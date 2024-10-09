namespace ClientAssignmentApp.Domain.Entities
{
    /// <summary>
    /// Сотрудник с его характеристиками.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название отдела, в котором работает сотрудник.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Текущая нагрузка сотрудника, представляющая количество назначенных клиентов.
        /// </summary>
        public int Workload { get; set; }

        /// <summary>
        /// Массив навыков сотрудника.
        /// </summary>
        public string[] Skill { get; set; }
    }
}
