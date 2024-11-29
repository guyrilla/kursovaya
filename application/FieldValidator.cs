using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public static class FieldValidator
    {
        static public bool ValidateBasicAccountDetails(string preRegisterEmail, string preRegisterLogin, 
            string preRegisterPassword)
        {
            if (string.IsNullOrWhiteSpace(preRegisterEmail) ||
                !System.Text.RegularExpressions.Regex.IsMatch(preRegisterEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }
            if (!IsAllEnglish(preRegisterEmail) ||
                !IsAllEnglish(preRegisterLogin) ||
                !IsAllEnglish(preRegisterPassword))
            {
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(preRegisterLogin, @"\d"))
            {
                return false;
            }
            using (ComputerShopEntities context = new ComputerShopEntities())
            {
                var existingAccount = context.Accounts_.FirstOrDefault(a => a.Email == preRegisterEmail);
                if (existingAccount != null)
                {
                    return false;
                }
            }

            return true;
        }

        static private bool IsAllEnglish(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9@._-]+$");
        }
        static public bool ValidateSecondaryAccountDetails(string preRegisterName, string preRegisterLastName,
            string preRegisterSurName)
        {
            return ValidateCyrillicName(preRegisterName) &&
                   ValidateCyrillicName(preRegisterLastName) &&
                   ValidateCyrillicName(preRegisterSurName);
        }

        static private bool ValidateCyrillicName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return System.Text.RegularExpressions.Regex.IsMatch(name, @"^[А-ЯЁ][а-яё\s-]*$");
        }
    }
}
