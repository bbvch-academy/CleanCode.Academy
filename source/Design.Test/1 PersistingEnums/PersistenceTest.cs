// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Design.PersistingEnums
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class PersistenceTest
    {
        private Persistence testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new Persistence();
        }

        [Test]
        public void StoresAPerson()
        {
            const string Name = "Clean Coder";
            var person = new Person { Name = Name, Title = Titles.Sir };

            this.testee.Save(person);
            Person loadedPerson = this.testee.Load(Name);

            loadedPerson.ShouldBeEquivalentTo(new Person { Name = person.Name, Title = person.Title });
        }
    }
}