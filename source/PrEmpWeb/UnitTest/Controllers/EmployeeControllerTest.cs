using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Empl.App_Start;
using Empl.BL.Interfaces;
using Empl.Controllers;
using Empl.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeService> _mockEmployeeService;

        private EmployeeViewModel employee;
        private List<EmployeeViewModel> employees;
        private IndexViewModel indexViewModel;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_mockEmployeeService.Object);

            AutoMapperViewModelConfig.Configure();

            employee = new EmployeeViewModel { EmployeeId = 0, Name = "employee-name", Position = "employees-position" };

            employees = new List<EmployeeViewModel>
            {
                employee
            };

            indexViewModel = new IndexViewModel
            {
                Employees = employees,
            };
        }

        [TestMethod]
        public void Check_Index_Get_Action_Return_Model()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.GetFilteredEmployees(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(() => indexViewModel);

            //Act
            var result = _employeeController.Index();
            var model = ((ViewResult)result).Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Check_Details_Action_Return_Valid_Model()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.GetEmployee(It.IsAny<int>())).Returns(() => employee);

            //Act
            var result = _employeeController.Details(It.IsAny<int>());
            var model = ((ViewResult)result).Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(EmployeeViewModel));
        }

        [TestMethod]
        public void Check_New_Get_Action_Return_ViewResult()
        {
            //Act
            var result = _employeeController.New();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Check_New_Post_Action_Valid_Model()
        {
            //Act
            var result = _employeeController.New(employee);
            var redirect = ((RedirectToRouteResult)result);

            //Assert
            Assert.IsInstanceOfType(redirect, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void Check_New_Post_Action_Not_Valid_Model()
        {
            //Arrange 
            _employeeController.ModelState.AddModelError(string.Empty, new Exception());

            //Act
            var result = _employeeController.New(employee);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Check_Update_Get_Action_Return_Valid_Model()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.GetEmployee(It.IsAny<int>())).Returns(() => employee);

            //Act
            var result = _employeeController.Update(It.IsAny<int>());
            var model = ((ViewResult)result).Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(EmployeeViewModel));
        }

        [TestMethod]
        public void CheckUpdatePostActionValidModel()
        {
            //Act
            var result = _employeeController.Update(employee);
            var redirect = ((RedirectToRouteResult)result);

            //Assert
            Assert.IsInstanceOfType(redirect, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void CheckUpdatePostActionNotValidModel()
        {
            //Arrange 
            _employeeController.ModelState.AddModelError(string.Empty, new Exception());

            //Act
            var result = _employeeController.Update(employee);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Check_Delete_Action_Return_RedirectToAction()
        {
            //Act
            var result = _employeeController.Delete(It.IsAny<int>());

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void Check_Generate_Action_Return_File()
        {
            //Act
            var result = _employeeController.Generate();

            //Assert
            Assert.IsInstanceOfType(result, typeof(FileResult));
        }
    }
}
