// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Samurai.cs" company="bbv Software Services AG">
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
//   Defines the Samurai type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Warriors
{
    using CleanCode.Naming.Weapons;

    /// <summary>
    /// The mighty and super strong with the sword Samurai!!!!
    /// </summary>
    /// <remarks>
    /// The mighty samurai is a master of the art of the sword. However, if he doesn't get his
    /// favored killing tool, he will fight with his bare hands rather than using another weapon!
    /// </remarks>
    public class Samurai : Warrior
    {
        /// <summary>
        /// The weapon handler
        /// </summary>
        private readonly WeaponHandler weaponHandler;

        /// <summary>
        /// The qualities
        /// </summary>
        private readonly SkillsContainer qualities;

        /// <summary>
        /// The honored samurai weapon
        /// </summary>
        private Weapon honoredSamuraiWeapon;

        /// <summary>
        /// Initializes a new instance of the <see cref="Samurai" /> class.
        /// </summary>
        /// <param name="weaponHandler">The weapon handler.</param>
        /// <param name="theQualities">The qualities.</param>
        public Samurai(WeaponHandler weaponHandler, SkillsContainer theQualities)
        {
            this.weaponHandler = weaponHandler;
            this.qualities = theQualities;
        }

        /// <summary>
        /// Combats the level.
        /// </summary>
        public int CombatLevel
        {
            get
            {
                return LevelCalculationHelper.DetermineCombatLevel(this.qualities, this.honoredSamuraiWeapon);
            }
        }

        /// <summary>
        /// Equips the warrior with a cool killing tool ^^.
        /// </summary>
        /// <param name="weapon">The weapon.</param>
        public void TakeKillingTool(Weapon weapon)
        {
            this.honoredSamuraiWeapon = this.weaponHandler.HandleEquipmentOfWeapon(weapon);
        }

        /// <summary>
        /// Combats the level.
        /// </summary>
        public string CombatLevelText()
        {
            return string.Format("Samurai is fighting with {0} ({1} attack points)", this.honoredSamuraiWeapon.Label, this.CombatLevel);
        }
    }
}