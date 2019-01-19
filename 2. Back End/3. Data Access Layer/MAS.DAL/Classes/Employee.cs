/// <summary>
/// File for the class employee
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.DAL.Classes
{
    using MAS.CI.Interfaces;

    /// <summary>
    /// Class for employee
    /// </summary>
    public class Employee: IEmployeeDTO
    {
        #region "PROPERTIES"

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Name of employee
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///  Type of contract
        /// </summary>       
        public string contractTypeName { get; set; }

        /// <summary>
        /// Id for role
        /// </summary>
        public int roleId { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string roleName { get; set; }

        /// <summary>
        /// Role description
        /// </summary>
        public string roleDescription { get; set; }

        /// <summary>
        /// Employee hourly salary
        /// </summary>
        public decimal hourlySalary { get; set; }

        /// <summary>
        /// Employee montly salary
        /// </summary>        
        public decimal monthlySalary { get; set; }

        /// <summary>
        /// Employee annual salary
        /// </summary>        
        public decimal calculatedAnnualSalary { get; set; }

        #endregion
    }
}
