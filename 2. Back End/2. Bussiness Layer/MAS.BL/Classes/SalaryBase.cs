/// <summary>
/// File for the Salary Base class
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.BL.Classes
{
    using MAS.CI.Interfaces;

    /// <summary>
    /// Class for Salary Base
    /// </summary>
    public abstract class SalaryBase
    {
        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Calculate the Annual Salary
        /// </summary>
        /// <param name="employeeDTO">Employee entity</param>
        /// <returns>The annual salary calculated</returns>
        public virtual decimal CalculatedAnnualSalary(IEmployeeDTO employeeDTO)
        {
            return 0;
        }

        #endregion

    }
}
