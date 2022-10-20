using AlunoECursos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

    
namespace AlunoECursos.Models
{
    [Table("MatriculadosModel")]
    public class MatriculadosModel
    {
        [Key()]
        public int Id { get; set; }


      
        public int AlunosId { get; set; }
        [ForeignKey("AlunosId")]
     
        public AlunosModel Alunos { get; set; }

        public int CursosId { get; set; }
        [ForeignKey("CursosId")]
        
        public virtual CursosModel Cursos{ get; set; }

        public string DataInicio { get; set; }
    

    }
   
}
    





