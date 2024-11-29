using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class CustomBasketServices : IBasketElement
    {
        public int ID { get; set; }
        public int ElementID { get; set; }
        public string ElementName { get; set; }
        public int ElementPrice { get; set; }
        public string ImagePath { get; set; }
        public void RemoveFromBasket()
        {
            using (ComputerShopEntities _context = new ComputerShopEntities())
            {
                Baskets_Services serviceToRemove = _context.Baskets_Services.FirstOrDefault(bs => bs.ID == this.ID);
                _context.Baskets_Services.Remove(serviceToRemove);
                _context.SaveChanges();
            }
        }
    }
}
