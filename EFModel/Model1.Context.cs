﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TelnetMVCEntities : DbContext
    {
        public TelnetMVCEntities()
            : base("name=TelnetMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DeptDict> DeptDict { get; set; }
        public DbSet<OrgDict> OrgDict { get; set; }
        public DbSet<Power> Power { get; set; }
        public DbSet<PowerAllot> PowerAllot { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<ResourcesAllot> ResourcesAllot { get; set; }
        public DbSet<RoleDict> RoleDict { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRoleAllot> UserRoleAllot { get; set; }
        public DbSet<BaseDict> BaseDict { get; set; }
    }
}
