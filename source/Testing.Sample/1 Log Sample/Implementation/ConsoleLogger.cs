// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="bbv Software Services AG">
//   Copyright (c) 2014 - 2020
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
    using System.Globalization;

    public class ConsoleLogger : ILogger
    {
        public void Fatal(string logMessageFormatString, params object[] args)
        {
            WriteToConsole(logMessageFormatString, args);
        }

        public void Fatal(Exception exception, string logMessageFormatString, params object[] args)
        {
            WriteToConsole(exception, logMessageFormatString, args);
        }

        public void Error(string logMessageFormatString, params object[] args)
        {
            WriteToConsole(logMessageFormatString, args);
        }

        public void Error(Exception exception, string logMessageFormatString, params object[] args)
        {
            WriteToConsole(exception, logMessageFormatString, args);
        }

        public void Warn(string logMessageFormatString, params object[] args)
        {
            WriteToConsole(logMessageFormatString, args);
        }

        public void Warn(Exception exception, string logMessageFormatString, params object[] args)
        {
            WriteToConsole(exception, logMessageFormatString, args);
        }

        public void Info(string logMessageFormatString, params object[] args)
        {
            WriteToConsole(logMessageFormatString, args);
        }

        public void Info(Exception exception, string logMessageFormatString, params object[] args)
        {
            WriteToConsole(exception, logMessageFormatString, args);
        }

        public void Debug(string logMessageFormatString, params object[] args)
        {
            WriteToConsole(logMessageFormatString, args);
        }

        public void Debug(Exception exception, string logMessageFormatString, params object[] args)
        {
            WriteToConsole(exception, logMessageFormatString, args);
        }

        public void Trace(string logMessageFormatString, params object[] args)
        {
            WriteToConsole(logMessageFormatString, args);
        }

        public void Trace(Exception exception, string logMessageFormatString, params object[] args)
        {
            WriteToConsole(exception, logMessageFormatString, args);
        }

        private static void WriteToConsole(string message, params object[] args)
        {
            string time = string.Format(CultureInfo.InvariantCulture, "[{0:HH:mm:ss.FFFF}]  ", DateTime.Now);

            Console.WriteLine(time + message, args);
        }

        private static void WriteToConsole(Exception exception, string message, params object[] args)
        {
            WriteToConsole(message, args);
            Console.WriteLine(exception);
        }
    }
}