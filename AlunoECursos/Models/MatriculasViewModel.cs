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
     

        public MatriculasViewModel()
        {
        
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

        

    }
}
