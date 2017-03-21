using Empl.Models.Interfaces;

namespace Empl.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext context;

        private IGenericRepository<Employee> employeeRepository;

        public UnitOfWork(EmployeeContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new EmployeeContext();
        }

        public IGenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new GenericRepository<Employee>(context);
                }

                return employeeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}