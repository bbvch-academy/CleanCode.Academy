// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoreManager.cs" company="bbv Software Services AG">
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
//   Manages the score.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming
{
    /// <summary>
    /// Manages the score.
    /// </summary>
    public class ScoreManager
    {
        /// <summary>
        /// Gets the team1.
        /// </summary>
        /// <value>
        /// The team1.
        /// </value>
        public int Team1 { get; private set; }

        /// <summary>
        /// Gets the team2.
        /// </summary>
        /// <value>
        /// The team2.
        /// </value>
        public int Team2 { get; private set; }

        /// <summary>
        /// Releases the score.
        /// </summary>
        public void NewScore()
        {
            this.Team1 = 0;
            this.Team2 = 0;
        }

        /// <summary>
        /// Team1s the won.
        /// </summary>
        public void Team1Won()
        {
            this.Team1++;
        }

        /// <summary>
        /// Team2s the won.
        /// </summary>
        public void Team2Won()
        {
            this.Team2++;
        }
    }
}