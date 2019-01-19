/// <summary>
/// File for basic extensions
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.UTILITIES.Utilities
{
    using MAS.UTILITIES.Constants;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>
    /// Class for basic extensions
    /// </summary>
    public static class BasicExtensions
    {
        #region "PUBLIC FUNCTIONS"

        /// <summary>
        /// Extension method to return an enum value of type T for the given string
        /// </summary>
        /// <typeparam name="T">Type of Enum</typeparam>
        /// <param name="value">String value of enum</param>
        /// <returns>A Enum</returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Cast a list to an explicit type
        /// </summary>
        /// <typeparam name="TOrigin">Data type origin</typeparam>
        /// <typeparam name="TDestination">Data type destination</typeparam>
        /// <param name="list">List to cast</param>
        /// <param name="function">Function value</param>
        /// <returns>A casted list</returns>
        public static List<TDestination> ListCast<TOrigin, TDestination>(IEnumerable<TOrigin> list, Func<TOrigin, TDestination> function)
        {
            List<TDestination> outList = new List<TDestination>();

            if (list != null)
            {
                foreach (TOrigin item in list)
                {
                    outList.Add(function(item));
                }
            }

            return outList;
        }

        /// <summary>
        /// Get the name of the method
        /// </summary>
        /// <param name="type">data type</param>
        /// <returns>Name of method</returns>
        public static string GetExecutionMethod(Type type)
        {
            try
            {
                string result = string.Concat((type == null ? string.Empty : type.FullName));
                StackTrace trace = new StackTrace(false);

                bool isTheMethod, isTheOptionalMethod;

                foreach (StackFrame frame in trace.GetFrames())
                {
                    MethodBase method = frame.GetMethod();

                    if (type == null)
                    {
                        isTheMethod = Constants.METHODSTOIGNORE.Find(m => method.Name.Contains(m)) == null;
                        isTheOptionalMethod = method.DeclaringType.Name.StartsWith(Constants.METHODSSTARTSWITH);
                    }
                    else
                    {
                        isTheMethod = isTheOptionalMethod = method.DeclaringType == type && type.IsAssignableFrom(method.DeclaringType);
                    }

                    if (isTheMethod)
                    {
                        result = string.Concat(method.DeclaringType.FullName, Constants.DOT, method.Name, Constants.OPENEDBRACKET, Constants.CLOSEDBRACKET);

                        if (!isTheOptionalMethod)
                        {
                            break;
                        }
                    }

                }

                return result;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
