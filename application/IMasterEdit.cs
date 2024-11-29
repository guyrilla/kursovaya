using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IMasterEdit : IEntityEdit
    {
        string PreparedSecondNameEdit { get; set; }
        string PreparedSurNameEdit { get; set; }
        byte PreparedWorkExperienceEdit { get; set; }
        void EditSecondName(string secondName);
        void EditSurName(string surName);
        void EditWorkExperience(byte workExperience);
    }
}
