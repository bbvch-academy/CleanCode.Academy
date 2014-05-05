// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElbLord.cs" company="bbv Software Services AG">
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
//   An elf lord is a teacher of the elf. He will train new elbs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Barracks
{
    using CleanCode.Naming.Warriors;
    using CleanCode.Naming.Weapons;

    /// <summary>
    /// An herdir is a teacher of the elf. He will train new elbs.
    /// </summary>
    public class Herdir : Instructor
    {
        /// <summary>
        /// Instructs new warriors.
        /// </summary>
        /// <param name="o">The offense.</param>
        /// <param name="d">The defense.</param>
        /// <param name="p">The penalty.</param>
        /// <returns>
        /// A new warrior.
        /// </returns>
        public Warrior instruct(double o, double d, int p)
        {
            var sc = new SkillsContainer(o, d, p);

            return new Elf(new BowHandlerImpl(), sc);
        }
    }
}