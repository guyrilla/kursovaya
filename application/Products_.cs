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
    
    public partial class Products_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products_()
        {
            this.Baskets_Products = new HashSet<Baskets_Products>();
        }
    
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int ProductCost { get; set; }
        public string ImagePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Baskets_Products> Baskets_Products { get; set; }
    }
}
