// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillsContainer.cs" company="bbv Software Services AG">
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
//   Defines the Skills container type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Warriors
{
    /// <summary>
    /// The skills.
    /// </summary>
    public class SkillsContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillsContainer" /> class.
        /// </summary>
        /// <param name="attack">The attack.</param>
        /// <param name="defense">The defense.</param>
        /// <param name="handicap">The handicap.</param>
        public SkillsContainer(double attack, double defense, int handicap)
        {
            this.Attack = attack;
            this.Defense = defense;
            this.Handicap = handicap;
        }

        /// <summary>
        /// Gets the attack force.
        /// </summary>
        /// <value>
        /// The attack force.
        /// </value>
        public double Attack { get; private set; }

        /// <summary>
        /// Gets the defense.
        /// </summary>
        /// <value>
        /// The defense.
        /// </value>
        public double Defense { get; private set; }

        /// <summary>
        /// Gets the handicap.
        /// </summary>
        /// <value>
        /// The handicap.
        /// </value>
        public int Handicap { get; private set; }
    }
}