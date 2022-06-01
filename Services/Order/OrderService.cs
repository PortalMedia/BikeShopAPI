using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BikeShopAPI.Models;
using Newtonsoft.Json;

namespace BikeShopAPI.Services.Order {
    /// <summary>
    ///     Handles logic for fetching Customer Order data
    /// </summary>
    public interface IOrderService {
        /// <summary>
        ///     Gets all Orders for the given Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<RepairOrder> GetAllOrdersForCustomer(Customer customer);

        /// <summary>
        ///     Provides a USD sum of Customer Orders Where the PaidStatus is "Paid"
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public decimal GetCustomerTotalPaidUsd(Customer customer);
    }

    /// <inheritdoc />
    public class OrderService : IOrderService {
        private readonly string _sampleData;

        public OrderService() {
            var sampleDataPath = Path.Join(
                Environment.CurrentDirectory,
                "SampleData",
                "CustomerOrders.json"
            );
            _sampleData = File.ReadAllText(sampleDataPath);
        }

        /// <inheritdoc />
        public List<RepairOrder> GetAllOrdersForCustomer(Customer customer) {
            var repairOrders = JsonConvert.DeserializeObject<List<RepairOrder>>(_sampleData);

            var customerOrders = repairOrders
                .Where(order => order.Bike.Id == customer.Id)
                .ToList();

            return customerOrders;
        }

        /// <inheritdoc />
        public decimal GetCustomerTotalPaidUsd(Customer customer) {
            var repairOrders = JsonConvert.DeserializeObject<List<RepairOrder>>(_sampleData);

            return repairOrders
                .Where(order => order.Bike.Owner.Id == customer.Id)
                .Sum(order => order.ChargesUsd);
        }
    }
}