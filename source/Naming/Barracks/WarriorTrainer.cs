// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarriorBuilder.cs" company="bbv Software Services AG">
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
//   Defines the WarriorBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.Barracks
{
    using System;

    using CleanCode.Naming.Warriors;
    using CleanCode.Naming.Weapons;

    /// <summary>
    /// Trains new warriors
    /// </summary>
    public class WarriorTrainer
    {
        /// <summary>
        /// The i
        /// </summary>
        private readonly Instructor i;

        /// <summary>
        /// The c
        /// </summary>
        private static int c = -1;

        /// <summary>
        /// The a
        /// </summary>
        private double a;

        /// <summary>
        /// The d
        /// </summary>
        private double d;

        /// <summary>
        /// The h
        /// </summary>
        private int h;

        /// <summary>
        /// The w
        /// </summary>
        private Weapon w;

        /// <summary>
        /// Prevents a default instance of the <see cref="WarriorTrainer" /> class from being created.
        /// </summary>
        /// <param name="i2">The i2.</param>
        private WarriorTrainer(Instructor i2)
        {
            i = i2;

            a = 1;
            d = 1;
            h = 1;
        }

        /// <summary>
        /// Trains a random warrior.
        /// </summary>
        /// <returns>A random warrior trainer.</returns>
        public static WarriorTrainer trainRandom()
        {
            var t = calculateTrainerCode();

            switch (t)
            {
                case 0:
                    return trainNewSamurai();
                case 1:
                    return trainNewGreek();
                case 2:
                    return trainNewElb();
                default:
                    throw new InvalidOperationException("something went terribly wrong...");
            }
        }

        /// <summary>
        /// Trains the new samurai.
        /// </summary>
        /// <returns>new samurai trainer</returns>
        public static WarriorTrainer trainNewSamurai()
        {
            return new WarriorTrainer(new Sensei());
        }

        /// <summary>
        /// Trains the new elf.
        /// </summary>
        /// <returns>new elf Lord</returns>
        public static WarriorTrainer trainNewElb()
        {
            return new WarriorTrainer(new Herdir());
        }

        /// <summary>
        /// Trains the new greek.
        /// </summary>
        /// <returns>new philosopher</returns>
        public static WarriorTrainer trainNewGreek()
        {
            return new WarriorTrainer(new Philosopher());
        }

        /// <summary>
        /// Exercises the attack skills.
        /// </summary>
        /// <param name="a2">The new attack skills.</param>
        public WarriorTrainer exerciseAttackSkills(double a2)
        {
            a = a2;

            return this;
        }

        /// <summary>
        /// Practices the defense abilities.
        /// </summary>
        /// <param name="d2">The new defense abilities.</param>
        public WarriorTrainer practiceDefenseAbilities(double d2)
        {
            d = d2;

            return this;
        }

        /// <summary>
        /// Measures the lack of stamina.
        /// </summary>
        /// <param name="h2">The measured lack of stamina.</param>
        public WarriorTrainer measureLackOfStamina(int h2)
        {
            h = h2;

            return this;
        }

        /// <summary>
        /// Equips the specified weapon.
        /// </summary>
        /// <param name="w2">The weapon.</param>
        public WarriorTrainer equip(Weapon w2)
        {
            w = w2;

            return this;
        }

        /// <summary>
        /// Recruits this instance.
        /// </summary>
        /// <returns>recruits the warrior</returns>
        public Warrior recruit()
        {
            Warrior w3 = i.instruct(a, d, h);

            if (w != null)
            {
                w3.TakeKillingTool(w);
            }

            return w3;
        }

        /// <summary>
        /// Calculates the next trainer code which is different than the last one.
        /// </summary>
        /// <returns>the next trainer code.</returns>
        private static int calculateTrainerCode()
        {
            var u = new Utility();
            int c2;

            do
            {
                c2 = u.GenerateNumber(0, 2);
            }
            while (c2 == c);

            c = c2;

            return c2;
        }
    }
}