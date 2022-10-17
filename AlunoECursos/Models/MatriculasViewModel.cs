using AlunoECursos.DataSql;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Models.ViewModel




{
    public class MatriculasViewModel
    {
       public  BancoContextcs sql = new BancoContextcs();

        public MatriculasViewModel()
        {
            //Alunoslista = CarregaAlunos("");
          //  Cursoslista = CarregaCurso("");
        }

        [DisplayName("MatriculasId")]
        
        public string MatriculaId { get; set; }

        public string DataInicio { get; set; }

        public List<SelectListItem> Alunoslista { get; set; }

        public SelectListItem  AlunoSelecionado{ get; set; }

        public List<SelectListItem> Cursoslista { get; set; }

        public SelectListItem CursoSelecionado { get; set; }

        public virtual MatriculadosModel NovaMatricula { get; set; }

        public int AlunosId { get; set; }

        public int CursosId { get; set; }

        /* public List<SelectListItem> CarregaAlunos(string aluno)
         {
             var lista = new List<SelectListItem>();
             var Alunos = sql.Alunos.ToList();
             try
             {
                 foreach (var item in Alunos)
                 {
                     var options = new SelectListItem()
                     {
                         Text = item.Nome,
                         Value = item.Nome,
                         Selected = (item.Nome == aluno)

                     };


                     lista.Add(options);
                 }
             }
             catch (Exception error)
             {

                 throw;
             }


             return lista;


         }


         public List<SelectListItem> CarregaCurso(string curso)
         {
             var lista = new List<SelectListItem>();
             var cursos = sql.Cursos.ToList();
             try
             {
                 foreach (var item in cursos)
                 {
                     var options = new SelectListItem()
                     {
                         Text = item.Curso,
                         Value = item.Curso,
                         Selected = (item.Curso == curso)

                     };


                     lista.Add(options);
                 }
             }
             catch (Exception error)
             {

                 throw;
             }


             return lista;


         }*/

    }
}
