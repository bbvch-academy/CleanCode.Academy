// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderCreatorLogTest.cs" company="bbv Software Services AG">
//   Copyright (c) 2014 - 2020
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

// ReSharper disable InconsistentNaming

namespace CleanCode.Testing.Sample
{
    using System.Collections.ObjectModel;

    using CleanCode.Testing.Sample.Implementation;

    using FakeItEasy;
    using NUnit.Framework;

    [TestFixture]
    public class OrderCreatorLogTest
    {
        private OrderCreator testee;

        private ILogger logger;

        [SetUp]
        public void SetUp()
        {
            this.logger = A.Fake<ILogger>();

            this.testee = new OrderCreator(this.logger);
        }

        [Test]
        public void LogsAsInfo_WhenProcessingOrder()
        {
            var sampleOrder = new OrderRequest(1, "Donald Duck", "Duckburg", new Collection<OrderItem>());

            this.testee.CreateOrder(sampleOrder);

            A.CallTo(() => this.logger.Info(OrderCreatorLogExtensionMethods.FormatProcessingOrder(sampleOrder)))
                .MustHaveHappened();
        }

        [Test]
        public void LogsAsError_WhenOrderNotSet()
        {
            this.testee.CreateOrder(null);

            A.CallTo(() => this.logger.Error(OrderCreatorLogExtensionMethods.FormatOrderNotSet()))
                .MustHaveHappened();
        }

        [Test]
        public void LogsAsError_WhenCustomerNotSet()
        {
            var orderWithoutCustomer = new OrderRequest(1, null, null, new Collection<OrderItem>());

            this.testee.CreateOrder(orderWithoutCustomer);

            A.CallTo(() => this.logger.Error(OrderCreatorLogExtensionMethods.FormatCustomerNameNotSet(orderWithoutCustomer)))
                .MustHaveHappened();
        }

        [Test]
        public void LogsAsError_WhenCustomerAddressNotSet()
        {
            var orderWithoutCustomerAddress = new OrderRequest(1, "Dagobert Duck", null, new Collection<OrderItem>());

            this.testee.CreateOrder(orderWithoutCustomerAddress);

            A.CallTo(() => this.logger.Error(OrderCreatorLogExtensionMethods.FormatCustomerAddressNotSet(orderWithoutCustomerAddress)))
                .MustHaveHappened();
        }

        [Test]
        public void LogsAsWarning_WhenOrderExceedsAmountLimit()
        {
            const int Limit = 150;
            const decimal AmountFirstItem = 20;
            const decimal AmountSecondItem = 300;
            const decimal Amount = AmountFirstItem + AmountSecondItem;

            OrderItem[] orderItems =
            {
                new OrderItem(12, "Pucks", AmountFirstItem),
                new OrderItem(13, "Skates", AmountSecondItem)
            };
            var orderExceedingAmountLimit = new OrderRequest(1, "Mighty Ducks", "Anaheim", orderItems);

            this.testee.CreateOrder(orderExceedingAmountLimit);

            A.CallTo(() => this.logger.Warn(
                OrderCreatorLogExtensionMethods.FormatOrderExceedsLimit(orderExceedingAmountLimit, Amount, Limit))).MustHaveHappened();
        }
    }
}