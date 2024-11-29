using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IEntityEdit
    { 
        string PreparedToEditName { get; set; }
        string PreparedToEditImagePath { get; set; }
        void SaveEntity(ComputerShopEntities context);
        void EditImage(string imagePath);
        void EditName(string name);
    }
}
