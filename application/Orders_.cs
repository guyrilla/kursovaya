//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace application
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders_
    {
        public int ID { get; set; }
        public int BasketID { get; set; }
        public Nullable<bool> OrderStatus { get; set; }
    
        public virtual Baskets_ Baskets_ { get; set; }
    }
}
