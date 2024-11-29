using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IEntityRegister
    {
        string preRegisterEmail { get; set; }
        string preRegisterPassword { get; set; }
        string preRegisterLogin { get; set; }
        string preRegisterName { get; set; }
        string preRegisterLastName { get; set; }
        string preRegisterSurName { get; set; }
        int preRegisterRole { get; set; }
        void EnterIntoDB();
        void EnterBasicAccountDetails(string enteredEmail, string enteredLogin, string enteredPassword);
        void EnterSecondaryAccountDetails(string enteredName, string enteredLastName, string enteredSurname);
        void FlushAccountDetails();
        void SetRole();
    }
}
