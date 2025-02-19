﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senparc.Xncf.SystemPermission.Models;

#nullable disable

namespace Senparc.Xncf.SystemPermission.Domain.Migrations.Sqlite
{
    [DbContext(typeof(SystemPermissionSenparcEntities_SQLite))]
    [Migration("20241016154316_Update_Role_Column_Length")]
    partial class Update_Role_Column_Length
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleCode")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleName")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SysRoles");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysRoleAdminUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleCode")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SysRoleAdminUserInfos");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysRolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMenu")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("PermissionId")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("ResourceCode")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleCode")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SysRolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
