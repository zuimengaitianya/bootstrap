using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Entities;
using System.Data.Entity;

namespace TelnetMVC.DAL
{
    public class TelnetContext:DbContext
    {
        #region <<表集合定义>>
        
        public DbSet<OrgDict> OrgDicts { get; set; }
        public DbSet<DeptDict> DeptDicts { get; set; }
        public DbSet<RoleDict> RoleDicts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleAllot> UserRoleAllots { get; set; }
        public DbSet<BaseDict> BaseDicts { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<PowerAllot> PowerAllots { get; set; }
        public DbSet<Resources> ResourcesS { get; set; }
        public DbSet<ResourcesAllot> ResourcesAllots { get; set; }

        #endregion

        public TelnetContext() : base("name=TelnetMVCEntites") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region OrgDict 表映射
            //表映射
            modelBuilder.Entity<OrgDict>().ToTable("OrgDict");
            //主键映射
            modelBuilder.Entity<OrgDict>().HasKey(o => o.Id);
            #endregion

            #region DeptDict 表映射
            //表映射
            modelBuilder.Entity<DeptDict>().ToTable("DeptDict");
            //主键映射
            modelBuilder.Entity<DeptDict>().HasKey(o => o.Id);
            #endregion

            #region RoleDict 表映射
            //表映射
            modelBuilder.Entity<RoleDict>().ToTable("RoleDict");
            //主键映射
            modelBuilder.Entity<RoleDict>().HasKey(o => o.Id);
            #endregion

            #region User 表映射
            //表映射
            modelBuilder.Entity<User>().ToTable("User");
            //主键映射
            modelBuilder.Entity<User>().HasKey(o => o.Id);
            #endregion

            #region UserRoleAllot 表映射
            //表映射
            modelBuilder.Entity<UserRoleAllot>().ToTable("UserRoleAllot");
            //主键映射
            modelBuilder.Entity<UserRoleAllot>().HasKey(o => o.Id);
            #endregion

            #region BaseDict 表映射
            //表映射
            modelBuilder.Entity<BaseDict>().ToTable("BaseDict");
            //主键映射
            modelBuilder.Entity<BaseDict>().HasKey(o => o.Id);
            #endregion

            #region Power 表映射
            //表映射
            modelBuilder.Entity<Power>().ToTable("Power");
            //主键映射
            modelBuilder.Entity<Power>().HasKey(o => o.Id);
            #endregion

            #region PowerAllot 表映射
            //表映射
            modelBuilder.Entity<PowerAllot>().ToTable("PowerAllot");
            //主键映射
            modelBuilder.Entity<PowerAllot>().HasKey(o => o.Id);
            #endregion

            #region Resources 表映射
            //表映射
            modelBuilder.Entity<Resources>().ToTable("Resources");
            //主键映射
            modelBuilder.Entity<Resources>().HasKey(o => o.Id);
            #endregion

            #region ResourcesAllot 表映射
            //表映射
            modelBuilder.Entity<ResourcesAllot>().ToTable("ResourcesAllot");
            //主键映射
            modelBuilder.Entity<ResourcesAllot>().HasKey(o => o.Id);
            #endregion

        }
    }
}
