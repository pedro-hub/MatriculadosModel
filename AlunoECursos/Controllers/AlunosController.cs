using AlunoECursos.Models;
using AlunoECursos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosRepositorio _alunosRepositorio;

        public AlunosController(IAlunosRepositorio alunosRepositorio)
        {
            _alunosRepositorio = alunosRepositorio;
        }

        public IActionResult Alunos()
        {
            List<AlunosModel> Alunos = _alunosRepositorio.Buscartodos();
            return View(Alunos);
        }


        public IActionResult AdicionarAlunos()
        {
            return View();
        }

        public IActionResult Alterar(int id)
        {
            AlunosModel Alunos = _alunosRepositorio.ListarPorIdAlunos(id);
            return View(Alunos);
        }


        public IActionResult Excluir(int id)
        {
            AlunosModel Alunos = _alunosRepositorio.ListarPorIdAlunos(id);
            return View(Alunos);
        }


        public IActionResult ConfirmarApagar(int id)
        {
            try
            {
               bool apagado = _alunosRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Aluno Excluido da tabela";
                }
                else
                {
                    TempData["MensagemErro"] = $"Aluno Não foi excluido  ";
                }

                return RedirectToAction("Alunos");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Aluno Não foi excluido detelhes do erro:{erro.Message} ";
                return RedirectToAction("Alunos");
             
            }
        }



        [HttpPost]
        public IActionResult CriarAluno(AlunosModel Alunos)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunosRepositorio.AdicionarAlunos(Alunos);
                    TempData["MensagemSucesso"] = "Aluno Cadastrado Na tabela";
                    return RedirectToAction("Alunos");
                }
                return View("AdicionarAlunos", Alunos);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Aluno Não Cadastrado ,detelhes do erro:{erro.Message}";
                return RedirectToAction("Alunos");
            }
            
            
        }


        [HttpPost]
        public IActionResult ConfirmarEdicao(AlunosModel Alunos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunosRepositorio.Atualizar(Alunos);
                    TempData["MensagemSucesso"] = "Aluno Editado Na tabela";
                    return RedirectToAction("Alunos");
                }

                return View(Alunos);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Aluno Não editado ,detelhes do erro:{erro.Message}";
                return RedirectToAction("Alunos");
            }

        }
    }
}
