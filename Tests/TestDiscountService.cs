using BikeShopAPI.Models;
using BikeShopAPI.Services.Discounts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BikeShopAPI.Tests {
    public class TestDiscountService {
        private readonly DiscountService _discountService;

        public TestDiscountService() {
            var mockLogger = new Mock<ILogger<DiscountService>>();
            var loggerForTest = mockLogger.Object;
            _discountService = new DiscountService(loggerForTest);
        }

        [Fact]
        public void PercentOffDiscount_AdjustsChargesUsd_GivenRepairOrder() {
            var order = new RepairOrder {
                Id = 232,
                ChargesUsd = 100.00m
            };

            var discount = new PercentOffDiscount(0.5m);
            _discountService.ApplyDiscount(order, discount);
            order.ChargesUsd.Should().Be(50m);
        }

        [Fact]
        public void DollarOffDiscount_AdjustsChargesUsd_GivenRepairOrder() {
            var order = new RepairOrder {
                Id = 232,
                ChargesUsd = 100.00m
            };

            var discount = new DollarOffDiscount(5);
            _discountService.ApplyDiscount(order, discount);
            order.ChargesUsd.Should().Be(95m);
        }

        [Fact]
        public void DollarOffDiscount_ExceedingTotalCostDoesNotCreateNegativeChargesUsd_GivenRepairOrder() {
            var order = new RepairOrder {
                Id = 232,
                ChargesUsd = 5.00m
            };

            var discount = new DollarOffDiscount(10);
            _discountService.ApplyDiscount(order, discount);
            order.ChargesUsd.Should().Be(0);
        }
    }
}