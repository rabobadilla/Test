

namespace MAS.UTILITIES.UI.Classes
{
    using MAS.UTILITIES.Utilities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;

    public static class WrapperUI
    {

        public static ActionResult ExecuteWrapperUI<C>(this ControllerBase controller, Func<ActionResult> cuerpoEjecutar) where C : class
        {
            ActionResult respuesta = Wrapper.ExecuteWrapper<ActionResult, C>(cuerpoEjecutar, (ex) =>
            {
                return controller.DoInError<C>(ex);
            });

            return respuesta;
        }
        private static ActionResult DoInError<C>(this ControllerBase controller, Exception exception) where C : class
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }
}
