// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="bbv Software Services AG">
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

    public interface ILogger
    {
        void Fatal(string logMessageFormatString, params object[] args);

        void Fatal(Exception exception, string logMessageFormatString, params object[] args);

        void Error(string logMessage, params object[] args);

        void Error(Exception exception, string logMessageFormatString, params object[] args);

        void Warn(string logMessageFormatString, params object[] args);

        void Warn(Exception exception, string logMessageFormatString, params object[] args);

        void Info(string logMessage, params object[] args);

        void Info(Exception exception, string logMessageFormatString, params object[] args);

        void Debug(string logMessageFormatString, params object[] args);

        void Debug(Exception exception, string message, params object[] args);

        void Trace(string logMessage, params object[] args);

        void Trace(Exception exception, string message, params object[] args);
    }
}