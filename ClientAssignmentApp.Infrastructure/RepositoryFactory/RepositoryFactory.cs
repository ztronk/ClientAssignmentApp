using ClientAssignmentApp.Domain.Entities;
using ClientAssignmentApp.Infrastructure.CsvRepository;
using ClientAssignmentApp.Infrastructure.Helpers;

namespace ClientAssignmentApp.Infrastructure.RepositoryFactory
{
    /// <inheritdoc/>
    public class RepositoryFactory : IRepositoryFactory
    {
        public CsvRepository<T> CreateRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Client))
                return new ClientCsvRepository(RepositoryFactoryPath.Client) as CsvRepository<T>;
            if (typeof(T) == typeof(Employee))
                return new EmployeeCsvRepository(RepositoryFactoryPath.Employees) as CsvRepository<T>;
            if (typeof(T) == typeof(Branch))
                return new BranchCsvRepository(RepositoryFactoryPath.Branches) as CsvRepository<T>;

            throw new ArgumentException("Неизвестный тип репозитория");
        }

        /// <inheritdoc/>
        public CsvRepository<Client> CreateClientRepository(string filePath)
        {
            return new ClientCsvRepository(filePath);
        }

        /// <inheritdoc/>
        public CsvRepository<Employee> CreateEmployeeRepository(string filePath)
        {
            return new EmployeeCsvRepository(filePath);
        }

        /// <inheritdoc/>
        public CsvRepository<Branch> CreateBranchRepository(string filePath)
        {
            return new BranchCsvRepository(filePath);
        }
    }
}
