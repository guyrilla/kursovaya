using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class CustomBasketProducts : IBasketElement
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
                Baskets_Products productToRemove = _context.Baskets_Products.FirstOrDefault(bp => bp.ID == this.ID);
                _context.Baskets_Products.Remove(productToRemove);
                _context.SaveChanges();
            }
         }
    }
}
