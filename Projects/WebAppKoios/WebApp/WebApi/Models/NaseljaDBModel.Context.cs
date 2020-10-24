﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NaseljaDBEntities : DbContext
    {
        public NaseljaDBEntities()
            : base("name=NaseljaDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Naselje> Naselje { get; set; }
    
        public virtual int delete_naselje(Nullable<int> naselje_id)
        {
            var naselje_idParameter = naselje_id.HasValue ?
                new ObjectParameter("naselje_id", naselje_id) :
                new ObjectParameter("naselje_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_naselje", naselje_idParameter);
        }
    
        public virtual int insert_dummy_data()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_dummy_data");
        }
    
        public virtual int insert_naselje(string naziv, string postanski_broj, Nullable<int> id_drzava)
        {
            var nazivParameter = naziv != null ?
                new ObjectParameter("naziv", naziv) :
                new ObjectParameter("naziv", typeof(string));
    
            var postanski_brojParameter = postanski_broj != null ?
                new ObjectParameter("postanski_broj", postanski_broj) :
                new ObjectParameter("postanski_broj", typeof(string));
    
            var id_drzavaParameter = id_drzava.HasValue ?
                new ObjectParameter("id_drzava", id_drzava) :
                new ObjectParameter("id_drzava", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_naselje", nazivParameter, postanski_brojParameter, id_drzavaParameter);
        }
    }
}