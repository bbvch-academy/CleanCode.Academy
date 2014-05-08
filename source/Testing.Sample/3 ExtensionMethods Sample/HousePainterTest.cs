// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HousePainterTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Testing.Sample
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Xml.Linq;

    using CleanCode.Testing.Sample.Implementation;

    using NUnit.Framework;

    [TestFixture]
    public class HousePainterTest
    {
        [Test]
        public void PaintsTheRoof()
        {
            HousePainter testee = CreateTestee();

            testee.ChangeColorOfRoof(Color.Red);
            XDocument result = testee.GetResult();

            // result.RoofElement().ColorAttributeValue().Should().Be(Color.Red);
            Console.WriteLine(result);
        }

        private static HousePainter CreateTestee()
        {
            return new HousePainter(CreateSampleHouseWith2Windows());
        }

        private static House CreateSampleHouseWith2Windows()
        {
            return new House
            {
                FacadeColor = Color.Gray,
                FrontDoor = new FrontDoor { Color = Color.Gray, Height = 2.1d, Width = 1d },
                Height = 5,
                NumberOfFloors = 2,
                Roof = new Roof { Color = Color.Gray, Size = 100d },
                Width = 15,
                Windows = new Collection<Window>
                {
                    new Window { BorderColor = Color.Gray, Dimension = new SizeF(1, 1.4f) },
                    new Window { BorderColor = Color.Gray, Dimension = new SizeF(1, 1.4f) }
                }
            };
        }
    }
}