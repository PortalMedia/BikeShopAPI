using System.Text.RegularExpressions;
using static System.String;

namespace BikeShopAPI.Services.Email
{
    public class EmailValidator
    {
        // Regex Matches Email
        private const string ValidEmailAddressPattern 
            = "^[a-zA-Z1-9._+-]+@[a-zA-Z1-9.-]+\\.[a-zA-Z0-9-.]+$";
        
        /// <summary>
        /// Returns true if the provided email matches a valid email pattern
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            if (IsNullOrEmpty(email)) return false;
            var regex = new Regex(ValidEmailAddressPattern);
            return regex.IsMatch(email);

        }
    }
}