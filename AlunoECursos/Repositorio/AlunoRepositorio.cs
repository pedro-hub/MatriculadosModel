using AlunoECursos.DataSql;
using AlunoECursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Repositorio
{
    public class AlunoRepositorio : IAlunosRepositorio
    {

        private readonly BancoContextcs _bancoContextcs;
        public AlunoRepositorio(BancoContextcs BancoContext) {

            _bancoContextcs = BancoContext; 

        }
        public AlunosModel ListarPorIdAlunos(int id)
        {
            return _bancoContextcs.Alunos.FirstOrDefault(x =>x.Id == id);
        }
        public List<AlunosModel> Buscartodos()
        {
            return _bancoContextcs.Alunos.ToList();
        }
        public AlunosModel AdicionarAlunos(AlunosModel Alunos)
        {
            _bancoContextcs.Alunos.Add(Alunos);
            _bancoContextcs.SaveChanges();

            return Alunos;
        }

        public AlunosModel Atualizar(AlunosModel Alunos)
        {
            AlunosModel AlunosDb = ListarPorIdAlunos(Alunos.Id);

            if (AlunosDb == null) throw new Exception("Houve um erro na Edição do Contato");
            {
                AlunosDb.Nome = Alunos.Nome;
                AlunosDb.Sobrenome = Alunos.Sobrenome;
                AlunosDb.Idade = Alunos.Idade;


                _bancoContextcs.Alunos.Update(AlunosDb);
                _bancoContextcs.SaveChanges();

                return AlunosDb;
            }
        }

        public bool Apagar(int id)
        {
            AlunosModel AlunosDb = ListarPorIdAlunos(id);

            if (AlunosDb == null) throw new Exception("Houve um erro na exclusão do Contato");
            _bancoContextcs.Alunos.Remove(AlunosDb);
            _bancoContextcs.SaveChanges();

            return true;

        }
    }
}
