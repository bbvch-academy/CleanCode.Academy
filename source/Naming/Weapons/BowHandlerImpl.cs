// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BowHandlerImpl.cs" company="bbv Software Services AG">
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
//   Archer weapon handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Weapons
{
    /// <summary>
    /// Archer weapon handler.
    /// </summary>
    public class BowHandlerImpl : WeaponHandler
    {
        /// <summary>
        /// Handles the equipment of the bow.
        /// </summary>
        /// <param name="weapon">The weapon for a archer.</param>
        /// <returns>If weapon is a bow then it will be utilized; otherwise fists.</returns>
        public Weapon HandleEquipmentOfWeapon(Weapon weapon)
        {
            if (weapon is BowImpl)
            {
                return weapon;
            }

            return new FistsImpl();
        }
    }
}