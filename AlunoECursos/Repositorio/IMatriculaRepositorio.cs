using AlunoECursos.Models;
using AlunoECursos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Repositorio
{
   public interface IMatriculaRepositorio
    {

        MatriculadosModel ListarPorId(int id);
        MatriculadosModel AdicionarMatricula(MatriculadosModel Matricula);

        List<MatriculadosModel> Buscartodos();
        bool ApagarMatricula(int id);
       
    }
}
