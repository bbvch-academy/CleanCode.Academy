// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FightResult.cs" company="bbv Software Services AG">
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
    public class FightResult
    {
        public FightResult(bool warriorOfTeam1Wins)
        {
            this.WarriorOfTeam1Won = warriorOfTeam1Wins;
        }

        public bool WarriorOfTeam1Won { get; private set; }

        public bool WarriorOfTeam2Won
        {
            get
            {
                return !this.WarriorOfTeam1Won;
            }
        }
    }
}