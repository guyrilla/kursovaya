using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class CustomProduct : Products_, IPriceableEntityEdit
    {
        public CustomProduct()
        {
            PreparedToEditCost = -1;
        }
        public int PreparedToEditCost { get; set; }
        public string PreparedToEditName { get; set; }
        public string PreparedToEditImagePath { get; set; }
        public void EditCost(int cost)
        {
            PreparedToEditCost = cost;
        }
        public void EditImage(string imagePath)
        {
            PreparedToEditImagePath = imagePath;
        }
        public void SaveEntity(ComputerShopEntities computerShopEntities)
        {
            Products_ productToUpdate = computerShopEntities.Products_.FirstOrDefault(product => product.ID == this.ID);
            if(PreparedToEditName != null)
            {
                productToUpdate.ProductName = PreparedToEditName;
            }
            if((PreparedToEditCost < 0) == false)
            {
                productToUpdate.ProductCost = PreparedToEditCost;
            }
            if (PreparedToEditImagePath != null)
            {
                productToUpdate.ImagePath = PreparedToEditImagePath;
            }
            computerShopEntities.SaveChanges();
            FlushPreparedFields();
        }
        public void EditName(string name)
        {
            PreparedToEditName = name;
        }
        public void FlushPreparedFields()
        {
            PreparedToEditName = null;
            PreparedToEditCost = -1;
            PreparedToEditImagePath = null;
        }
    }
}
