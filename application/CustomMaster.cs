using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class CustomMaster : Masters_, IMasterEdit, IEntityRegister
    {
        public string PreparedToEditName { get; set; }
        public string PreparedToEditImagePath { get; set; }
        public string PreparedSecondNameEdit { get; set; }
        public string PreparedSurNameEdit { get; set; }
        public byte PreparedWorkExperienceEdit { get; set; }
        public string preRegisterEmail { get; set; }
        public string preRegisterPassword { get; set; }
        public string preRegisterLogin { get; set; }
        public string preRegisterName { get; set; }
        public string preRegisterLastName { get; set; }
        public string preRegisterSurName { get; set; }
        public int preRegisterRole { get; set; }
        public void EditSecondName(string secondName)
        {
            PreparedSecondNameEdit = secondName;
        }
        public void EditSurName(string surName)
        {
            PreparedSurNameEdit = surName;
        }
        public void EditWorkExperience(byte workExperience)
        {
            PreparedWorkExperienceEdit = workExperience;
        }
        public void SaveEntity(ComputerShopEntities context)
        {
            var masterFromDB = context.Masters_.Find(this.ID);
            if (!string.IsNullOrWhiteSpace(PreparedToEditName))
            {
                masterFromDB.FirstName = PreparedToEditName;
            }
            if (!string.IsNullOrWhiteSpace(PreparedWorkExperienceEdit.ToString()))
            {
                masterFromDB.WorkExperience = PreparedWorkExperienceEdit;
            }
            masterFromDB.ImagePath = PreparedToEditImagePath;
            context.SaveChanges();
            PrepareReset();
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
                Masters_ newMaster = new Masters_()
                {
                    AccountID = newAccount.ID,
                    FirstName = preRegisterName,
                    SecondName = preRegisterLastName,
                    SurName = preRegisterSurName,
                };
                computerShopEntities.Masters_.Add(newMaster);
                computerShopEntities.SaveChanges();
            }
        }
        private void PrepareReset()
        {
            PreparedToEditName = null;
            PreparedToEditImagePath = null;
            PreparedSecondNameEdit = null;
            PreparedSurNameEdit = null;
            PreparedWorkExperienceEdit = 0;
        }
        public void EditImage(string imagePath)
        {
            PreparedToEditImagePath = imagePath;
        }
        public void EditName(string name)
        {
            PreparedToEditName = name;
        }
        public void EnterBasicAccountDetails(string enteredEmail, string enteredLogin, string enteredPassword)
        {
            preRegisterEmail = enteredEmail;
            preRegisterLogin = enteredLogin;
            preRegisterPassword = enteredPassword;
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
            preRegisterRole = 2;
        }
    }
}
