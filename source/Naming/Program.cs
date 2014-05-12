// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="bbv Software Services AG">
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

    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new GameEngine();

            game.Initialize();
            game.SetupTeams();
            
            Score score = game.RunGame();

            WriteGameResultToConsole(score);

            Console.Write("Press <ENTER> to exit");
            Console.ReadLine();
        }

        private static void WriteGameResultToConsole(Score score)
        {
            Console.WriteLine(" ");
            Console.WriteLine("      Team1  vs  Team2");
            Console.WriteLine("        {0}          {1}", score.Team1, score.Team2);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    }
}
