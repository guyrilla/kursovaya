using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class CustomService : Services_, IPriceableEntityEdit
    {
        public CustomService()
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
            Services_ serviceToUpdate = computerShopEntities.Services_.FirstOrDefault(service => service.ID == this.ID);
            if (PreparedToEditName != null)
            {
                serviceToUpdate.ServiceName = PreparedToEditName;
            }
            if ((PreparedToEditCost < 0) == false)
            {
                serviceToUpdate.ServiceCost = PreparedToEditCost;
            }
            if(PreparedToEditImagePath != null)
            {
                serviceToUpdate.ImagePath = PreparedToEditImagePath;
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
