/// <summary>
/// File for the class extension related with the employee
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.CI.Extensions
{
    using MAS.CI.Interfaces;
    using MAS.UTILITIES.Utilities;
    using System.Collections.Generic;

    /// <summary>
    /// Class extension related with the employee
    /// </summary>
    public static class EmployeeDTOExtension
    {

        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Mapper to employee
        /// </summary>
        /// <typeparam name="TR">Type to cast</typeparam>
        /// <param name="origin">Origin data type</param>
        /// <returns>A casted type</returns>
        public static TR EmployeeMapper<TR>(this IEmployeeDTO origin)
        where TR : IEmployeeDTO, new()
        {
            return origin.EmployeeMapper(new TR());
        }

        /// <summary>
        /// Mapper to employee
        /// </summary>
        /// <typeparam name="TR">Type to cast</typeparam>
        /// <param name="origin">Origin data type</param>
        /// <param name="destination">Destination data type</param>
        /// <returns>A casted type</returns>
        public static TR EmployeeMapper<TR>(this IEmployeeDTO origin, TR destination)
        where TR : IEmployeeDTO, new()
        {
            if (origin == null)
            {
                destination = default(TR);
            }
            else
            {
                if (destination == null)
                {
                    destination = new TR();
                }

                destination.id = origin.id;
                destination.name = origin.name;
                destination.contractTypeName = origin.contractTypeName;
                destination.roleId = origin.roleId;
                destination.roleName = origin.roleName;
                destination.roleDescription = origin.roleDescription;
                destination.hourlySalary = origin.hourlySalary;
                destination.monthlySalary = origin.monthlySalary;
                destination.calculatedAnnualSalary = origin.calculatedAnnualSalary;
            }

            return destination;
        }

        /// <summary>
        /// Cast a list of employees
        /// </summary>
        /// <typeparam name="TR">Type to cast</typeparam>
        /// <param name="origin">Origin data type</param>
        /// <returns>A casted list</returns>
        public static List<TR> EmployeeListMapper<TR>(this List<IEmployeeDTO> origin)
        where TR : IEmployeeDTO, new()
        {
            return BasicExtensions.ListCast(origin, (itemorigin) => { return itemorigin.EmployeeMapper(new TR()); });
        }

        #endregion

    }

}
