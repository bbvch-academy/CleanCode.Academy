// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelCalculator.cs" company="bbv Software Services AG">
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
//   Level Calculator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Warriors
{
    using System;

    using CleanCode.Naming.Weapons;

    /// <summary>
    /// Level Calculator
    /// </summary>
    public static class LevelCalculationHelper
    {
        /// <summary>
        /// Determines the level.
        /// </summary>
        /// <param name="skills">The skills.</param>
        /// <param name="weapon">The weapon.</param>
        public static int DetermineCombatLevel(SkillsContainer skills, Weapon weapon)
        {
            double a = skills.Attack + weapon.APoints;
            double d = skills.Defense / skills.Handicap;

            return Convert.ToInt32(Math.Ceiling(a + d));
        }
    }
}