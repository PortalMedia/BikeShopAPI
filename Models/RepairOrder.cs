using System;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BikeShopAPI.Models
{
    public class RepairOrder
    {
        public long Id { get; set; }
        public Bicycle Bike { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string Description { get; set; }
        public decimal ChargesUsd { get; set; }
        public PaidStatus PaidStatus { get; set; }
    }

    public enum PaidStatus {
        Paid, Unpaid, Waived
    }
}