using Empl.Models;
using Empl.Models.Interfaces;
using Empl.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Models
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void Give_Employee_Repository_Test()
        {
            var uow = new UnitOfWork();
            var result = uow.EmployeeRepository;

            Assert.IsInstanceOfType(result, typeof(IGenericRepository<Employee>));
        }
    }
}
