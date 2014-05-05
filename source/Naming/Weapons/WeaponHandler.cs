// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponHandler.cs" company="bbv Software Services AG">
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
//   Weapon handler interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Weapons
{
    /// <summary>
    /// Weapon handler interface.
    /// </summary>
    public interface WeaponHandler
    {
        /// <summary>
        /// Handles the equipment of a specific weapon.
        /// </summary>
        /// <param name="weapon">The weapon.</param>
        /// <returns>The effective weapon of a warrior.</returns>
        Weapon HandleEquipmentOfWeapon(Weapon weapon);
    }
}