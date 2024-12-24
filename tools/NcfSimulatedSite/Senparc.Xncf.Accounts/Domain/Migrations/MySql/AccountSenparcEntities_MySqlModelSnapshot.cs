﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senparc.Xncf.Accounts.Models;

#nullable disable

namespace Senparc.Xncf.Accounts.Domain.Migrations.MySql
{
    [DbContext(typeof(AccountSenparcEntities_MySql))]
    partial class AccountSenparcEntities_MySqlModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("District")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool?>("EmailChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Flag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("HeadImgUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("LastLoginIP")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastWeixinSignInTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("LockMoney")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool?>("Locked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Package")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool?>("PhoneChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PicUrl")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Province")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("QQ")
                        .HasColumnType("longtext");

                    b.Property<string>("RealName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<byte>("Sex")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("ThisLoginIp")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("ThisLoginIP");

                    b.Property<DateTime>("ThisLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WeixinOpenId")
                        .HasColumnType("longtext");

                    b.Property<int>("WeixinSignTimes")
                        .HasColumnType("int");

                    b.Property<string>("WeixinUnionId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.AccountPayLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AddIp")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("CompleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Flag")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("GetPoints")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<decimal>("PayMoney")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("PayParam")
                        .HasColumnType("longtext");

                    b.Property<int>("PayType")
                        .HasColumnType("int");

                    b.Property<string>("PrepayId")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TradeNumber")
                        .HasColumnType("varchar(150)");

                    b.Property<byte?>("Type")
                        .HasColumnType("tinyint unsigned");

                    b.Property<decimal?>("UsedPoints")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountPayLogs");
                });

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.PointsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("AccountPayLogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("AfterPoints")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BeforePoints")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("Flag")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountPayLogId");

                    b.ToTable("PointsLogs");
                });

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.AccountPayLog", b =>
                {
                    b.HasOne("Senparc.Xncf.Accounts.Domain.Models.Account", "Account")
                        .WithMany("AccountPayLogs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.PointsLog", b =>
                {
                    b.HasOne("Senparc.Xncf.Accounts.Domain.Models.Account", "Account")
                        .WithMany("PointsLogs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Senparc.Xncf.Accounts.Domain.Models.AccountPayLog", "AccountPayLog")
                        .WithMany("PointsLogs")
                        .HasForeignKey("AccountPayLogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Account");

                    b.Navigation("AccountPayLog");
                });

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.Account", b =>
                {
                    b.Navigation("AccountPayLogs");

                    b.Navigation("PointsLogs");
                });

            modelBuilder.Entity("Senparc.Xncf.Accounts.Domain.Models.AccountPayLog", b =>
                {
                    b.Navigation("PointsLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
