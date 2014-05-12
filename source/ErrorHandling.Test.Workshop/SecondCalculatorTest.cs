// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecondCalculatorTest.cs" company="bbv Software Services AG">
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

namespace ErrorHandling.Test.Workshop
{
    using System;

    using ErrorHandling.Workshop.SecondExercise;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class SecondCalculatorTest
    {
        private Calculator testee;

        private LoggerStub loggerStub;

        [SetUp]
        public void SetUp()
        {
            this.loggerStub = new LoggerStub();

            this.testee = new Calculator(this.loggerStub);
        }

        [Test]
        public void CalculatesPowerOfTwoNumbers()
        {
            this.testee.SetNumber(2);
            this.testee.PerformOperation(PowerOperator.Name);
            this.testee.SetNumber(4);
            this.testee.PerformOperation(EndOperator.Name);

            int result = this.testee.Result;

            result.Should().Be(16, "we calculated 2^4");
        }

        [Test]
        public void ThrowsArithmeticExceptionWithFullStackTrace_WhenCalculatedPowerResultExceedsLimit()
        {
            this.testee.SetNumber(200);
            this.testee.PerformOperation(PowerOperator.Name);
            this.testee.SetNumber(5);

            Action act = () => this.testee.PerformOperation(EndOperator.Name);

            act.ShouldThrow<OverflowException>()
                .And.StackTrace.Should().Contain("SecondExercise.PowerOperator.Calculate");
        }

        [Test]
        public void Logs_WhenCalculatedPowerResultExceedsLimit()
        {
            this.testee.SetNumber(200);
            this.testee.PerformOperation(PowerOperator.Name);
            this.testee.SetNumber(5);

            this.testee.Invoking(x => x.PerformOperation(EndOperator.Name)).ShouldThrow<Exception>();

            this.loggerStub.LoggedMessages.Should().Contain(x => x.Contains("something") && x.Contains("wrong"));
        }
    }
}