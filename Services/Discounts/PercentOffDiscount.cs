using BikeShopAPI.Models;

namespace BikeShopAPI.Services.Discounts {
    /// <summary>
    ///     Calculates a "Percent Off" discount
    /// </summary>
    public class PercentOffDiscount : Discount {
        private readonly decimal _percentOffAmount;

        public PercentOffDiscount(decimal percentOffAmount) {
            _percentOffAmount = percentOffAmount;
        }

        public override decimal Amount => _percentOffAmount;

        public override decimal CalculateDiscountedTotalFor(RepairOrder order) {
            return order.ChargesUsd * _percentOffAmount;
        }
    }
}