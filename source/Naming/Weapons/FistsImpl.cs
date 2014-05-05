// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FistImpl.cs" company="bbv Software Services AG">
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
//   Defines the FistImpl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Weapons
{
    /// <summary>
    /// Fist implementation
    /// </summary>
    public class FistsImpl : Weapon
    {
        /// <summary>
        /// Gets the attack points.
        /// </summary>
        /// <value>
        /// The attack points.
        /// </value>
        public double APoints
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label
        {
            get
            {
                return "fists";
            }
        }
    }
}