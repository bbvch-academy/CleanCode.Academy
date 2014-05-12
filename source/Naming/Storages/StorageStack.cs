// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StorageStack.cs" company="bbv Software Services AG">
//   Copyright (c) 2014
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
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Storages
{
    using System.Collections.Generic;

    using CleanCode.Naming.Weapons;

    public class StorageStack
    {
        private readonly WeaponCollection weaponCollection;

        public StorageStack()
        {
            this.weaponCollection = new WeaponCollection();
        }

        public IEnumerator<IWeapon> GetEnumerator()
        {
            return new StorageEnumerator(this.weaponCollection);
        }

        public void Push(IWeapon newWeapon)
        {
            this.weaponCollection.Add(newWeapon);
        }

        public IWeapon Pop()
        {
            IWeapon popedWeapon = this.weaponCollection.GetAt(this.weaponCollection.Count - 1);

            this.weaponCollection.RemoveAt(this.weaponCollection.Count - 1);

            return popedWeapon;
        }
    }
}