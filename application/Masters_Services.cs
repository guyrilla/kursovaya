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
    
    public partial class Masters_Services
    {
        public int ID { get; set; }
        public int MasterID { get; set; }
        public int ServiceID { get; set; }
    
        public virtual Masters_ Masters_ { get; set; }
        public virtual Services_ Services_ { get; set; }
    }
}
