/// <summary>
/// File for access to employee's data
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.DAL.Classes
{
    using MAS.CI.Interfaces;
    using MAS.UTILITIES.Utilities;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>
    /// Class for access to employee's data
    /// </summary>
    public class EmployeeDAL
    {
        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <param name="employeeDTO">Employee Entity</param>
        /// <returns>A list of employees</returns>
        public List<IEmployeeDTO> GetEmployees(IEmployeeDTO employeeDTO)
        {
            return Wrapper.ExecuteWrapper<List<IEmployeeDTO>, EmployeeDAL>(() =>
            {
                List<Employee> employees = new List<Employee>();
                string url = "http://masglobaltestapi.azurewebsites.net/api/Employees";

                WebClient client = new WebClient();
                string content = client.DownloadString(url);

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Employee>));

                using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
                {
                    employees = (List<Employee>)serializer.ReadObject(ms);
                }

                employees = employees.Concat(EmployeeMockData()).ToList();

                employees = employees.Where(p => employeeDTO.id == 0 ? true : p.id == employeeDTO.id).ToList();

                return employees.ToList<IEmployeeDTO>();
            });
        }

        #endregion

        #region "PRIVATE FUNCTIONS"

        /// <summary>
        /// Get a list of employees mock values
        /// </summary>
        /// <returns>A list of employees</returns>
        private List<Employee> EmployeeMockData()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee()
            {
                id = 3,
                name = "Luis",
                contractTypeName = "HourlySalaryEmployee",
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "",
                hourlySalary = 58200,
                monthlySalary = 96012,
                calculatedAnnualSalary = 0
            });

            employees.Add(new Employee()
            {
                id = 4,
                name = "Pedro",
                contractTypeName = "MonthlySalaryEmployee",
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "",
                hourlySalary = 45000,
                monthlySalary = 87000,
                calculatedAnnualSalary = 0
            });

            employees.Add(new Employee()
            {
                id = 5,
                name = "Carla",
                contractTypeName = "MonthlySalaryEmployee",
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "",
                hourlySalary = 34441,
                monthlySalary = 78992,
                calculatedAnnualSalary = 0
            });

            employees.Add(new Employee()
            {
                id = 6,
                name = "Raul",
                contractTypeName = "MonthlySalaryEmployee",
                roleId = 1,
                roleName = "Administrator",
                roleDescription = "",
                hourlySalary = 48520,
                monthlySalary = 86215,
                calculatedAnnualSalary = 0
            });

            return employees;
        }

        #endregion
    }
}
