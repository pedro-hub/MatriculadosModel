using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Models
{
    public class AlunosModel
    {
        [Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Aluno")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite o Sobrenome do Aluno")]
        public string Sobrenome { get; set; }


        [Required(ErrorMessage = "Digite A idade do Aluno")]
        public int Idade { get; set; }


         
       

        


    } 
}
