// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BattleFieldHandler.cs" company="bbv Software Services AG">
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
//   the battle field
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming
{
    using System;
    using System.Collections.Generic;

    using CleanCode.Naming.Warriors;

    /// <summary>
    /// the battle field
    /// </summary>
    public class BattleFieldHandler
    {
        /// <summary>
        /// Warriors of team 1
        /// </summary>
        private readonly IList<Warrior> team1;

        /// <summary>
        /// Warriors of team 2
        /// </summary>
        private readonly IList<Warrior> team2;

        /// <summary>
        /// The current round
        /// </summary>
        private int currentRound;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleFieldHandler" /> class.
        /// </summary>
        public BattleFieldHandler()
        {
            this.team1 = new List<Warrior>();
            this.team2 = new List<Warrior>();
            this.currentRound = 0;
        }

        /// <summary>
        /// Gets the number of rounds.
        /// </summary>
        /// <value>
        /// The number of rounds.
        /// </value>
        public int NumberOfRounds
        {
            get
            {
                return this.team1.Count < this.team2.Count ? this.team1.Count : this.team2.Count;
            }
        }

        /// <summary>
        /// Assigns the warrior to team 1.
        /// </summary>
        /// <param name="warrior1">The warrior 1.</param>
        public void AssignWarriorToTeam1(Warrior warrior1)
        {
            this.team1.Add(warrior1);
        }

        /// <summary>
        /// Assigns the warrior to team 2.
        /// </summary>
        /// <param name="warrior2">The warrior 2.</param>
        public void AssignWarriorToTeam2(Warrior warrior2)
        {
            this.team2.Add(warrior2);
        }

        /// <summary>
        /// Lets the them fight.
        /// </summary>
        /// <param name="i">The i.</param>
        public FightEnd LetThemFight(int i)
        {
            this.AskReferee(i);

            Warrior warrior1 = this.team1[i];
            Warrior warrior2 = this.team2[i];

            warrior1.CombatLevelText();
            warrior2.CombatLevelText();

            Console.WriteLine();
            Console.WriteLine(warrior1.CombatLevelText());
            Console.WriteLine("                vs.");
            Console.WriteLine(warrior2.CombatLevelText());
            Console.WriteLine();

            // A draw will be ignored -> advantage team2
            return new FightEnd(warrior1.CombatLevel > warrior2.CombatLevel);
        }

        /// <summary>
        /// Asks the referee if a fight is possible.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <exception cref="System.InvalidOperationException">If no fight is possible.</exception>
        private void AskReferee(int i)
        {
            if (i >= this.NumberOfRounds)
            {
                string message = string.Format("round {0}: there are not enough warriors for a fight...", this.currentRound);

                throw new InvalidOperationException(message);
            }
        }
    }
}