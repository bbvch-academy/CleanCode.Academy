// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarriorBuilder.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.Barracks
{
    using System;

    using CleanCode.Naming.Warriors;
    using CleanCode.Naming.Weapons;

    public class WarriorBuilder
    {
        private const int SamuraiCode = 0;
        private const int AncientGreekCode = 1;
        private const int ElfCode = 2;

        private static int lastWarriorCode = -1;

        private readonly IWarriorFactory warriorFactory;

        private double attackPoints;
        private double defensePoints;
        private int handicapPoints;
        private IWeapon weapon;

        private WarriorBuilder(IWarriorFactory warriorFactory)
        {
            this.warriorFactory = warriorFactory;

            this.attackPoints = 1;
            this.defensePoints = 1;
            this.handicapPoints = 1;
        }

        public static WarriorBuilder NewRandom()
        {
            int warriorCode = GenerateWarriorCode();

            switch (warriorCode)
            {
                case SamuraiCode:
                    return NewSamurai();
                case AncientGreekCode:
                    return NewAncientGreek();
                case ElfCode:
                    return NewElf();
                default:
                    throw new InvalidOperationException("something went terribly wrong...");
            }
        }

        public static WarriorBuilder NewSamurai()
        {
            return new WarriorBuilder(new SamuraiFactory());
        }

        public static WarriorBuilder NewElf()
        {
            return new WarriorBuilder(new ElfFactory());
        }

        public static WarriorBuilder NewAncientGreek()
        {
            return new WarriorBuilder(new AncientGreekFactory());
        }

        public WarriorBuilder WithAttackPoints(double attackPoints)
        {
            this.attackPoints = attackPoints;

            return this;
        }

        public WarriorBuilder WithDefensePoints(double defensePoints)
        {
            this.defensePoints = defensePoints;

            return this;
        }

        public WarriorBuilder WithHandicapPoints(int handicapPoints)
        {
            this.handicapPoints = handicapPoints;

            return this;
        }

        public WarriorBuilder WithWeapon(IWeapon weapon)
        {
            this.weapon = weapon;

            return this;
        }

        public IWarrior Build()
        {
            IWarrior warrior = this.warriorFactory.Create(this.attackPoints, this.defensePoints, this.handicapPoints);

            if (this.weapon != null)
            {
                warrior.Equip(this.weapon);
            }

            return warrior;
        }

        private static int GenerateWarriorCode()
        {
            var numberGenerator = new NumberGenerator();
            int generatedWarriorCode;

            do
            {
                generatedWarriorCode = numberGenerator.GenerateNumberBetween(0, 2);

                System.Threading.Thread.Sleep(10); // improves random generation
            }
            while (generatedWarriorCode == lastWarriorCode);

            lastWarriorCode = generatedWarriorCode;

            return generatedWarriorCode;
        }
    }
}