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

        public override decimal ApplyTo(RepairOrder order) {
            var discountAmount = order.ChargesUsd * _percentOffAmount;
            var subtotal = order.ChargesUsd - discountAmount;
            return subtotal;
        }
    }
}