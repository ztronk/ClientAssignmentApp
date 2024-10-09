using ClientAssignmentApp.Domain.Dto;
using ClientAssignmentApp.Domain.Entities;
using System.Text.Json;

namespace ClientAssignmentApp.Domain.ClientManagerService
{
    /// <inheritdoc/>
    public class ClientManagerService : IClientManagerService
    {
        /// <inheritdoc/>
        public void GenerateClientDistributionJson(IList<Client> clients, IList<Employee> employees)
        {
            var output = new List<Output>();

            foreach (var client in clients ?? Enumerable.Empty<Client>())
            {
                var assignedEmployee = 
                    employees.FirstOrDefault(e => e.Id == client.Id); // Найти назначенного сотрудника для клиента

                if (assignedEmployee == null) continue;

                output.Add(new Output
                {
                    ManagerId = assignedEmployee.Id,
                    ClientId = client.Id,
                    ManagerWorkload = assignedEmployee.Workload,
                });
            }

            var jsonOutput =
                JsonSerializer.Serialize(new { data = output }, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("path/to/output.json", jsonOutput);

            Console.WriteLine("Данные распределения клиентов сохранены в output.json");
        }
    }
}
