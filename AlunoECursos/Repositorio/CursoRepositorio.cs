using AlunoECursos.DataSql;
using AlunoECursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Repositorio
{
    public class CursosRepositorio : ICursosRepositorio
    {

        private readonly BancoContextcs _bancoContextcs;
        public CursosRepositorio(BancoContextcs BancoContext)
        {

            _bancoContextcs = BancoContext;

        }
        public CursosModel ListarPorIdCursos(int id)
        {
            return _bancoContextcs.Cursos.FirstOrDefault(x => x.Id == id);
        }
        public List<CursosModel> Buscartodos()
        {
            return _bancoContextcs.Cursos.ToList();
        }
        public CursosModel AdicionarCursos(CursosModel Cursos)
        {
            _bancoContextcs.Cursos.Add(Cursos);
            _bancoContextcs.SaveChanges();

            return Cursos;
        }

        public CursosModel Atualizar(CursosModel Cursos)
        {
            CursosModel CursosDb = ListarPorIdCursos(Cursos.Id);

            if (CursosDb == null) throw new Exception("Houve um erro na Edição do Cursos");
            {
                CursosDb.Curso = Cursos.Curso;
                CursosDb.HorasCurso = Cursos.HorasCurso;
           


                _bancoContextcs.Cursos.Update(CursosDb);
                _bancoContextcs.SaveChanges();

                return CursosDb;
            }
        }

        public bool Apagar(int id)
        {
            CursosModel CursosDb = ListarPorIdCursos(id);

            if (CursosDb == null) throw new Exception("Houve um erro na exclusão do Cursos");
            _bancoContextcs.Cursos.Remove(CursosDb);
            _bancoContextcs.SaveChanges();

            return true;

        }

       
        }
    }

