using AlunoECursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Repositorio
{
    public interface ICursosRepositorio
    {
        CursosModel ListarPorIdCursos(int id);


        List<CursosModel> Buscartodos();

        CursosModel AdicionarCursos(CursosModel Cursos);

        CursosModel Atualizar(CursosModel Cursos);


        bool Apagar(int id);
        
    }
}
