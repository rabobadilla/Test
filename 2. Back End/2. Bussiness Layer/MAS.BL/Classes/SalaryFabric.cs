/// <summary>
/// File for the class Salary Fabric
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.BL.Classes
{
    using MAS.CI.Interfaces;
    using MAS.CI.Enumerations;
    using MAS.UTILITIES.Utilities;

    /// <summary>
    /// Class for Salary Fabric
    /// </summary>
    public class SalaryFabric
    {
        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Calculate the Annual Salary
        /// </summary>
        /// <param name="employeeDTO">Employee entity</param>
        /// <returns>The annual salary calculated</returns>
        public static decimal CalculatedAnnualSalary(IEmployeeDTO employeeDTO)
        {
            SalaryBase  salaryBase = null;
            decimal annualSalary = 0;

            TypesContracts typesContracts = BasicExtensions.ToEnum<TypesContracts>(employeeDTO.contractTypeName);            

            switch (typesContracts)
            {
                case TypesContracts.HourlySalaryEmployee:
                    salaryBase = new  HourlySalary();
                    break;
                case TypesContracts.MonthlySalaryEmployee:
                    salaryBase = new MonthlySalary();
                    break;
            }

            annualSalary = salaryBase.CalculatedAnnualSalary(employeeDTO);

            return annualSalary;
        }

        #endregion

    }
}
