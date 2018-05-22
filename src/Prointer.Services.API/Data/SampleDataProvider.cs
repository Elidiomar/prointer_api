using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Prointer.Services.API.Models;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Prointer.Services.API.Data
{
        public static class SampleDataProvider
        {
            #region ApplyMigrations
            public static void ApplyMigration(IServiceProvider serviceProvider)
            {
                //serviceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                serviceProvider.GetService<AppDbContext>().Database.Migrate();
            }

            #endregion

            #region Seed
            internal static void Seed(IServiceProvider serviceProvider, IConfigurationRoot configuration)
            {
                var context = serviceProvider.GetService<AppDbContext>();
            
            context.Database.EnsureCreated(); //if db is not exist ,it will create database .but ,do nothing .

            TestDataSeed(serviceProvider.GetService<AppDbContext>(), configuration).GetAwaiter().GetResult();

            // Look for any students.
            if (!context.Alunos.Any())
                {
                

                    ApplyMigration(serviceProvider);
                    TestDataSeed(serviceProvider.GetService<AppDbContext>(), configuration).GetAwaiter().GetResult();
                }


            }

            #endregion

            #region Ids

            #region AlunoIds
            enum AlunoIds
        {
                [EnumGuid("240de0d4-ade7-417e-a034-9b63cc2de853")] Aluno1,
                [EnumGuid("1966c895-c0d4-40d6-b201-47c0dd0228e1")] Aluno2,
                [EnumGuid("975c62c9-5924-4b23-9e1b-d3de87118d42")] Aluno3,
                [EnumGuid("6670f705-8a06-451c-b267-5dceb9c130b1")] Aluno4,
        }
            #endregion
            
            #region ProfessorIds
            enum ProfessorIds
        {
                [EnumGuid("50ec3a54-0eab-4dfc-bad7-d1538f62f25e")] Professor1,
                [EnumGuid("693721cb-61e5-41cd-9d99-376c08ab627b")] Professor2
        }
            #endregion

            #region GrupoIds
            enum GrupoIds
            {
                [EnumGuid("337acae3-7adf-4372-8619-1cc9345c61ea")] Grupo1,
                [EnumGuid("21e88188-057e-41e0-8746-57ec2fd76a51")] Grupo2,
            }
            #endregion

            #region TarefaIds
            enum TarefaIds
            {
                [EnumGuid("8c4825ef-8c4c-4162-b2e3-08d46c337976")] Tarefa1,
                [EnumGuid("572a88b0-17ef-4e6c-a806-ca35ad57a41b")] Tarefa2,                
            }
            #endregion
    #endregion            

           
            #region Helpers
            
            static Guid GetGuid(this Enum e)
            {
                Type type = e.GetType();
                MemberInfo[] memInfo = type.GetMember(e.ToString());

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = (object[])memInfo[0].GetCustomAttributes(typeof(EnumGuid), false);
                    if (attrs != null && attrs.Length > 0)
                        return ((EnumGuid)attrs[0]).Guid;
                }

                throw new ArgumentException($"Enum {e.ToString()} has no EnumGuid defined!");
            }

            #endregion

            #region TestDataSeed
            private static async Task TestDataSeed(AppDbContext context, IConfiguration configuration)
            {
                #region RemoveRange

                context.Alunos.RemoveRange(context.Alunos);
                context.Professores.RemoveRange(context.Professores);
                context.Grupos.RemoveRange(context.Grupos);
                context.Tarefas.RemoveRange(context.Tarefas);
                context.Usuarios.RemoveRange(context.Usuarios);
                await context.SaveChangesAsync();

            #endregion

            #region #region Usuario
            var usuarios = new List<Usuario>
            {
                #region Usuario 01"
                new Usuario
                {
                    UserName = "professor1@test.com.br",
                    Password = "admin",
                    DateAdded = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Active = true,
                    TipoProfessor = true
                },
                #endregion

                 #region Usuario 02"
                new Usuario
                {
                    UserName = "professor2@test.com.br",
                    Password = "admin",
                    DateAdded = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Active = true,
                    TipoProfessor = true
                },
                #endregion

                 #region Usuario 03"
                new Usuario
                {
                    UserName = "aluno1@test.com.br",
                    Password = "admin",
                    DateAdded = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Active = true,
                    TipoProfessor = false
                },
                #endregion

                 #region Usuario 04"
                new Usuario
                {
                    UserName = "aluno2@test.com.br",
                    Password = "admin",
                    DateAdded = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Active = true,
                    TipoProfessor = false
                },
                #endregion

                 #region Usuario 05"
                new Usuario
                {
                    UserName = "aluno3@test.com.br",
                    Password = "admin",
                    DateAdded = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Active = true,
                    TipoProfessor = false
                },
                #endregion

                 #region Usuario 06"
                new Usuario
                {
                    UserName = "aluno4@test.com.br",
                    Password = "admin",
                    DateAdded = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Active = true,
                    TipoProfessor = false
                },
                #endregion
            };
            context.Usuarios.AddRange(usuarios);
            await context.SaveChangesAsync();
            #endregion    


            #region Professor
            var professores = new List<Professor>
            {
                #region Professor 01"
                new Professor
                {
                    
                    Name = "Professor 01",
                    Email = usuarios[0].UserName,
                    UserId = usuarios[0].Id,
                    DateAdded = DateTime.Now
                },
                #endregion
                
                #region Professor 02"
                new Professor
                {                    
                    Name = "Professor 02",
                    Email = usuarios[1].UserName,
                    UserId = usuarios[1].Id,
                    DateAdded = DateTime.Now
                },
                #endregion                

            };
            context.Professores.AddRange(professores);
            await context.SaveChangesAsync();
            #endregion

            #region Grupo
            var grupos = new List<Grupo>
            {
                #region Grupo 01"
                new Grupo
                {
                    Name = "Grupo Professor 01",
                    ProfessorId = professores[0].Id,
                    DateAdded = DateTime.Now
                },
                #endregion
                
                #region Grupo 02"
                new Grupo
                {
                    Name = "Grupo Professor 02",
                    ProfessorId = professores[1].Id,                    
                    DateAdded = DateTime.Now
                },
                #endregion 

            };
            context.Grupos.AddRange(grupos);
            await context.SaveChangesAsync();
            #endregion

            #region Tarefa
            var tarefas = new List<Tarefa>
            {
                #region Tarefa 01"
                new Tarefa
                {
                    Name = "Tarefa do grupo 01",
                    Time = DateTime.Now.AddDays(5).AddHours(2),
                    GrupoId = grupos[0].Id,
                    DateAdded = DateTime.Now

                },
                #endregion
                
                #region Tarefa 02"
                new Tarefa
                {
                    Name = "Tarefa do grupo 02",
                    Time = DateTime.Now.AddDays(3).AddHours(8),
                    GrupoId = grupos[1].Id,
                    DateAdded = DateTime.Now
                },
                #endregion 

            };
            context.Tarefas.AddRange(tarefas);
            await context.SaveChangesAsync();
            #endregion


            #region Aluno
            var alunos = new List<Aluno>
            {
                #region Aluno 01"
                new Aluno
                {
                    Name = "Aluno 01",
                    GrupoId = grupos[0].Id,
                    Email = usuarios[2].UserName,
                    UserId = usuarios[2].Id,
                    DateAdded = DateTime.Now
                },
                #endregion

                #region Aluno 02"
                new Aluno
                {
                    Name = "Aluno 02",
                    GrupoId = grupos[0].Id,
                    Email = usuarios[3].UserName,
                    UserId = usuarios[3].Id,
                    DateAdded = DateTime.Now
                },
                #endregion

                #region Aluno 03"
                new Aluno
                {                 
                    Name = "Aluno 03",
                    GrupoId = grupos[0].Id,
                    Email = usuarios[4].UserName,
                    UserId = usuarios[4].Id,
                    DateAdded = DateTime.Now
                },
                #endregion

                #region Aluno 04"
                new Aluno
                {
                    Name = "Aluno 04",
                    GrupoId = grupos[1].Id,
                    Email = usuarios[5].UserName,
                    UserId = usuarios[5].Id,
                    DateAdded = DateTime.Now
                },
                #endregion                

            };
            context.Alunos.AddRange(alunos);
            await context.SaveChangesAsync();
            #endregion                   

        }
        #endregion
    }

        #region EnumGuid class
        class EnumGuid : Attribute
        {
            public Guid Guid;

            public EnumGuid(string guid)
            {
                Guid = new Guid(guid);
            }
        }
        #endregion
    }
