// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponCollection.cs" company="bbv Software Services AG">
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
    using System.Collections.ObjectModel;

    using CleanCode.Naming.Weapons;

    public class WeaponCollection
    {
        private readonly Collection<IWeapon> weapons;

        public WeaponCollection()
        {
            this.weapons = new Collection<IWeapon>();
        }

        public int Count
        {
            get
            {
                return this.weapons.Count;
            }
        }

        public void Add(IWeapon newWeapon)
        {
            this.weapons.Add(newWeapon);
        }

        public IWeapon GetAt(int index)
        {
            return this.weapons[index];
        }

        public void RemoveAt(int index)
        {
            this.weapons.RemoveAt(index);
        }
    }
}