﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senparc.Xncf.PromptRange.Models;

#nullable disable

namespace Senparc.Xncf.PromptRange.Domain.Migrations.Sqlite
{
    [DbContext(typeof(PromptRangeSenparcEntities_Sqlite))]
    [Migration("20240515040341_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Senparc.Xncf.PromptRange.Domain.Models.DatabaseModel.LlModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ApiKey")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ApiVersion")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("DeploymentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsShared")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxToken")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelType")
                        .HasMaxLength(20)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationId")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Show")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Senparc_PromptRange_LlModel");
                });

            modelBuilder.Entity("Senparc.Xncf.PromptRange.Domain.Models.DatabaseModel.PromptItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("Aiming")
                        .HasMaxLength(5)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<double>("EvalAvgScore")
                        .HasMaxLength(3)
                        .HasColumnType("REAL");

                    b.Property<double>("EvalMaxScore")
                        .HasMaxLength(3)
                        .HasColumnType("REAL");

                    b.Property<string>("ExpectedResultsJson")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<float>("FrequencyPenalty")
                        .HasColumnType("REAL");

                    b.Property<string>("FullVersion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDraft")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsShare")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastRunTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxToken")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NickName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentTac")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefix")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<float>("PresencePenalty")
                        .HasColumnType("REAL");

                    b.Property<int>("RangeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RangeName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("StopSequences")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suffix")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tactic")
                        .HasColumnType("TEXT");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TopP")
                        .HasColumnType("REAL");

                    b.Property<string>("VariableDictJson")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Senparc_PromptRange_PromptItem");
                });

            modelBuilder.Entity("Senparc.Xncf.PromptRange.Domain.Models.DatabaseModel.PromptRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RangeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Senparc_PromptRange_PromptRange");
                });

            modelBuilder.Entity("Senparc.Xncf.PromptRange.Domain.Models.DatabaseModel.PromptResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<double>("CostTime")
                        .HasColumnType("REAL");

                    b.Property<decimal>("FinalScore")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("HumanScore")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("LlmModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PromptCostToken")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PromptItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromptItemVersion")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("ResultCostToken")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResultString")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RobotScore")
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TestType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalCostToken")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Senparc_PromptRange_PromptResult");
                });
#pragma warning restore 612, 618
        }
    }
}
