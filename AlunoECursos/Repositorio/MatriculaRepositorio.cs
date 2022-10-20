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

        public MatriculadosModel Atualizar(MatriculadosModel Matricula)
        {
            
            {
                MatriculadosModel Matriculadb = ListarPorId(Matricula.Id);

                if (Matriculadb == null) throw new Exception("Houve um erro na Edição do Contato");
                {
                    Matriculadb.AlunosId = Matricula.AlunosId;
                    Matriculadb.CursosId = Matricula.CursosId;
                    Matriculadb.DataInicio = Matricula.DataInicio;


                    _bancoContextcs.Matriculas.Update(Matriculadb);
                    _bancoContextcs.SaveChanges();

                    return Matriculadb;
                }
            }
        }

        public List<MatriculadosModel> Buscartodos()
        {
            var matriculas = (from m in _bancoContextcs.Matriculas
                         join a in _bancoContextcs.Alunos on m.AlunosId equals a.Id
                         join c in _bancoContextcs.Cursos on m.CursosId equals c.Id
                         select new MatriculadosModel
                         {
                             Alunos = a,
                             AlunosId = a.Id,
                             Cursos = c,
                             CursosId = c.Id,
                             DataInicio = m.DataInicio,
                             Id = m.Id
                         }).ToList();

            return matriculas;
        }

        public MatriculadosModel ListarPorId(int id)
        {
            return _bancoContextcs.Matriculas.FirstOrDefault(x => x.Id == id);
        }
    }
}
