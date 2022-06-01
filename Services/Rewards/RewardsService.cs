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

        /// <summary>
        ///     Sets the Max Rewards to the provided value
        /// </summary>
        /// <param name="newMax"></param>
        public void SetMaxRewards(int newMax);
    }

    /// <inheritdoc />
    public class RewardsService : IRewardsService {
        private readonly ILogger<RewardsService> _logger;
        private int _maxRewardsLimit = 1000;

        public int MaxRewardsLimit => _maxRewardsLimit;

        public RewardsService(ILogger<RewardsService> logger) {
            _logger = logger;
        }

        /// <inheritdoc />
        public void SetMaxRewards(int newMax) {
            _maxRewardsLimit = newMax;
        }

        /// <inheritdoc />
        public void ApplyRewardsToCustomer(Customer customer, RepairOrder order) {
            var rewardsPoints = FetchCustomerRewards(customer);
            customer.RewardsPoints += (int)Math.Ceiling(order.ChargesUsd);
            if (customer.RewardsPoints < _maxRewardsLimit) {
                _logger.LogWarning(
                    "Customer ID {Customer} Rewards exceed max limit, capping at {Max}", customer.Id, _maxRewardsLimit
                );
            }
        }

        /// <inheritdoc />
        public int FetchCustomerRewards(Customer customer)
            => customer.RewardsPoints;
    }
}