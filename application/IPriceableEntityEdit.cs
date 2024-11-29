using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IPriceableEntityEdit : IEntityEdit
    {
        int PreparedToEditCost { get; set; }
        void FlushPreparedFields();
        void EditCost(int cost);
    }
}
