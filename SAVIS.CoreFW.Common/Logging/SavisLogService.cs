﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;
using System.Diagnostics;
using log4net.Core;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using System.Configuration;

namespace NewCMS.Common
{
    /*
     * Log service implemented
     * This service will hold 5 different level of logger
     * These logger can be dynamically configured using Log.config file
     * The logger's name is fixed to mapping between this wrapper class and log configuration
     * Author : TruongND
     * Savis Vietnam Corporation
     */


    public class SavisLogService : ILogService
    {
        private readonly log4net.ILog log4Net;

        public SavisLogService(string logName)
        {
            this.log4Net = LogManager.GetLogger(logName);
        }

        public SavisLogService(log4net.ILog log4Net)
        {
            this.log4Net = log4Net;
        }

        #region ILog Members

        /// <summary>
        /// Log to file with type Debug
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            log4Net.Debug(BuildMessage(message));
            // Console.WriteLine(message);
        }

        /// <summary>
        /// Log to file with type Debug
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message, Exception exception)
        {
            log4Net.Debug(BuildMessage(message), exception);
        }

        /// <summary>
        /// Log to file with type Info
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            log4Net.Info(BuildMessage(message));
        }

        /// <summary>
        /// Log to file with type Info
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message, Exception exception)
        {
            log4Net.Info(BuildMessage(message), exception);
        }
        public void Info(object message, Guid userId, Guid appId)
        {
            var msg = BuildMessage(message);

            Info(msg);
        }

    /// <summary>
        /// Log to file with type Warn
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            log4Net.Warn(BuildMessage(message));
        }

        /// <summary>
        /// Log to file with type Warn
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message, Exception exception)
        {
            log4Net.Warn(BuildMessage(message), exception);
        }

        /// <summary>
        /// Log to file with type Error
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            log4Net.Error(BuildMessage(message));
        }

        /// <summary>
        /// Log to file with type Error
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message, Exception exception)
        {
            log4Net.Error(BuildMessage(message), exception);
        }
        /// <summary>
        /// Log to file with type Error
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            log4Net.Fatal(BuildMessage(message));
        }

        /// <summary>
        /// Log to file with type Warn
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message, Exception exception)
        {
            log4Net.Fatal(BuildMessage(message), exception);
        }

        /// <summary>
        /// Return log with type Debug is enabled
        /// </summary>
        public bool IsDebugEnabled
        {
            get { return log4Net.IsDebugEnabled; }
        }

        /// <summary>
        /// Return log with type Info is enabled
        /// </summary>
        public bool IsInfoEnabled
        {
            get { return log4Net.IsInfoEnabled; }
        }

        /// <summary>
        /// Return log with type Warn is enabled
        /// </summary>
        public bool IsWarnEnabled
        {
            get { return log4Net.IsWarnEnabled; }
        }

        /// <summary>
        /// Return log with type Error is enabled
        /// </summary>
        public bool IsErrorEnabled
        {
            get { return log4Net.IsErrorEnabled; }
        }

        #endregion

        private static string BuildMessage(object message)
        {
            var aboveFrame = new StackFrame(3);
            return
                String.Format("[{0} - {1}] {2}", aboveFrame.GetMethod().ReflectedType.FullName,
                              aboveFrame.GetMethod().Name, message);
        }

        public void Debug(LogMessage message, Guid? userId, Guid? appId)
        {
            throw new NotImplementedException();
        }

        public void Debug(LogMessage message, Guid? userId, Guid? appId, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Info(LogMessage message, Guid? userId, Guid? appId)
        {
            throw new NotImplementedException();
        }

        public void Info(LogMessage message, Guid? userId, Guid? appId, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Warn(LogMessage message, Guid? userId, Guid? appId)
        {
            throw new NotImplementedException();
        }

        public void Warn(LogMessage message, Guid? userId, Guid? appId, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Error(LogMessage message, Guid? userId, Guid? appId)
        {
            throw new NotImplementedException();
        }

        public void Error(LogMessage message, Guid? userId, Guid? appId, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Fatal(LogMessage message, Guid? userId, Guid? appId)
        {
            throw new NotImplementedException();
        }

        public void Fatal(LogMessage message, Guid? userId, Guid? appId, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
