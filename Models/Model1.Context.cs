﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blood_Page.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Blood_PageEntitiesNew : DbContext
    {
        public Blood_PageEntitiesNew()
            : base("name=Blood_PageEntitiesNew")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Donner> Donners { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Thana> Thanas { get; set; }
    }
}
