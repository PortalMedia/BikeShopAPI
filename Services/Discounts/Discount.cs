using BikeShopAPI.Models;

namespace BikeShopAPI.Services.Discounts {
    public abstract class Discount {
        public abstract decimal Amount { get; }

        /// <summary>
        ///     Abstract ApplyTo method - override in concrete classes
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public abstract decimal CalculateDiscountedTotalFor(RepairOrder order);
    }
}