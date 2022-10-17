using AlunoECursos.DataSql;
using AlunoECursos.Models;
using AlunoECursos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Repositorio
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly BancoContextcs _bancoContextcs;
        public MatriculaRepositorio(BancoContextcs BancoContext)
        {

            _bancoContextcs = BancoContext;

        }
                    
       
        
        public MatriculadosModel AdicionarMatricula(MatriculadosModel Matricula)
        {
            var novaMatricula = new MatriculasViewModel();
             


            _bancoContextcs.Matriculas.Add(Matricula);
            _bancoContextcs.SaveChanges();
             
            return  (Matricula);
        }

        public bool ApagarMatricula(int idMatricula)
        {
           MatriculadosModel MatriculaDb = ListarPorId(idMatricula);

            if (MatriculaDb == null) throw new Exception("Houve um erro na exclusão do Cursos");
            _bancoContextcs.Matriculas.Remove(MatriculaDb);
            _bancoContextcs.SaveChanges();

            return true;

        }

      

     

        public List<MatriculadosModel> Buscartodos()
        {
           return _bancoContextcs.Matriculas.ToList();
          
        }

        public MatriculadosModel ListarPorId(int id)
        {
            return _bancoContextcs.Matriculas.FirstOrDefault(x => x.Id == id);
        }
    }
}
