/// <summary>
/// File for execution wrapper in the rest api
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.WEBAPI.UtilitiesUI
{
    using MAS.UTILITIES.Utilities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;

    /// <summary>
    /// Wrapper for the rest api
    /// </summary>
    public static class WrapperUI
    {
        #region ""PUBLIC FUNCTIONS"

        /// <summary>
        /// Wrapper for execute the function
        /// </summary>
        /// <typeparam name="C">Executed Class</typeparam>
        /// <param name="controller">Controller of api rest</param>
        /// <param name="bodyToExecute">Body to execute</param>
        /// <returns>A function</returns>
        public static ActionResult ExecuteWrapperUI<C>(this ControllerBase controller, Func<ActionResult> bodyToExecute) where C : class
        {
            ActionResult respuesta;

            respuesta = Wrapper.ExecuteWrapper<ActionResult, C>(bodyToExecute);

            if (respuesta == null)
            {
                respuesta = controller.StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return respuesta;
        }

        #endregion
    }
}
