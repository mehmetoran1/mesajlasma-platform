﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mesajlasma_Platform.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gruplar> Gruplar { get; set; }
        public virtual DbSet<GrupUyeleri> GrupUyeleri { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Mesajlar> Mesajlar { get; set; }
        public virtual DbSet<TopluMesajAlicilar> TopluMesajAlicilar { get; set; }
        public virtual DbSet<TopluMesajlar> TopluMesajlar { get; set; }
    }
}