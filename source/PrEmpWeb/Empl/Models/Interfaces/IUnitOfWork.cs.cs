namespace Empl.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Employee> EmployeeRepository { get; }

        void Save();
    }
}