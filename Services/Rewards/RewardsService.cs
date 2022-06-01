using System;
using BikeShopAPI.Models;
using Microsoft.Extensions.Logging;

namespace BikeShopAPI.Services.Rewards {
    /// <summary>
    ///     Handles Customer Rewards Logic
    /// </summary>
    public interface IRewardsService {
        /// <summary>
        ///     Applies rewards point to a customer.  The maximum limit for rewards is 1000
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="order"></param>
        public void ApplyRewardsToCustomer(Customer customer, RepairOrder order);

        /// <summary>
        ///     Fetches rewards points for an existing customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int FetchCustomerRewards(Customer customer);
    }

    /// <inheritdoc />
    public class RewardsService : IRewardsService {
        private readonly ILogger<RewardsService> _logger;

        public RewardsService(ILogger<RewardsService> logger) {
            _logger = logger;
        }

        public void ApplyRewardsToCustomer(Customer customer, RepairOrder order) {
            var rewardsPoints = FetchCustomerRewards(customer);
            customer.RewardsPoints += (int)Math.Ceiling(order.ChargesUsd);
        }

        public int FetchCustomerRewards(Customer customer) {
            return customer.RewardsPoints;
        }
    }
}