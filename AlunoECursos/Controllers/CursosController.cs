using AlunoECursos.Models;
using AlunoECursos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursosRepositorio _CursosRepositorio;

        public CursosController(ICursosRepositorio CursosRepositorio)
        {
            _CursosRepositorio = CursosRepositorio;
        }

        public IActionResult Cursos()
        {
            List<CursosModel> Cursos = _CursosRepositorio.Buscartodos();
            return View(Cursos);
        }


        public IActionResult AdicionarCursos()
        {
            return View();
        }

        public IActionResult Alterar(int id)
        {
            CursosModel Cursos = _CursosRepositorio.ListarPorIdCursos(id);
            return View(Cursos);
        }


        public IActionResult Excluir(int id)
        {
            CursosModel Cursos = _CursosRepositorio.ListarPorIdCursos(id);
            return View(Cursos);
        }


        public IActionResult ConfirmarApagar(int id)
        {
            try
            {
                bool apagado = _CursosRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Curso Excluido da tabela";
                }
                else
                {
                    TempData["MensagemErro"] = $"Curso Não foi excluido  ";
                }

                return RedirectToAction("Cursos");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Curso Não foi excluido, detelhes do erro:{erro.Message} ";
                return RedirectToAction("Cursos");

            }
        }



        [HttpPost]
        public IActionResult CriarCurso(CursosModel Cursos)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CursosRepositorio.AdicionarCursos(Cursos);
                    TempData["MensagemSucesso"] = "Curso Cadastrado Na tabela";
                    return RedirectToAction("Cursos");
                }
                return View("AdicionarCursos", Cursos);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Curso Não Cadastrado ,detelhes do erro:{erro.Message}";
                return RedirectToAction("Cursos");
            }


        }


        [HttpPost]
        public IActionResult ConfirmarEdicao(CursosModel Cursos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CursosRepositorio.Atualizar(Cursos);
                    TempData["MensagemSucesso"] = "Curso Editado Na tabela";
                    return RedirectToAction("Cursos");
                }
                return View(Cursos);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Curso Não editado ,detelhes do erro:{erro.Message}";
                return RedirectToAction("Cursos");
            }

        }
    }
}
