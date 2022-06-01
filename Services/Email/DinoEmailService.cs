using System;
using System.Collections.Generic;
using BikeShopAPI.Models;

namespace BikeShopAPI.Services.Email {
    /// <summary>
    ///     Email client for the API - Sends emails to Customers
    /// </summary>
    public interface IEmailService {
        /// <summary>
        ///     Sends an Email to a List of Customers
        /// </summary>
        /// <param name="email"></param>
        /// <param name="customers"></param>
        void SendEmailToCustomers(Email email, IEnumerable<Customer> customers);

        /// <summary>
        ///     Subscribes a Customer to an Email Campaign
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="campaignId"></param>
        void SubscribeCustomer(Customer customer, long campaignId);
    }

    public class DinoEmailService : IEmailService {
        private readonly EmailValidator _validator;
        private readonly List<string> _invalidEmails;

        private IEnumerable<Customer> _subscribedCustomers;

        public DinoEmailService() {
            _subscribedCustomers = new List<Customer>();
            _invalidEmails = new List<string>();
            _validator = new EmailValidator();
        }

        /// <inheritdoc />
        public void SendEmailToCustomers(Email email, IEnumerable<Customer> customers) {
            var toAddresses = new List<string>();

            foreach (var customer in customers) {
                if (!IsValidEmail(customer.Email)) {
                    _invalidEmails.Add(customer.Email);
                    continue;
                }

                toAddresses.Add(customer.Email);
            }

            email.ToAddresses = toAddresses;

            SendEmail(email);
        }

        /// <inheritdoc />
        public void SubscribeCustomer(Customer customer, long campaignId) {
            var isValidEmail = IsValidEmail(customer.Email);

            if (!isValidEmail) return;

            var email = new Email {
                Message = "Welcome!",
                ToAddresses = new List<string> { customer.Email },
                FromAddress = "donotreply@portalmedia.com"
            };

            SendEmail(email);
        }

        private static void SubscribeCustomer(long customerId, long campaignId) {
            Console.Write($"Customer {customerId} Subscribed to campaign {campaignId}");
        }

        private static void SendEmail(Email email) {
            Console.Write("Email Sent!");
            Console.Write(email.Message);
        }

        private bool IsValidEmail(string emailAddress) {
            return _validator.IsValidEmail(emailAddress);
        }
    }
}