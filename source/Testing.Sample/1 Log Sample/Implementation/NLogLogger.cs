// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NLogLogger.cs" company="bbv Software Services AG">
//   Copyright (c) 2014
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Testing.Sample.Implementation
{
    using System;

    using NLog;

    public class NLogLogger : ILogger
    {
        private readonly Logger logger;

        public NLogLogger(Logger log)
        {
            this.logger = log;
        }

        public void Fatal(string logMessageFormatString, params object[] args)
        {
            this.logger.Fatal(logMessageFormatString, args);
        }

        public void Fatal(Exception exception, string logMessageFormatString, params object[] args)
        {
            this.logger.Fatal(exception, logMessageFormatString, args);
        }

        public void Error(string logMessageFormatString, params object[] args)
        {
            this.logger.Error(logMessageFormatString, args);
        }

        public void Error(Exception exception, string logMessageFormatString, params object[] args)
        {
            this.logger.Error(exception, logMessageFormatString, args);
        }

        public void Warn(string logMessageFormatString, params object[] args)
        {
            this.logger.Warn(logMessageFormatString);
        }

        public void Warn(Exception exception, string logMessageFormatString, params object[] args)
        {
            this.logger.Warn(exception, logMessageFormatString, args);
        }

        public void Info(string logMessageFormatString, params object[] args)
        {
            this.logger.Info(logMessageFormatString, args);
        }

        public void Info(Exception exception, string logMessageFormatString, params object[] args)
        {
            this.logger.Info(exception, logMessageFormatString, args);
        }

        public void Debug(string logMessageFormatString, params object[] args)
        {
            this.logger.Debug(logMessageFormatString, args);
        }

        public void Debug(Exception exception, string logMessageFormatString, params object[] args)
        {
            this.logger.Debug(exception, logMessageFormatString, args);
        }

        public void Trace(string logMessageFormatString, params object[] args)
        {
            this.logger.Trace(logMessageFormatString, args);
        }

        public void Trace(Exception exception, string logMessageFormatString, params object[] args)
        {
            this.logger.Trace(exception, logMessageFormatString, args);
        }
    }
}