// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Inventory.cs" company="bbv Software Services AG">
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
//   Defines the Inventory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Store
{
    using System.Collections.ObjectModel;

    using CleanCode.Naming.Weapons;

    /// <summary>
    /// Weapon Inventory
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// The m_ the inventory
        /// </summary>
        private Collection<Weapon> m_TheInventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheInventory" /> class.
        /// </summary>
        public Inventory()
        {
            m_TheInventory = new Collection<Weapon>();
        }

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        public int TheInventory
        {
            get
            {
                return m_TheInventory.Count;
            }
        }

        /// <summary>
        /// Delivers the specified new weapon.
        /// </summary>
        /// <param name="newWeapon">The new weapon.</param>
        public void DeliverToInventory(Weapon newWeapon)
        {
            m_TheInventory.Add(newWeapon);
        }

        /// <summary>
        /// Takes from inventory position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public Weapon TakeFromInventoryPosition(int position)
        {
            return m_TheInventory[position];
        }

        /// <summary>
        /// Erases the weapon from invetory.
        /// </summary>
        /// <param name="p">The position.</param>
        public void EraseWeaponFromInvetory(int p)
        {
            m_TheInventory.RemoveAt(p);
        }
    }
}