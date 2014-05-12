// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponFactory.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.Factory
{
    using System.Collections.Generic;

    using CleanCode.Naming.Weapons;

    public class WeaponFactory
    {
        private readonly Dictionary<int, IWeaponFactory> smithRegister;

        private readonly NumberGenerator weaponIndication;

        public WeaponFactory()
        {
            this.weaponIndication = new NumberGenerator();
            this.smithRegister = new Dictionary<int, IWeaponFactory>();

            this.PrepareFactoryForProduction();
        }

        public IWeapon ForgeNewWeapon()
        {
            int predicatedWeaponCode = this.weaponIndication.GenerateNumber(0, 2);

            var utility = new NumberGenerator();

            double points = (utility.GeneratePercentValue() * 100d) + 100d;

            System.Threading.Thread.Sleep(10); // improves random generation

            return this.smithRegister[predicatedWeaponCode].Create(points);
        }

        private void PrepareFactoryForProduction()
        {
            this.smithRegister.Add(0, new SwordFactory());
            this.smithRegister.Add(1, new SpearFactory());
            this.smithRegister.Add(2, new BowFactory());
        }
    }
}