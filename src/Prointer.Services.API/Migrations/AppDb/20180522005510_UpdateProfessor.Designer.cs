﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Prointer.Services.API.Models;
using System;

namespace Prointer.Services.API.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180522005510_UpdateProfessor")]
    partial class UpdateProfessor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prointer.Services.API.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(11);

                    b.Property<Guid>("GrupoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.HasIndex("UserId");

                    b.ToTable("Alunos","data");
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("ProfessorId");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Grupos","data");
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Professores","data");
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateAdded");

                    b.Property<Guid>("GrupoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Tarefas","data");
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Password");

                    b.Property<bool>("Professor");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Usuarios","data");
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Aluno", b =>
                {
                    b.HasOne("Prointer.Services.API.Models.Grupo", "Grupo")
                        .WithMany("Alunos")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Prointer.Services.API.Models.Usuario", "Usuario")
                        .WithMany("Alunos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Grupo", b =>
                {
                    b.HasOne("Prointer.Services.API.Models.Professor", "Professor")
                        .WithMany("Grupos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Professor", b =>
                {
                    b.HasOne("Prointer.Services.API.Models.Usuario", "Usuario")
                        .WithMany("Professores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Prointer.Services.API.Models.Tarefa", b =>
                {
                    b.HasOne("Prointer.Services.API.Models.Grupo", "Grupo")
                        .WithMany("Tarefas")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
