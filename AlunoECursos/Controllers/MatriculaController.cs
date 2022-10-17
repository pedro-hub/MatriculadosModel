using AlunoECursos.DataSql;
using AlunoECursos.Models;
using AlunoECursos.Models.ViewModel;
using AlunoECursos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoECursos.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IMatriculaRepositorio _MatriculaRepositorio;
        private BancoContextcs _bancoContextcs;

        public MatriculaController(IMatriculaRepositorio MatriculaRepositorio, BancoContextcs bancoContextcs)
        {
            _bancoContextcs = bancoContextcs;

            _MatriculaRepositorio = MatriculaRepositorio;
            

        } 
        
        
        

        public IActionResult Matricula()
        {
            var model = new MatriculasViewModel();

            MatriculadosModel matriculados = new MatriculadosModel();

           

           
          
              
           
             List<MatriculadosModel> Matricula = _MatriculaRepositorio.Buscartodos();
            return View(Matricula);


        }


    

        public IActionResult Alterar(int id)
        {
            MatriculadosModel Matricula = _MatriculaRepositorio.ListarPorId(id);
            return View(Matricula);
        }


        public IActionResult Excluir(int id)
        {
            MatriculadosModel Matricula = _MatriculaRepositorio.ListarPorId(id);
            return View(Matricula);
        }


        public IActionResult ConfirmarApagar(int id)
        {
            try
            {
                bool apagado = _MatriculaRepositorio.ApagarMatricula(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Aluno Excluido da tabela";
                }
                else
                {
                    TempData["MensagemErro"] = $"Aluno Não foi excluido  ";
                }

                return RedirectToAction("Matricula");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Aluno Não foi excluido detelhes do erro:{erro.Message} ";
                return RedirectToAction("Matricula");

            }
        }
        
        public IActionResult AdicionarMatricula()
        {
            MatriculasViewModel viewModel = new MatriculasViewModel();
            var ListaAlunos = (from aluno in _bancoContextcs.Alunos
                               select new SelectListItem()
                               {
                                   Text = aluno.Nome,
                                   Value = aluno.Id.ToString()
                               }).ToList();
            ListaAlunos.Insert(0, new SelectListItem()
            {
                Text = "---Alunos Matriculados---",
                Value = string.Empty

            });
            viewModel.Alunoslista = ListaAlunos;

            var ListaCursos = (from curso in _bancoContextcs.Cursos
                               select new SelectListItem()
                               {
                                   Text = curso.Curso,
                                   Value = curso.Id.ToString()
                               }).ToList();
            ListaCursos.Insert(0, new SelectListItem()
            {
                Text = "---Cursos Disponiveis---",
                Value = string.Empty

            });
            viewModel.Cursoslista = ListaCursos;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AdicionarMatricula(MatriculadosModel Matricula,MatriculasViewModel matriculas)
              
        {
            MatriculasViewModel matriculaviewModel = new MatriculasViewModel()
            {
                NovaMatricula = _MatriculaRepositorio.ListarPorId(1)

            };
            try
            {
                if (ModelState.IsValid)
                {
                     {
                        _MatriculaRepositorio.AdicionarMatricula(Matricula);
                    TempData["MensagemSucesso"] = "Aluno Cadastrado Na tabela";
                  
                    
                    return RedirectToAction("Matricula",matriculaviewModel.MatriculaId,matriculas);
                    }
                }
                return ViewBag("AdicionarMatricula", matriculas);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Aluno Não Cadastrado ,detelhes do erro:{erro.Message}";
                return RedirectToAction("Matricula", matriculas);
            }
         

        }
      
        

    }
}
