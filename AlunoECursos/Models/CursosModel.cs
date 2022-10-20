using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using AlunoECursos.DataSql;

namespace AlunoECursos.Models
{
    public class CursosModel
    {

        [Key()]
        public int Id { get; set; }



        [Required(ErrorMessage = "Digite o Nome do Curso")]

        public string Curso { get; set; }

        [Required(ErrorMessage = "Digite As do Horas")]
        public string HorasCurso { get; set; }

       



    }
}


