// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FightEnd.cs" company="bbv Software Services AG">
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
//   Result of a fight.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming
{
    /// <summary>
    /// Result of a fight.
    /// </summary>
    public class FightEnd
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FightEnd" /> class.
        /// </summary>
        /// <param name="w1Won">if set to <c>true</c> [w1 won].</param>
        public FightEnd(bool w1Won)
        {
            W1Killed = !w1Won;
        }

        /// <summary>
        /// Gets a value indicating whether [w1 killed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [w1 killed]; otherwise, <c>false</c>.
        /// </value>
        public bool W1Killed { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [w2 killed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [w2 killed]; otherwise, <c>false</c>.
        /// </value>
        public bool W2Killed
        {
            get
            {
                return !W1Killed;
            }
        }
    }
}