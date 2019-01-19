/// <summary>
/// File for the constants
/// </summary>
/// <remarks>
/// Autor: Raul Bobadilla - raul.bobadilla.mendez@hotmail.com
/// Fecha: 18/01/2018
/// </remarks>
namespace MAS.UTILITIES.Constants
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for the constants
    /// </summary>
    public static class Constants
    {
        #region "COMMON CONSTANTS"

        public static readonly List<string> METHODSTOIGNORE = new List<string>(new[] { "GetExecutingMethodName", "ExecuteWrapper", "ExecuteWrapperBL", "ExecuteWrapperDB", "ExecuteWrapperProxy", "InvokeMethod", "UnsafeInvokeInternal" });

        public const string METHODSSTARTSWITH = "<>";

        public const string DOT = ".";

        public const string OPENEDBRACKET = "(";

        public const string CLOSEDBRACKET = ")";

        #endregion
    }
}


