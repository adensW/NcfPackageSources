﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Senparc.Xncf.AIKernel.Models;

#nullable disable

namespace Senparc.Xncf.AIKernel.Domain.Migrations.Migrations.Oracle
{
    [DbContext(typeof(AIKernelSenparcEntities_Oracle))]
    partial class AIKernelSenparcEntities_OracleModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Senparc.Xncf.AIKernel.Models.AIModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR2(300)");

                    b.Property<int>("AiPlatform")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("ApiKey")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<string>("ApiVersion")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("DeploymentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)");

                    b.Property<bool>("Flag")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("IsShared")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("MaxToken")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Note")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrganizationId")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR2(300)");

                    b.Property<bool>("Show")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("TenantId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Senparc_AIKernel_AIModel");
                });
#pragma warning restore 612, 618
        }
    }
}
