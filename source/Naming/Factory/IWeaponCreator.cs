// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWeaponFactory.cs" company="bbv Software Services AG">
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
//   Defines the IWeaponFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Factory
{
    using CleanCode.Naming.Weapons;

    /// <summary>
    /// Weapon factory interface.
    /// </summary>
    public interface IWeaponCreator
    {
        /// <summary>
        /// Forges the new weapon.
        /// </summary>
        /// <param name="points">The attack points.</param>
        Weapon ForgeNewWeapon(double points);
    }
}