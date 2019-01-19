/// <summary>
/// File for the test
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.TEST.Clases
{
    using MAS.BL.Classes;
    using MAS.CI.Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    /// <summary>
    /// Main class for the tests
    /// </summary>
    [TestClass]
    public class UnitTestEmployee
    {
        /// <summary>
        /// Get the type of contract
        /// </summary>
        [TestMethod]
        public void GetContractTypeName()
        {
            EmployeeTest employeeTest = new EmployeeTest();
            EmployeeBL employeeBL = new EmployeeBL();
            string typeContractExpected = TypesContracts.HourlySalaryEmployee.ToString();

            employeeTest.id = 1;

            string typeContract = employeeBL.GetEmployees(employeeTest).First().contractTypeName;

            Assert.AreEqual(typeContractExpected, typeContract);
        }
    }
}
