using BikeShopAPI.Models;

namespace BikeShopAPI.Services.Discounts {
    public abstract class Discount {
        public abstract decimal Amount { get; }

        /// <summary>
        ///     Abstract CalculateForOrder method - override in concrete classes
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public abstract decimal CalculateForOrder(RepairOrder order);
    }
}