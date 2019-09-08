using System;
using BikeShopAPI.Models;
using BikeShopAPI.Services.Order;
using FluentAssertions;
using Xunit;

namespace BikeShopAPI.Tests
{
    public class TestOrderService
    {
        private readonly OrderService _orderService;
        
        public TestOrderService()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public void GetAllOrdersForCustomer_Gets_Correct_Number_Of_Customer_Orders_Given_Customer()
        {
            var customer = new Customer() {
                Id = 232
            };

            var customerOrders = _orderService.GetAllOrdersForCustomer(customer);

            customerOrders.Count.Should().Be(2);
        }
        
        [Fact]
        public void GetCustomerTotalPaidUsd_Is_Sum_Of_All_Paid_Orders_Given_Customer()
        {
            var customer = new Customer() {
                Id = 232
            };

            var customerPaidUsd = _orderService.GetCustomerTotalPaidUsd(customer);

            customerPaidUsd.Should().Be(60.0M);
        }
    }
}