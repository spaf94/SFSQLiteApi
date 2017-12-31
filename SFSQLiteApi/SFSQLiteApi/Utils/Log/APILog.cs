using System;

namespace SFSQLiteApi.Utils.Log
{
    internal class APILog
    {
        #region Members

        /// <summary>
        /// The is log active
        /// </summary>
        internal static bool IsLogActive = false;

        #endregion Members

        #region Activate/Deactivate

        /// <summary>
        /// Activates the log.
        /// </summary>
        internal static void ActivateLog()
        {
            IsLogActive = true;
        }

        /// <summary>
        /// Deactivates the log.
        /// </summary>
        internal static void DeactivateLog()
        {
            IsLogActive = false;
        }

        #endregion Activate/Deactivate

        #region Log

        /// <summary>
        /// Debugs the specified object class.
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="method">The method.</param>
        /// <param name="message">The message.</param>
        internal static void Debug(Type type, string method, string message)
        {
            if (IsLogActive)
            {
                SFLog.Log.Debug(type, method, message);
            }
        }

        /// <summary>
        /// Errors the specified object class.
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="method">The method.</param>
        /// <param name="exception">The exception.</param>
        internal static void Error(object objClass, string method, Exception exception)
        {
            if (IsLogActive)
            {
                SFLog.Log.Error(objClass, method, exception);
            }
        }

        #endregion Log
    }
}