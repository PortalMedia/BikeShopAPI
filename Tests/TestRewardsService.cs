using BikeShopAPI.Models;
using BikeShopAPI.Services.Rewards;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BikeShopAPI.Tests {
    public class TestRewardsService {
        private readonly RewardsService _rewardService;

        public TestRewardsService() {
            var mockLogger = new Mock<ILogger<RewardsService>>();
            var loggerForTest = mockLogger.Object;
            _rewardService = new RewardsService(loggerForTest);
        }

        [Fact]
        public void ApplyRewardsToCustomer_IfOverMaxLimit_CapsCustomerRewards() {
            _rewardService.SetMaxRewards(1000);

            // Set up a customer with 900 rewards
            var customer = new Customer {
                Id = 9384,
                RewardsPoints = 999
            };

            // Create an order with $200 Charges
            var order = new RepairOrder{
                ChargesUsd = 200m
            };

            _rewardService.ApplyRewardsToCustomer(customer, order);

            customer.RewardsPoints.Should().Be(_rewardService.MaxRewardsLimit);
        }
    }
}