// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Calculator.cs" company="bbv Software Services AG">
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

    public class Calculator
    {
        public const string AdditionOperation = "Add";
        public const string SubtractionOperation = "Sub";
        public const string EndOperation = "End";
        public const string NotDefinedOperation = "NDef";

        private readonly AdditionOperator additionOperator;
        private readonly SubtractionOperator subtractionOperator;

        private int lastSetNumber;

        private string lastSelectedOperation = NotDefinedOperation;

        public Calculator(AdditionOperator additionOperator, SubtractionOperator subtractionOperator)
        {
            this.additionOperator = additionOperator;
            this.subtractionOperator = subtractionOperator;
        }

        public int Result { get; private set; }

        public void SetNumber(int value)
        {
            this.lastSetNumber = value;
        }

        public void PerformOperation(string operation)
        {
            this.Result = this.lastSelectedOperation != NotDefinedOperation
                ? this.Calculate(this.lastSelectedOperation, this.Result, this.lastSetNumber)
                : this.lastSetNumber;

            this.lastSelectedOperation = operation;
        }

        private int Calculate(string operation, int firstNumber, int secondNumber)
        {
            switch (operation)
            {
                case AdditionOperation:
                    return this.additionOperator.CalculateSum(firstNumber, secondNumber);

                case SubtractionOperation:
                    return this.subtractionOperator.CalculateDifference(firstNumber, secondNumber);

                default:
                    throw new ArgumentException("invalid operation " + operation);
            }
        }
    }
}