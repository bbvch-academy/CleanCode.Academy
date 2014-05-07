// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderCreatorLogExtensionMethods.cs" company="bbv Software Services AG">
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

namespace CleanCode.Testing.Sample.Implementation
{
    using System;
    using System.Globalization;

    public static class OrderCreatorLogExtensionMethods
    {
        public static void LogStartingOrderCreation(this ILogger logger)
        {
            logger.Trace("creating order...");
        }

        public static void LogOrderCreationSuccessfull(this ILogger logger)
        {
            logger.Debug("order succefully created!");
        }

        public static string FormatOrderNotSet()
        {
            return "order is null.";
        }

        public static void LogOrderNotSet(this ILogger logger)
        {
            logger.Error(FormatOrderNotSet());
        }

        public static string FormatCustomerNameNotSet(OrderRequest order)
        {
            return string.Format(CultureInfo.InvariantCulture, "no customer defined in order {0}.", order.Id);
        }

        public static void LogCustomerNameNotSet(this ILogger logger, OrderRequest order)
        {
            logger.Error(FormatCustomerNameNotSet(order));
        }

        public static string FormatCustomerAddressNotSet(OrderRequest order)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "address of customer {0} not defined in order {1}.",
                order.CustomerAddress,
                order.Id);
        }

        public static void LogCustomerAddressNotSet(this ILogger logger, OrderRequest order)
        {
            logger.Error(FormatCustomerAddressNotSet(order));
        }

        public static string FormatOrderExceedsLimit(OrderRequest order, decimal amount, int limit)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "amout of order {0} exceeds the limit of {1} with {2}.",
                order.Id,
                amount,
                limit);
        }

        public static void LogOrderExceedsLimit(this ILogger logger, OrderRequest order, decimal amount, int limit)
        {
            logger.Warn(FormatOrderExceedsLimit(order, amount, limit));
        }

        public static string FormatProcessingOrder(OrderRequest order)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "processing order {0} for customer {1} living in {2}.",
                order.Id,
                order.CustomerName,
                order.CustomerAddress);
        }

        public static void LogProcessingOrder(this ILogger logger, OrderRequest order)
        {
            logger.Info(FormatProcessingOrder(order));
        }

        public static void LogOrderCreationFailed(this ILogger logger, Exception exception)
        {
            logger.Error(exception, "order creation failed!!!");
        }
    }
}