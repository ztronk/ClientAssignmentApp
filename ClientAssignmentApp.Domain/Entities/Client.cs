namespace ClientAssignmentApp.Domain.Entities
{
    /// <summary>
    /// Клиент с его характеристиками.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Страна проживания клиента.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Адрес клиента.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Атрибуты клиента, которые могут содержать дополнительную информацию (например, "VIP").
        /// </summary>
        public string[] Attributes { get; set; }
    }
}
