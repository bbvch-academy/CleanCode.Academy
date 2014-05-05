// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponFactory.cs" company="bbv Software Services AG">
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
//   Defines the WeaponFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Factory
{
    using System;
    using System.Collections.Generic;

    using CleanCode.Naming.Weapons;

    /// <summary>
    /// Creates new weapons for the ultimate fight.
    /// </summary>
    public class WeaponCreator
    {
        /// <summary>
        /// The smith register
        /// </summary>
        private readonly Dictionary<int, IWeaponCreator> smithRegister;

        /// <summary>
        /// The weapon indication
        /// </summary>
        private readonly Utility weaponIndication;

        /// <summary>
        /// Prevents a default instance of the <see cref="WeaponCreator"/> class from being created.
        /// </summary>
        public WeaponCreator()
        {
            this.weaponIndication = new Utility();
            this.smithRegister = new Dictionary<int, IWeaponCreator>();

            PrepareFactoryForProduction();
        }

        /// <summary>
        /// Forges randomly a new weapon.
        /// </summary>
        public Weapon ForgeNewWeapon()
        {
            int predicatedWeaponCode = this.weaponIndication.GenerateNumber(0, 2);

            var utility = new Utility();

            double points = utility.GeneratePercentValue() * 100 + 100;

            return this.smithRegister[predicatedWeaponCode].ForgeNewWeapon(points);
        }

        /// <summary>
        /// Initialize factory.
        /// </summary>
        private void PrepareFactoryForProduction()
        {
            this.smithRegister.Add(0, new SwordSmith());
            this.smithRegister.Add(1, new SpearSmith());
            this.smithRegister.Add(2, new Bowyer());
        }
    }
}