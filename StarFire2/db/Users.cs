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
    
    public partial class Users
    {
        public Users()
        {
            this.Authorization = new HashSet<Authorization>();
            this.Orders = new HashSet<Orders>();
        }
    
        public int ID_user { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual ICollection<Authorization> Authorization { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
