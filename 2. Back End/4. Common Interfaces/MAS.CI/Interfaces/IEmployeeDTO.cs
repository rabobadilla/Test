/// <summary>
/// File for the interface related to the employee
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.CI.Interfaces
{
    /// <summary>
    /// Interface related to the employee
    /// </summary>
    public interface IEmployeeDTO
    {
        #region "PROPERTIES"

        /// <summary>
        /// Unique identifier
        /// </summary>
        int id { get; set; }

        /// <summary>
        /// Name of employee
        /// </summary>
        string name { get; set; }

        /// <summary>
        ///  Type of contract
        /// </summary>       
        string contractTypeName { get; set; }

        /// <summary>
        /// Id for role
        /// </summary>
        int roleId { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        string roleName { get; set; }

        /// <summary>
        /// Role description
        /// </summary>
        string roleDescription { get; set; }

        /// <summary>
        /// Employee hourly salary
        /// </summary>
        decimal hourlySalary { get; set; }

        /// <summary>
        /// Employee montly salary
        /// </summary>        
        decimal monthlySalary { get; set; }
        
        /// <summary>
        /// Employee annual salary
        /// </summary>        
        decimal calculatedAnnualSalary { get; set; }

        #endregion
    }

}