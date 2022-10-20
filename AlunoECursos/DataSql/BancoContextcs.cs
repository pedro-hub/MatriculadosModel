

using AlunoECursos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.DataSql
{
    public class BancoContextcs : DbContext
    {


        public BancoContextcs(DbContextOptions<BancoContextcs> options) :base(options)
        { 
        }
        public DbSet<AlunosModel> Alunos { get; set; }


        public DbSet<CursosModel> Cursos { get; set; }
     
        public DbSet<MatriculadosModel> Matriculas{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
