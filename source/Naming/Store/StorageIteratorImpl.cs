// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StorageIteratorImpl.cs" company="bbv Software Services AG">
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
//   Defines the StorageIteratorImpl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Store
{
    using CleanCode.Naming.Weapons;

    /// <summary>
    /// Storage Iterator Implementation.
    /// </summary>
    public class StorageIteratorImpl : Iterator
    {
        /// <summary>
        /// The inventory.
        /// </summary>
        private readonly Inventory m_theInventory;

        /// <summary>
        /// The currently for iteration selected weapon index.
        /// </summary>
        private int m_curItWpI = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageIteratorImpl" /> class.
        /// </summary>
        /// <param name="aInventory">A inventory.</param>
        public StorageIteratorImpl(Inventory aInventory)
        {
            m_theInventory = aInventory;
        }

        /// <summary>
        /// Nexts this instance.
        /// </summary>
        /// <returns>
        /// a Weapon.
        /// </returns>
        public Weapon next()
        {
            Weapon takenFromInventoryPosition = m_theInventory.TakeFromInventoryPosition(m_curItWpI);

            m_curItWpI++;

            return takenFromInventoryPosition;
        }

        /// <summary>
        /// Determines whether this instance has next.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has next; otherwise, <c>false</c>.
        /// </returns>
        public bool hasNext()
        {
            return m_curItWpI < m_theInventory.TheInventory;
        }
    }
}