﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiabetesHelperUser
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database1Entities : DbContext
    {
        public Database1Entities()
            : base("name=Database1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CombDefinition> CombDefinitions { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealCombination> MealCombinations { get; set; }
        public DbSet<MealName> MealNames { get; set; }
        public DbSet<MeasuringUnit> MeasuringUnits { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
    }
}
