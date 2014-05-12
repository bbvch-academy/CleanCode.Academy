// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Score.cs" company="bbv Software Services AG">
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
    public class Score
    {
        public int Team1 { get; private set; }

        public int Team2 { get; private set; }

        public void ResetScore()
        {
            this.Team1 = 0;
            this.Team2 = 0;
        }

        public void Team1Scores()
        {
            this.Team1++;
        }

        public void Team2Scores()
        {
            this.Team2++;
        }
    }
}