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
    
    public partial class Baskets_Products
    {
        public int ID { get; set; }
        public int BasketID { get; set; }
        public int ProductID { get; set; }
    
        public virtual Baskets_ Baskets_ { get; set; }
        public virtual Products_ Products_ { get; set; }
    }
}
