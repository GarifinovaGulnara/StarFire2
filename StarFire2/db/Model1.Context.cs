﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StarFireEntities : DbContext
    {
        public StarFireEntities()
            : base("name=StarFireEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TypeOfProducts> TypeOfProducts { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
