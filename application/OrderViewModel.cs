using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace application
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public string ClientFullName { get; set; }
        public ObservableCollection<IBasketElement> BasketElements { get; set; } = new ObservableCollection<IBasketElement>();

        public OrderViewModel(Orders_ order)
        {
            ID = order.ID;
            var client = order.Baskets_.Clients_;
            ClientFullName = $"{client.FirstName} {client.SecondName} {client.SurName}";
        }
    }
}
