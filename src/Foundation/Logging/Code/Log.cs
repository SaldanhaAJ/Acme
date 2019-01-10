using System.ComponentModel;
using log4net;
using System;

namespace Foundation.Log
{
    public static class Log
    {

        private static readonly ILog log = LogManager.GetLogger("Foundation.Logger");

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug([Localizable(false)] string message)
        {
            log.Debug(message);
        }

        /// </param>
        public static void Error([Localizable(false)] string message)
        {
            log.Error(message);
        }

        public static void Error([Localizable(false)] string message, Exception ex)
        {
            log.Error(message + " " + ex.Message);
        }
        public static void Info([Localizable(false)] string message)
        {
            log.Info(message);
        }

    }
}