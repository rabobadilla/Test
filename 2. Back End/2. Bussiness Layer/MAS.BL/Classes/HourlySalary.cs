/// <summary>
/// File for the class Hourly Salary
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.BL.Classes
{
    using MAS.CI.Interfaces;

    /// <summary>
    /// Class for Hourly Salary
    /// </summary>
    public class HourlySalary : SalaryBase
    {
        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Calculate the Annual Salary
        /// </summary>
        /// <param name="employeeDTO">Employee entity</param>
        /// <returns>The annual salary calculated</returns>
        public override decimal CalculatedAnnualSalary(IEmployeeDTO employeeDTO)
        {
            decimal annualSalary = 0;

            annualSalary = 120 * employeeDTO.hourlySalary * 12;

            return annualSalary;
        }

        #endregion
    }
}
