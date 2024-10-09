namespace ClientAssignmentApp.Domain.Entities
{
    /// <summary>
    /// Филиал с его характеристиками.
    /// </summary>
    public class Branch
    {
        /// <summary>
        /// Название отдела, к которому принадлежит филиал.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Широта местоположения филиала.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота местоположения филиала.
        /// </summary>
        public double Longitude { get; set; }
    }
}
