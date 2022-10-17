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


        [Required(ErrorMessage = "Digite o Nome do Aluno")]
        public int AlunosId { get; set; }
        [ForeignKey("AlunosId")]
      
        public AlunosModel Alunos { get; set; }
       

        [Required(ErrorMessage = "Digite o Nome do Curso")] 
        
        public int CursosId { get; set; }
        [ForeignKey("CursosId")]
        
        public virtual CursosModel Cursos{ get; set; }
        [Required(ErrorMessage = "Digite o Data de Inicio do Aluno")]
        public string DataInicio { get; set; }
        
    }

}
    





