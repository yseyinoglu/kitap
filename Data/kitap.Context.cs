﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kitapContainer : DbContext
    {
        public kitapContainer()
            : base("name=kitapContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<UserType> UserTypeSet { get; set; }
        public virtual DbSet<Sikayet> SikayetSet { get; set; }
        public virtual DbSet<Kategori> KategoriSet { get; set; }
        public virtual DbSet<KitapDetay> KitapDetaySet { get; set; }
        public virtual DbSet<Yorum> YorumSet { get; set; }
        public virtual DbSet<Kitapİlan> KitapİlanSet { get; set; }
    }
}
