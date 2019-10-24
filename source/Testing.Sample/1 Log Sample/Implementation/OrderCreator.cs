// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderCreator.cs" company="bbv Software Services AG">
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

// ReSharper disable NotResolvedInText

namespace CleanCode.Testing.Sample.Implementation
{
    using System;
    using System.Linq;

    public class OrderCreator
    {
        private readonly ILogger logger;

        public OrderCreator(ILogger logger)
        {
            this.logger = logger;
        }

        public void CreateOrder(OrderRequest order)
        {
            this.logger.LogStartingOrderCreation();

            try
            {
                var command = new OrderCreationCommand(this.logger, order);
                command.Execute();

                this.logger.LogOrderCreationSuccessfull();
            }
            catch (Exception exception)
            {
                this.logger.LogOrderCreationFailed(exception);
            }
        }

        private class OrderCreationCommand
        {
            private const int OrderAmountLimit = 150;

            private readonly ILogger logger;
            private readonly OrderRequest order;

            public OrderCreationCommand(ILogger logger, OrderRequest order)
            {
                this.logger = logger;
                this.order = order;
            }

            public void Execute()
            {
                this.EnsureOrderNotNull();
                this.EnsureCustomerNameIsSet();
                this.EnsureCustomerAddressIsSet();

                this.WarnIfOrderAmountOver(OrderAmountLimit);

                this.ProcessOrder();
            }

            private void EnsureOrderNotNull()
            {
                if (this.order == null)
                {
                    this.logger.LogOrderNotSet();

                    throw new ArgumentNullException("order");
                }
            }

            private void EnsureCustomerNameIsSet()
            {
                if (string.IsNullOrEmpty(this.order.CustomerName))
                {
                    this.logger.LogCustomerNameNotSet(this.order);

                    throw new ArgumentException("customer name not set.");
                }
            }

            private void EnsureCustomerAddressIsSet()
            {
                if (string.IsNullOrEmpty(this.order.CustomerAddress))
                {
                    this.logger.LogCustomerAddressNotSet(this.order);

                    throw new ArgumentException("customer address not set.");
                }
            }

            private void WarnIfOrderAmountOver(int limit)
            {
                decimal orderAmount = this.CalculateOrderAmount();

                if (orderAmount > limit)
                {
                    this.logger.LogOrderExceedsLimit(this.order, orderAmount, limit);
                }
            }

            private decimal CalculateOrderAmount()
            {
                return this.order.Items.Sum(x => x.Price);
            }

            private void ProcessOrder()
            {
                this.logger.LogProcessingOrder(this.order);
            }
        }
    }
}