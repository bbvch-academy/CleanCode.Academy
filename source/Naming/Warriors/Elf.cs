// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Elf.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.Warriors
{
    using CleanCode.Naming.Weapons;

    public class Elf : IWarrior
    {
        private readonly IWeaponEquipmentStrategy weaponEquipmentStrategy;

        private readonly Skills skills;

        private IWeapon weapon;

        public Elf(IWeaponEquipmentStrategy weaponEquipmentStrategy, Skills skills)
        {
            this.weaponEquipmentStrategy = weaponEquipmentStrategy;
            this.skills = skills;
        }

        public int CombatLevel
        {
            get
            {
                return CombatLevelCalculator.Calculate(this.skills, this.weapon);
            }
        }

        public void Equip(IWeapon weapon)
        {
            this.weapon = this.weaponEquipmentStrategy.Equip(weapon);
        }

        public string CombatMessage()
        {
            return string.Format("Elf is fighting with {0} ({1} attack points)", this.weapon.Name, this.CombatLevel);
        }
    }
}