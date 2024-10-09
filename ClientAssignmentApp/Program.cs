using ClientAssignmentApp.Application.Services;
using ClientAssignmentApp.Domain.ClientManagerService;
using ClientAssignmentApp.Domain.Entities;
using ClientAssignmentApp.Infrastructure.GeolocationService;
using ClientAssignmentApp.Infrastructure.Handlers;
using ClientAssignmentApp.Infrastructure.RepositoryFactory;

// Обертка основного выполнения в middleware для обработки ошибок
var errorHandlingMiddleware = new ErrorHandling();

await errorHandlingMiddleware.Invoke(async () =>
{
    var apiKey = "ВАШ_API_КЛЮЧ";

    var geolocationService = new GeolocationService(apiKey);

    // Создание экземпляра фабрики
    var repositoryFactory = new RepositoryFactory();

    // Чтение данных из репозиториев
    var clients = 
        repositoryFactory.CreateRepository<Client>().GetAll();

    var employees = 
        repositoryFactory.CreateRepository<Employee>().GetAll();

    var branches = 
        repositoryFactory.CreateRepository<Branch>().GetAll();

    // Назначение клиентов сотрудникам на основе геолокации и доступных филиалов
    await new ClientAssignmentService(geolocationService, branches, employees)
        .AssignClientsAsync(clients);

    // Генерация JSON-отчета о распределении клиентов среди сотрудников
    new ClientManagerService()
        .GenerateClientDistributionJson(clients, employees);
});