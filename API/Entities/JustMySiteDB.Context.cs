﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JustMySiteDB : DbContext
    {
        public JustMySiteDB()
            : base("name=JustMySiteDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<CV> CV { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }
        public virtual DbSet<PersonalLetter> PersonalLetter { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
