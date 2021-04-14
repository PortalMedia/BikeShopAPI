using System.Collections.Generic;
using System.IO;
using System.Linq;
using BikeShopAPI.Models;
using Newtonsoft.Json;

namespace BikeShopAPI.Services.Order
{
    public class OrderService
    {
        private readonly string _sampleData;
        
        /// <summary>
        /// Handles all business logic for processing customer orders
        /// </summary>
        public OrderService()
        {
            var sampleDataPath = Path.Join(System.Environment.CurrentDirectory, "SampleData", "CustomerOrders.json");
            _sampleData = File.ReadAllText(sampleDataPath);        
        }
        
        /// <summary>
        /// Gets all Orders for the given Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<RepairOrder> GetAllOrdersForCustomer(Customer customer)
        {
            var repairOrders = JsonConvert.DeserializeObject<List<RepairOrder>>(_sampleData);
            
            var customerOrders = repairOrders
                .Where(order => order.Bike.Owner.Id == customer.Id)
                .ToList();

            return customerOrders;
        }
        
        /// <summary>
        /// Provides a USD sum of customer orders where the PaidStatus is "Paid"
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public decimal GetCustomerTotalPaidUsd(Customer customer)
        {
            var repairOrders = JsonConvert.DeserializeObject<List<RepairOrder>>(_sampleData);
            
            return repairOrders
                .Where(order => order.Bike.Owner.Id == customer.Id && order.PaidStatus == PaidStatus.Paid)
                .Sum(order => order.ChargesUsd);
        }
    }
}