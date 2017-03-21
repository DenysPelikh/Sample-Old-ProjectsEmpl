using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Empl.App_Start;
using Empl.BL.Interfaces;
using Empl.BL.Services;
using Empl.Models;
using Empl.Models.Interfaces;
using Empl.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Services
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private IEmployeeService _employeeService;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        private Employee employee;
        private EmployeeViewModel employeeModel;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _employeeService = new EmployeeService(_mockUnitOfWork.Object);

            AutoMapperViewModelConfig.Configure();

            employee = new Employee { EmployeeId = 0, Name = "employee-name", Position = "employees-position" };

            employeeModel = Mapper.Map<EmployeeViewModel>(employee);
        }

        [TestMethod]
        public void Get_Employee_Maps_Data_Appropriately()
        {
            //Arrange
            _mockUnitOfWork.Setup(m => m.EmployeeRepository.GetById(It.IsAny<int>())).Returns(() => employee);

            //Act
            var result = _employeeService.GetEmployee(It.IsAny<int>());

            //Assert
            Assert.AreEqual(employee.Name, result.Name);
            Assert.AreEqual(employee.Position, result.Position);
        }

        [TestMethod]
        public void Get_Employees_Maps_Data_Appropriately()
        {
            //Arrange
            _mockUnitOfWork.Setup(m => m.EmployeeRepository.Get()).Returns(new[] { employee });

            //Act
            var result = _employeeService.GetEmployees();

            //Assert
            Assert.AreEqual(employee.Name, result.ElementAt(0).Name);
            Assert.AreEqual(employee.Position, result.ElementAt(0).Position);
        }

        [TestMethod]
        public void Get_Filtered_Employees_Maps_Data_Appropriately()
        {
            //Arrange
            _mockUnitOfWork.Setup(m => m.EmployeeRepository.GetMany(It.IsAny<Func<Employee, bool>>())).Returns(new[] { employee });

            //Act
            var result = _employeeService.GetFilteredEmployees("All", 5, 1);

            //Assert
            Assert.AreEqual(employee.Name, result.Employees.ElementAt(0).Name);
            Assert.AreEqual(employee.Position, result.Employees.ElementAt(0).Position);
            Assert.AreEqual(1, result.FilteredRowsTotal);
        }

        [TestMethod]
        public void Create_Employee_Maps_Data_Appropriately()
        {
            Employee employeeTest = null;
            _mockUnitOfWork
                .Setup(m => m.EmployeeRepository.Add(It.IsAny<Employee>()))
                .Callback<Employee>(item => { employeeTest = item; });

            //Act
            _employeeService.CreateEmployee(employeeModel);

            //Assert
            Assert.AreEqual(employeeModel.Name, employeeTest.Name);
            Assert.AreEqual(employeeModel.Position, employeeTest.Position);
        }

        [TestMethod]
        public void Create_Employee_Calls_Save_Method()
        {
            //Arrange
            _mockUnitOfWork.Setup(m => m.EmployeeRepository.Add(It.IsAny<Employee>()));

            //Act
            _employeeService.CreateEmployee(employeeModel);

            //Assert
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once);
        }

        [TestMethod]
        public void Delete_Employee_Calls_Save_Method()
        {
            //Arrange
            _mockUnitOfWork.Setup(m => m.EmployeeRepository.GetById(It.IsAny<int>())).Returns(employee);

            //Act
            _employeeService.DeleteEmployee(It.IsAny<int>());

            //Assert
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once);
        }

        [TestMethod]
        public void Edit_Employee_Maps_Data_Appropriately()
        {
            Employee employeeTest = null;
            _mockUnitOfWork
                .Setup(m => m.EmployeeRepository.Update(It.IsAny<Employee>()))
                .Callback<Employee>(item => { employeeTest = item; });

            //Act
            _employeeService.EditEmployee(employeeModel);

            //Assert
            Assert.AreEqual(employeeModel.Name, employeeTest.Name);
            Assert.AreEqual(employeeModel.Position, employeeTest.Position);
        }

        [TestMethod]
        public void Edit_Employee_Calls_Save_Method()
        {
            //Arrange
            _mockUnitOfWork.Setup(m => m.EmployeeRepository.Update(It.IsAny<Employee>()));

            //Act
            _employeeService.EditEmployee(employeeModel);

            //Assert
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once);
        }
    }
}
