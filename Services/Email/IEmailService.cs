using System.Collections.Generic;
using BikeShopAPI.Models;

namespace BikeShopAPI.Services.Email
{
    public interface IEmailService
    {
        void SendEmailToCustomers(Email email, IEnumerable<Customer> customers);
        void SubscribeCustomer(Customer customer, long campaignId);
    }
}