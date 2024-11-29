using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class CustomClient : IEntityRegister
    {
        public int preRegisterRole { get; set; }
        public string preRegisterEmail { get; set; }
        public string preRegisterPassword { get; set; }
        public string preRegisterLogin { get; set; }
        public string preRegisterName { get; set; }
        public string preRegisterLastName { get; set; }
        public string preRegisterSurName { get; set; }
        public void EnterBasicAccountDetails(string enteredEmail, string enteredLogin, string enteredPassword)
        {
            preRegisterEmail = enteredEmail;
            preRegisterPassword = enteredPassword;
            preRegisterLogin = enteredLogin;
        }
        public void EnterIntoDB()
        {
            using (ComputerShopEntities computerShopEntities = new ComputerShopEntities())
            {
                SHA256 sHA256 = SHA256.Create();
                byte[] hashedPassword = sHA256.ComputeHash(Encoding.UTF8.GetBytes(preRegisterPassword));

                Accounts_ newAccount = new Accounts_
                {
                    Email = preRegisterEmail,
                    Login = preRegisterLogin,
                    Password = new byte[hashedPassword.Length]
                };
                Array.Copy(hashedPassword, newAccount.Password, hashedPassword.Length);
                newAccount.Role = preRegisterRole;
                computerShopEntities.Accounts_.Add(newAccount);
                computerShopEntities.SaveChanges();
                Clients_ newClient = new Clients_()
                {
                    AccountID = newAccount.ID,
                    FirstName = preRegisterName,
                    SecondName = preRegisterLastName,
                    SurName = preRegisterSurName,
                };
                computerShopEntities.Clients_.Add(newClient);
                computerShopEntities.SaveChanges();
            }
        }

        public void EnterSecondaryAccountDetails(string enteredName, string enteredLastName, string enteredSurname)
        {
            preRegisterName = enteredName;
            preRegisterLastName = enteredLastName;
            preRegisterSurName = enteredSurname;
        }
        public void FlushAccountDetails()
        {
            preRegisterEmail = null;
            preRegisterPassword = null;
            preRegisterLogin = null;
            preRegisterName = null;
            preRegisterLastName = null;
            preRegisterSurName = null;
        }
        public void SetRole()
        {
            preRegisterRole = 1;
        }
    }
}

