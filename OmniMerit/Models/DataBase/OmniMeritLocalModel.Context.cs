﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OmniMerit.Models.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class omnimeritLocalEntities : DbContext
    {
        public omnimeritLocalEntities()
            : base("name=omnimeritLocalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<phy_ques> phy_ques { get; set; }
        public virtual DbSet<poc_file2> poc_file2 { get; set; }
        public virtual DbSet<result> results { get; set; }
    }
}
