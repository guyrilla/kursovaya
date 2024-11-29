using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IBasketElement
    {
        int ID { get; set; }
        int ElementID { get; set; }
        string ElementName { get; set; }
        int ElementPrice { get; set; }
        string ImagePath { get; set; }
        void RemoveFromBasket();
    }
}
