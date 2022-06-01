using BikeShopAPI.Models;
using Microsoft.Extensions.Logging;

namespace BikeShopAPI.Services.Discounts {
    /// <summary>
    ///     Handles Order Discount Logic
    /// </summary>
    public interface IDiscountService {
        /// <summary>
        ///     Given a RepairOrder and a Discount, returns a mutated version of the given RepairOrder
        ///     with the discount applied
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="discount">Discount instance</param>
        /// <returns></returns>
        public void ApplyDiscount(RepairOrder order, Discount discount);
    }

    /// <inheritdoc />
    public class DiscountService : IDiscountService {
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(ILogger<DiscountService> logger) {
            _logger = logger;
        }

        public void ApplyDiscount(RepairOrder order, Discount discount) {
            discount.ApplyTo(order);

            _logger.LogInformation(
                "Applying discount to Order {OrderId}", order.Id
            );
        }
    }
}