//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StarFire2.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int ID_order { get; set; }
        public string Description { get; set; }
        public int ID_prod { get; set; }
        public int ID_user { get; set; }
        public bool Ready { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
    }
}