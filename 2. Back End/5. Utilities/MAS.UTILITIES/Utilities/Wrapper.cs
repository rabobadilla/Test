/// <summary>
/// File for execution wrapper
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.UTILITIES.Utilities
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Wrapper of execution
    /// </summary>
    public class Wrapper
    {

        #region "METODOS PUBLICOS"

        /// <summary>
        /// Wrapper for execute the function
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <typeparam name="C">Executed Class</typeparam>
        /// <param name="bodyToExecute">Body to execute</param>
        /// <param name="doInError">Do in error</param>
        /// <param name="doInFinalization">Do in finalization</param>
        /// <returns>A function</returns>
        public static T ExecuteWrapper<T, C>(Func<T> bodyToExecute, Func<Exception, T> doInError, Func<T, T> doInFinalization) where C : class
        {
            T retorno = default(T);
            Guid correlationId = Guid.NewGuid();
            try
            {
                retorno = bodyToExecute();
            }
            catch (Exception exception)
            {
                exception = exception.InnerException == null ? exception : exception.GetBaseException();
                string methodName = BasicExtensions.GetExecutionMethod(typeof(C));

                StringBuilder exceptionTrace = new StringBuilder();

                exceptionTrace.Append("Date: ");
                exceptionTrace.Append(DateTime.Now.ToString());
                exceptionTrace.AppendLine();
                exceptionTrace.Append("Method: ");
                exceptionTrace.Append(methodName);
                exceptionTrace.AppendLine();
                exceptionTrace.Append("Exception: ");
                exceptionTrace.Append(exception.Message);
                exceptionTrace.AppendLine();

                File.WriteAllText(string.Concat(@"Logs\", correlationId.ToString(), ".txt"), exceptionTrace.ToString());
            }

            finally
            {
                if (doInFinalization != null)
                {
                    retorno = doInFinalization(retorno);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Wrapper for execute the function
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <typeparam name="C">Executed Class</typeparam>
        /// <param name="bodyToExecute">Body to execute</param>
        /// <param name="doInError">Do in error</param>
        /// <returns>The function</returns>
        public static T ExecuteWrapper<T, C>(Func<T> bodyToExecute, Func<Exception, T> doInError) where C : class
        {
            return ExecuteWrapper<T, C>(bodyToExecute, doInError, null);
        }

        /// <summary>
        /// Wrapper for execute the function
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <typeparam name="C">Executed Class</typeparam>
        /// <param name="bodyToExecute">Body to execute</param>
        /// <returns>The function</returns>
        public static T ExecuteWrapper<T, C>(Func<T> bodyToExecute) where C : class
        {
            return ExecuteWrapper<T, C>(bodyToExecute, null, null);
        }

        /// <summary>
        /// Wrapper for execute the function
        /// </summary>
        /// <typeparam name="C">Executed Class</typeparam>
        /// <param name="bodyToExecute">Body to execute</param>
        public static void ExecuteWrapper<C>(Action bodyToExecute) where C : class
        {
            bool nothing = ExecuteWrapper<bool, C>(() =>
            {
                bodyToExecute();
                return false;
            });
        }

        #endregion
    }
}
