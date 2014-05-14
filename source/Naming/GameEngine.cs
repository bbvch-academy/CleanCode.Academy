// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="bbv Software Services AG">
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
// <summary>
//   Defines the GameEngine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming
{
    using System;
    using System.Collections.Generic;

    using CleanCode.Naming.Barracks;
    using CleanCode.Naming.Factory;
    using CleanCode.Naming.Storages;
    using CleanCode.Naming.Warriors;
    using CleanCode.Naming.Weapons;

    public class GameEngine
    {
        private const int WarriorsPerTeam = 5;
        private const int WeaponsInStorage = WarriorsPerTeam * 2;

        private const int MinimalAttackPoints = 1;
        private const int MaximalAttackPointsPossible = 4;

        private const int MinimalHandicapPoints = 2;
        private const int MaximalHandicapPointsPossible = 7;

        private const int MinimalDefensePoints = 7;
        private const int MaximalDefensePointsPossible = 12;

        private readonly WeaponFactory weaponFactory;
        private readonly StorageStack storageStack;
        private readonly BattleField battleField;
        private readonly Score score;
        private readonly NumberGenerator numberGenerator;

        public GameEngine()
        {
            this.weaponFactory = new WeaponFactory();
            this.storageStack = new StorageStack();
            this.battleField = new BattleField();
            this.score = new Score();
            this.numberGenerator = new NumberGenerator();
        }

        public void Initialize()
        {
            this.score.ResetScore();
            this.SetupStorage();

            IEnumerator<IWeapon> weaponEnumerator = this.storageStack.GetEnumerator();

            Console.WriteLine("weapons in the storage:");
            while (weaponEnumerator.MoveNext())
            {
                Console.WriteLine(" " + weaponEnumerator.Current.Name);
            }
        }

        public void SetupTeams()
        {
            for (int i = 0; i < WarriorsPerTeam; i++)
            {
                IWarrior warriorOfTeam1 = this.CreateWarrior();
                IWarrior warriorOfTeam2 = this.CreateWarrior();

                this.battleField.AddToTeam1(warriorOfTeam1);
                this.battleField.AddToTeam2(warriorOfTeam2);
            }
        }

        public Score RunGame()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("NEW GAME STARTS:");

            for (int round = 0; round < this.battleField.RoundCount; round++)
            {
                FightResult result = this.battleField.RunFight(round);

                if (result.WarriorOfTeam2Won)
                {
                    this.score.Team2Scores();
                }
                else
                {
                    this.score.Team1Scores();
                }
            }

            return this.score;
        }

        private void SetupStorage()
        {
            for (int i = 0; i < WeaponsInStorage; i++)
            {
                IWeapon theNewWeapon = this.weaponFactory.ForgeNewWeapon();

                this.storageStack.Push(theNewWeapon);
            }
        }

        private IWarrior CreateWarrior()
        {
            return WarriorBuilder.NewRandom()
                    .WithAttackPoints(this.GenerateAttackPoints())
                    .WithHandicapPoints(this.GenerateHandicapPoints())
                    .WithDefensePoints(this.GenerateDefensePoints())
                    .WithWeapon(this.storageStack.Pop())
                .Build();
        }

        private int GenerateAttackPoints()
        {
            return this.numberGenerator.GenerateNumberBetween(MinimalAttackPoints, MaximalAttackPointsPossible);
        }

        private int GenerateHandicapPoints()
        {
            return this.numberGenerator.GenerateNumberBetween(MinimalHandicapPoints, MaximalHandicapPointsPossible);
        }

        private int GenerateDefensePoints()
        {
            return this.numberGenerator.GenerateNumberBetween(MinimalDefensePoints, MaximalDefensePointsPossible);
        }
    }
}