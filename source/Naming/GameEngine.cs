// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="bbv Software Services AG">
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
//   Defines the GameEngine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming
{
    using System;

    using CleanCode.Naming.Barracks;
    using CleanCode.Naming.Factory;
    using CleanCode.Naming.Store;
    using CleanCode.Naming.Warriors;
    using CleanCode.Naming.Weapons;

    /// <summary>
    /// The Game Engine
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// The number of turns.
        /// </summary>
        private const int T = 5;

        /// <summary>
        /// The _weapon factory.
        /// </summary>
        private readonly WeaponCreator _weaponCreator;

        /// <summary>
        /// The _storage manager.
        /// </summary>
        private readonly StorageManager _storageManager;

        /// <summary>
        /// The _battle field handler
        /// </summary>
        private readonly BattleFieldHandler _battleFieldHandler;

        /// <summary>
        /// The _score manager
        /// </summary>
        private readonly ScoreManager _scoreManager;

        /// <summary>
        /// The _utility
        /// </summary>
        private readonly Utility _utility;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        public GameEngine()
        {
            this._weaponCreator = new WeaponCreator();
            this._storageManager = new StorageManager();
            this._battleFieldHandler = new BattleFieldHandler();
            this._scoreManager = new ScoreManager();
            this._utility = new Utility();
        }

        /// <summary>
        /// Prepares the new game.
        /// </summary>
        public void PrepareNewGame()
        {
            this._scoreManager.NewScore();
            this.NewWeaponsIntoTheStorage();

            Iterator itr = this._storageManager.CreateIterationUnit();

            Console.WriteLine("weapons in the storage:");
            while (itr.hasNext())
            {
                Console.WriteLine(" " + itr.next().Label);
            }
        }

        /// <summary>
        /// Recruits the warriors.
        /// </summary>
        public void RecruitWarriors()
        {
            for (int index = 0; index < T; index++)
            {
                var recruit1 = this.recruit();
                var recruit2 = this.recruit();

                this._battleFieldHandler.AssignWarriorToTeam1(recruit1);
                this._battleFieldHandler.AssignWarriorToTeam2(recruit2);
            }
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public ScoreManager RunGame()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("NEW GAME STARTS:");

            for (int i = 0; i < this._battleFieldHandler.NumberOfRounds; i++)
            {
                FightEnd end = this._battleFieldHandler.LetThemFight(i);

                if (end.W1Killed)
                {
                    this._scoreManager.Team2Won();
                }
                else
                {
                    this._scoreManager.Team1Won();
                }
            }

            return this._scoreManager;
        }

        /// <summary>
        /// News the weapons into the storage.
        /// </summary>
        private void NewWeaponsIntoTheStorage()
        {
            for (int i = 0; i < T * 2; i++)
            {
                Weapon theNewWeapon = this._weaponCreator.ForgeNewWeapon();

                this._storageManager.DeliverToInventory(theNewWeapon);
            }
        }

        /// <summary>
        /// Recruits this instance.
        /// </summary>
        private Warrior recruit()
        {
            return WarriorTrainer.trainRandom()
                .exerciseAttackSkills(this.attack())
                .measureLackOfStamina(this.staminaDrawback())
                .practiceDefenseAbilities(this.defensiveness())
                .equip(this._storageManager.TakeFromInventory())
                .recruit();
        }

        /// <summary>
        /// Attacks this instance.
        /// </summary>
        private int attack()
        {
            return _utility.GenerateNumber(1, 4);
        }

        /// <summary>
        /// Staminas the drawback.
        /// </summary>
        private int staminaDrawback()
        {
            return _utility.GenerateNumber(2, 7);
        }

        /// <summary>
        /// Defensivenesses this instance.
        /// </summary>
        private int defensiveness()
        {
            return _utility.GenerateNumber(7, 12);
        }
    }
}