// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BattleField.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming
{
    using System;
    using System.Collections.Generic;

    using CleanCode.Naming.Warriors;

    public class BattleField
    {
        private readonly IList<IWarrior> warriorsOfTeam1;
        private readonly IList<IWarrior> warriorsOfTeam2;

        private readonly int currentRound;

        public BattleField()
        {
            this.warriorsOfTeam1 = new List<IWarrior>();
            this.warriorsOfTeam2 = new List<IWarrior>();

            this.currentRound = 0;
        }

        public int RoundCount
        {
            get
            {
                return this.warriorsOfTeam1.Count < this.warriorsOfTeam2.Count ? this.warriorsOfTeam1.Count : this.warriorsOfTeam2.Count;
            }
        }

        public void AddToTeam1(IWarrior warrior1)
        {
            this.warriorsOfTeam1.Add(warrior1);
        }

        public void AddToTeam2(IWarrior warrior2)
        {
            this.warriorsOfTeam2.Add(warrior2);
        }

        public FightResult RunFight(int round)
        {
            this.VerifyRoundValid(round);

            IWarrior firstWarrior = this.warriorsOfTeam1[round];
            IWarrior secondWarrior = this.warriorsOfTeam2[round];

            Console.WriteLine();
            Console.WriteLine(firstWarrior.CombatMessage());
            Console.WriteLine("                vs.");
            Console.WriteLine(secondWarrior.CombatMessage());
            Console.WriteLine();

            // A draw will be ignored -> advantage team2
            return new FightResult(WarriorOfTeam1Wins(firstWarrior, secondWarrior));
        }

        private static bool WarriorOfTeam1Wins(IWarrior warriorOfTeam1, IWarrior warriorOfTeam2)
        {
            return warriorOfTeam1.CombatLevel > warriorOfTeam2.CombatLevel;
        }

        private void VerifyRoundValid(int i)
        {
            if (i >= this.RoundCount)
            {
                string message = string.Format("round {0}: there are not enough warriors for a fight...", this.currentRound);

                throw new InvalidOperationException(message);
            }
        }
    }
}