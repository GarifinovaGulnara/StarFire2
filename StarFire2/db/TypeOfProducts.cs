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
    
    public partial class TypeOfProducts
    {
        public TypeOfProducts()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int ID_type { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Products> Products { get; set; }
    }
}
