﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFWebApp.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CatalogosEntities : DbContext
    {
        public CatalogosEntities()
            : base("name=CatalogosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
