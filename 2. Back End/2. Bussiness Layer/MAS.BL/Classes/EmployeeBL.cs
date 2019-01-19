/// <summary>
/// File for access to employee's bussiness layer
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.BL.Classes
{
    using MAS.CI.Interfaces;
    using MAS.DAL.Classes;
    using MAS.UTILITIES.Utilities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for access to employee's bussiness layer
    /// </summary>
    public class EmployeeBL
    {
        #region "DECLARATIONS"

        /// <summary>
        /// Object for access data layer
        /// </summary>
        private Lazy<EmployeeDAL> employeeDAL;

        #endregion

        #region "CONSTRUCTORS"

        /// <summary>
        /// Class contrsuctor
        /// </summary>
        public EmployeeBL()
        {
            employeeDAL = new Lazy<EmployeeDAL>();
        }

        #endregion

        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <param name="employeeDTO">Employe entity</param>
        /// <returns>A list of employees</returns>
        public List<IEmployeeDTO> GetEmployees(IEmployeeDTO employeeDTO)
        {
            return Wrapper.ExecuteWrapper<List<IEmployeeDTO>, EmployeeBL>(() =>
            {
                List<IEmployeeDTO> employees = employeeDAL.Value.GetEmployees(employeeDTO);

                employees.ForEach(p => p.calculatedAnnualSalary = SalaryFabric.CalculatedAnnualSalary(p));

                return employees;

            });
        }

        #endregion
    }
}
