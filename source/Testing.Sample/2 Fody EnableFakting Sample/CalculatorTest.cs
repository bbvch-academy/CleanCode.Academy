// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalculatorTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Testing.Sample
{
    using CleanCode.Testing.Sample.Implementation;

    using FakeItEasy;
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class CalculatorTest
    {
        private Calculator testee;

        private AdditionOperator additionOperator;
        private SubtractionOperator subtractionOperator;

        [SetUp]
        public void SetUp()
        {
            this.additionOperator = A.Fake<AdditionOperator>();
            this.subtractionOperator = A.Fake<SubtractionOperator>();

            SetUpFakeAdditionOperator(this.additionOperator);
            SetUpFakeSubtractionOperator(this.subtractionOperator);
            
            this.testee = new Calculator(this.additionOperator, this.subtractionOperator);
        }

        [Test]
        public void CaluclatesSimpleAddition()
        {
            this.testee.SetNumber(23);
            this.testee.PerformOperation(Calculator.AdditionOperation);
            this.testee.SetNumber(17);
            this.testee.PerformOperation(Calculator.EndOperation);

            int result = this.testee.Result;

            result.Should().Be(40, "we calculated 23+17");
        }

        [Test]
        public void CaluclatesChainedAddition()
        {
            this.testee.SetNumber(23);
            this.testee.PerformOperation(Calculator.AdditionOperation);
            this.testee.SetNumber(17);
            this.testee.PerformOperation(Calculator.AdditionOperation);
            this.testee.SetNumber(15);
            this.testee.PerformOperation(Calculator.AdditionOperation);
            this.testee.SetNumber(20);
            this.testee.PerformOperation(Calculator.EndOperation);

            int result = this.testee.Result;

            result.Should().Be(75, "we calculated 23+17+15+20");
        }

        [Test]
        public void OverridesNumberInCalculation()
        {
            this.testee.SetNumber(23);
            this.testee.PerformOperation(Calculator.AdditionOperation);
            this.testee.SetNumber(17);
            this.testee.SetNumber(20);
            this.testee.PerformOperation(Calculator.EndOperation);

            int result = this.testee.Result;

            result.Should().Be(43, "we calculated 23+20");
        }

        [Test]
        public void CaluclatesSimpleSubtraction()
        {
            this.testee.SetNumber(23);
            this.testee.PerformOperation(Calculator.SubtractionOperation);
            this.testee.SetNumber(17);
            this.testee.PerformOperation(Calculator.EndOperation);

            int result = this.testee.Result;

            result.Should().Be(6, "we calculated 23-17");
        }

        private static void SetUpFakeAdditionOperator(AdditionOperator fakeOperator)
        {
            A.CallTo(() => fakeOperator.CalculateSum(A<int>._, A<int>._)).ReturnsLazily((int a, int b) => a + b);
        }

        private static void SetUpFakeSubtractionOperator(SubtractionOperator fakeOperator)
        {
            A.CallTo(() => fakeOperator.CalculateDifference(A<int>._, A<int>._)).ReturnsLazily((int a, int b) => a - b);
        }
    }
}