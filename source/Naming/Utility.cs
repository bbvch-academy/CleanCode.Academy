// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utility.cs" company="bbv Software Services AG">
//   Copyright (c) 2013
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
// <summary>
//   Common Functions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming
{
    using System;
    using System.Threading;

    /// <summary>
    /// Common Functions.
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// The RND.
        /// </summary>
        private Random rnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="Utility" /> class.
        /// </summary>
        public Utility()
        {
            this.rnd = new Random();
        }

        /// <summary>
        /// Generates the number.
        /// </summary>
        /// <param name="smallestPossible">The smallest possible.</param>
        /// <param name="greatestPossible">The greatest possible.</param>
        public int GenerateNumber(int smallestPossible, int greatestPossible)
        {
            int gnrNbr = rnd.Next(smallestPossible, greatestPossible + 1);

            Thread.Sleep(30); // improves random generation

            return gnrNbr;
        }

        /// <summary>
        /// Generates a percent value between 0 and 1.
        /// </summary>
        public double GeneratePercentValue()
        {
            double pV = rnd.NextDouble();

            Thread.Sleep(30); // improves random generation

            return pV;
        }
    }
}