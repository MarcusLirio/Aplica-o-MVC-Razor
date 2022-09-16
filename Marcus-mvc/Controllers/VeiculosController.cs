using Marcus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcus_mvc.Controllers
{
    public class VeiculosController : Controller
    {
        // GET: Veiculos
        public ActionResult Adicionar()
        {

            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Cadastro de Veiculos";
            return View();
        }

        public ActionResult Alterar(int id)
        {

            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Atualizar cadastro veiculos" + id;
            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            ViewBag.Veiculo = veiculo;


            return View();
        }

        public ActionResult Excluir(int id)
        {

            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Excluir cadastro veiculos" + id;

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);

            ViewBag.Veiculo = veiculo;
            return View();
        }


        [HttpPost]
        public void Salvar()
        {
            var veiculo = new Veiculos();
            veiculo.Id = Convert.ToInt32("0" + Request["id"]);
            veiculo.Nome = Request["nome"];
            veiculo.Modelo = Request["modelo"];
            veiculo.Ano = Convert.ToInt16(Request["fabricacao"]);
            veiculo.Fabricacao = Convert.ToInt16(Request["fabricacao"]);
            veiculo.Cor = Request["nome"];
            veiculo.Combustivel = Convert.ToByte(Request["combustivel"]);
            veiculo.Automatico = false;
            veiculo.Valor = Convert.ToDecimal(Request["Valor"]);
            veiculo.Ativo = true;

            veiculo.Salvar();

            Response.Redirect("/Home/Veiculo");
        }

        [HttpPost]
        public void Excluir()
        {
            var veiculo = new Veiculos();
            veiculo.Id = Convert.ToInt32("0" + Request["id"]);

            veiculo.Excluir();
            Response.Redirect("/Home/Veiculo");
        }
    }
}