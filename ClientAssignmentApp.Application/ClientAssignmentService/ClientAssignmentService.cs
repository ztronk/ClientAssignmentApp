using ClientAssignmentApp.Application.GeolocationService;
using ClientAssignmentApp.Domain.Entities;
using ClientAssignmentApp.Infrastructure.GeolocationService;

namespace ClientAssignmentApp.Application.Services
{
    /// <inheritdoc/>
    public class ClientAssignmentService : IClientAssignmentService
    {
        private readonly IGeolocationService _geolocationService;
        private readonly IList<Branch> _branches;
        private readonly IList<Employee> _employees;

        public ClientAssignmentService(IGeolocationService geolocationService, IList<Branch> branches, IList<Employee> employees)
        {
            _geolocationService = geolocationService;
            _branches = branches;
            _employees = employees;
        }

        /// <inheritdoc/>
        public async Task AssignClientsAsync(IList<Client> clients)
        {
            foreach (var client in clients)
            {
                // Проверка для VIP-клиентов
                if (TryGetVipEmployee(client, out var vipEmployee))
                {
                    AssignClientToEmployee(client, vipEmployee!);
                    continue;
                }

                // Проверка для клиентов не из Казахстана или без адреса
                if (TryGetDepartmentEmployee(client, out var departmentEmployee))
                {
                    AssignClientToEmployee(client, departmentEmployee!);
                    continue;
                }

                // Логика для обычных клиентов
                var (latitude, longitude) =
                    await _geolocationService.GetCoordinatesAsync(client.Address);

                var nearestBranch = FindNearestBranch(latitude, longitude);

                // Проверяем, была ли найдена ближайшая филиал. Если нет, переходим к следующему клиенту.
                if (nearestBranch == null) continue;

                // Находим ближайшего сотрудника к найденному филиалу.
                var nearestEmployee = FindNearestEmployee(nearestBranch);

                // Проверяем, был ли найден ближайший сотрудник. Если нет, переходим к следующему клиенту.
                if (nearestEmployee == null) continue;

                // Назначаем клиента найденному сотруднику.
                AssignClientToEmployee(client, nearestEmployee);
            }
        }

        /// <summary>
        /// Попытка получить VIP-сотрудника для указанного клиента.
        /// </summary>
        /// <param name="client">Клиент, для которого необходимо найти VIP-сотрудника.</param>
        /// <param name="vipEmployee">Выходной параметр, который будет содержать VIP-сотрудника, если он найден.</param>
        /// <returns>Возвращает true, если VIP-сотрудник найден, иначе false.</returns>
        private bool TryGetVipEmployee(Client client, out Employee? vipEmployee)
        {
            vipEmployee = null;

            if (client.Attributes != null && client.Attributes.Any(e => e == "VIP"))
            {
                vipEmployee = _employees.FirstOrDefault(e => e.Skill.Contains("VIP"));

                return vipEmployee != null;
            }

            return false;
        }

        /// <summary>
        /// Попытка получить сотрудника из отдела для указанного клиента.
        /// </summary>
        /// <param name="client">Клиент, для которого необходимо найти сотрудника из отдела.</param>
        /// <param name="departmentEmployee">Выходной параметр, который будет содержать сотрудника из отдела, если он найден.</param>
        /// <returns>Возвращает true, если сотрудник из отдела найден, иначе false.</returns>
        private bool TryGetDepartmentEmployee(Client client, out Employee? departmentEmployee)
        {
            departmentEmployee = null;

            if ((client.Attributes != null && !client.Attributes.Any(e => e == "Казахстан"))
                || string.IsNullOrEmpty(client.Address))
            {
                departmentEmployee = _employees
                    .Where(e => e.Department == "Отдел 1" || e.Department == "Отдел 2")
                    .OrderBy(e => e.Workload)
                    .FirstOrDefault();

                return departmentEmployee != null;
            }

            return false;
        }

        /// <summary>
        /// Поиск ближайшего филиала по заданным координатам.
        /// </summary>
        /// <param name="latitude">Широта текущего местоположения.</param>
        /// <param name="longitude">Долгота текущего местоположения.</param>
        /// <returns>Возвращает ближайший филиал или null, если филиал не найден.</returns>
        private Branch? FindNearestBranch(double latitude, double longitude)
        {
            return _branches
                .OrderBy(b => GetDistance(b.Latitude, b.Longitude, latitude, longitude))
                .FirstOrDefault();
        }

        /// <summary>
        /// Поиск ближайшего сотрудника к указанному филиалу.
        /// </summary>
        /// <param name="nearestBranch">Ближайший филиал.</param>
        /// <returns>Возвращает ближайшего сотрудника из соответствующего отдела или null, если сотрудник не найден.</returns>
        private Employee? FindNearestEmployee(Branch nearestBranch)
        {
            return _employees
                .Where(e => e.Department.ToString() == nearestBranch.Department)
                .OrderBy(e => e.Workload)
                .FirstOrDefault();
        }

        /// <summary>
        /// Вычисление расстояния между двумя точками на Земле по их координатам.
        /// </summary>
        /// <param name="lat1">Широта первой точки.</param>
        /// <param name="lon1">Долгота первой точки.</param>
        /// <param name="lat2">Широта второй точки.</param>
        /// <param name="lon2">Долгота второй точки.</param>
        /// <returns>Расстояние между двумя точками в метрах.</returns>
        private static double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // В т. ч. можно использовать формулу Хаверсина, которая учитывает кривизну Земли.
            return Math.Sqrt(Math.Pow(lat1 - lat2, 2) + Math.Pow(lon1 - lon2, 2));
        }

        /// <summary>
        /// Назначение клиента конкретному сотруднику и увеличение его нагрузки.
        /// </summary>
        /// <param name="client">Клиент, которого необходимо назначить.</param>
        /// <param name="employee">Сотрудник, которому назначается клиент.</param>
        private void AssignClientToEmployee(Client client, Employee employee)
        {
            employee.Workload++;
            Console.WriteLine($"Клиент {client.Id} назначен на сотрудника {employee.Id}. Текущая нагрузка: {employee.Workload}");
        }
    }
}
