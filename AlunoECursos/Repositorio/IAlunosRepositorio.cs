using AlunoECursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Repositorio
{
    public interface IAlunosRepositorio
    {
        AlunosModel ListarPorIdAlunos(int id);


        List<AlunosModel> Buscartodos();

        AlunosModel AdicionarAlunos(AlunosModel Alunos);

        AlunosModel Atualizar(AlunosModel Alunos);


        bool Apagar(int id);
   
    }
}
