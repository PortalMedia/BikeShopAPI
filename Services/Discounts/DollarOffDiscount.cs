using BikeShopAPI.Models;

namespace BikeShopAPI.Services.Discounts {
    public class DollarOffDiscount : Discount {
        private readonly decimal _dollarOffAmount;

        public DollarOffDiscount(decimal dollarOffAmount) {
            _dollarOffAmount = dollarOffAmount;
        }

        public override decimal Amount => _dollarOffAmount;

        public override decimal CalculateForOrder(RepairOrder order) {
            return order.ChargesUsd - _dollarOffAmount;
        }
    }
}