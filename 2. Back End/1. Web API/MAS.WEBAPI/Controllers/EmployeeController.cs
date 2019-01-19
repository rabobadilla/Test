/// <summary>
/// File for the controller employee
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.WEBAPI.Controllers
{
    using MAS.BL.Classes;
    using MAS.CI.Extensions;
    using MAS.CI.Interfaces;
    using MAS.WEBAPI.Models;
    using MAS.WEBAPI.UtilitiesUI;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    /// <summary>
    /// Class for employee's controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region ""PUBLIC FUNCTIONS"

        /// <summary>
        /// Get all the employees
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>An Action result</returns>
        [HttpGet("{id}")]
        [Produces("Application/json")]
        public ActionResult<IEnumerable<IEmployeeDTO>> GetEmployee(int id)
        {
            return this.ExecuteWrapperUI<EmployeeController>(() =>
            {
                EmployeeBL employeeBL = new EmployeeBL();
                List<IEmployeeDTO> employees = employeeBL.GetEmployees(new EmployeeModel() { id = id });

                return Ok(employees);
            });
        }

        #endregion
    }
}
