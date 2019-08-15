using Domain;
using Domain.NToN;
using Domain._1To1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)//调用父类构造函数传入dbContextOptions，dbContextOptions包含一些配置信息和连接字符串
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Key Configuration
            /*N:N复合主键*/
            modelBuilder.Entity<CompanyDepartment>().HasKey(x => new { x.CompanyId, x.DepartmentId });//配置联合主键，这种配置方式称为FluentAPI，而并不推荐在属性上配置[key]那种方法
            /*N:N主外键*/
            modelBuilder.Entity<CompanyDepartment>().HasOne(x => x.Company).WithMany(x => x.CompanyDepartments).HasForeignKey(x => x.CompanyId);
            modelBuilder.Entity<CompanyDepartment>().HasOne(x => x.Department).WithMany(x => x.CompanyDepartments).HasForeignKey(x => x.DepartmentId);//尽管EFCore可以自动生成主外键关系，但尽量手动指定以方便理解
            /*1:1主外键*/
            modelBuilder.Entity<President>().HasOne(x => x.Country).WithOne(x => x.President).HasForeignKey<President>(x => x.CountryId);//指定外键必须指定<President>
            /*1:N主外键*/
            modelBuilder.Entity<City>().HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId);
            #endregion

            #region Seed Data
            modelBuilder.Entity<Province>().HasData(new Province
            {
                ProvinceId = 1,
                Name = "四川省",
                Population = 10_000_000
            },
            new Province
            {
                ProvinceId = 2,
                Name = "重庆市",
                Population = 8_000_000,
            });
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, ProvinceId = 2, Name = "渝北区" },
                new City { CityId = 2, ProvinceId = 2, Name = "沙坪坝区" },
                new City { CityId = 3, ProvinceId = 2, Name = "江北区" });
            var studentId = new Guid("57f436d1-c85a-41a8-839b-5545d8fdea0f");
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id =studentId,
                Name = "廖然2"
            });
            #endregion
        }
        /*1:N*/
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        /*N:N*/
        public DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        /*1:1*/
        public DbSet<Country> Countries { get; set; }
        public DbSet<President> Presidents { get; set; }
        /*GUID*/
        public DbSet<Student> Students { get; set; }
    }
}
