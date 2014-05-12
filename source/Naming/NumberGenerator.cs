// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberGenerator.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming
{
    using System;
    using System.Threading;

    public class NumberGenerator
    {
        private readonly Random random;

        public NumberGenerator()
        {
            this.random = new Random();
        }

        public int GenerateNumber(int smallestPossible, int greatestPossible)
        {
            WaitForRandomImprovement();

            return this.random.Next(smallestPossible, greatestPossible + 1);
        }

        public double GeneratePercentValue()
        {
            WaitForRandomImprovement();

            return this.random.NextDouble();
        }

        private static void WaitForRandomImprovement()
        {
            Thread.Sleep(30);
        }
    }
}