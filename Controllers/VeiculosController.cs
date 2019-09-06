using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciaFrota.BLL;
using GerenciaFrota.Models;

namespace GerenciaFrota.Controllers
{
    public class VeiculosController : Controller
    {
        private VeiculosBLL bll = new VeiculosBLL();

        // GET: Veiculos
        public ActionResult Index()
        {
            var veiculos = bll.GetVeiculos();
            return View(veiculos);
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int veiculoId)
        {
            Veiculo veiculo = bll.GetVeiculo(veiculoId);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        public ActionResult Create(int? veiculoId = 0)
        {
            
            Veiculo veiculo = bll.GetVeiculo(veiculoId ?? 0);
            if (veiculo == null)
            {
                veiculo = new Veiculo();
                veiculo.IdTipoVeiculo = 1;
                veiculo.NumeroPassageiros = 2;
            }
            ViewBag.TipoVeiculo = new SelectList(bll.GetTipoVeiculos(), "IdTipoVeiculo", "TipoVeiculoDescricao", veiculo.IdTipoVeiculo);
            return View(veiculo);
        }

        // POST: Veiculos/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeiculoId,Chassi,NumeroPassageiros,Cor,IdTipoVeiculo")] Veiculo veiculo)
        {
            string validaNumPassageiros = VerificaNumeroPassageiros(veiculo);
            if (!String.IsNullOrEmpty(validaNumPassageiros))
            {
                ModelState.AddModelError("NumeroPassageiros", validaNumPassageiros);
            }
            if (veiculo.VeiculoId == 0)
            {
                string validaChassi = VerificaChassi(veiculo);
                if (!String.IsNullOrEmpty(validaChassi))
                {
                    ModelState.AddModelError("Chassi", validaChassi);
                }
            }

            if (ModelState.IsValid)
            {
                bool result = Salvar(veiculo);
                if (result) return RedirectToAction("Index");
            }

            ViewBag.TipoVeiculo = new SelectList(bll.GetTipoVeiculos(), "IdTipoVeiculo", "TipoVeiculoDescricao", veiculo.IdTipoVeiculo);
            return View(veiculo);
        }

        public bool Salvar(Veiculo veiculo)
        {
            bool result;
            if (veiculo.VeiculoId == 0)
            {
                result = bll.Insert(veiculo);
            }
            else
            {
                result = bll.Update(veiculo);
            }
            return result;
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(int veiculoId)
        {
            Veiculo veiculo = bll.GetVeiculo(veiculoId);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int veiculoId)
        {
            //Veiculo veiculo = bll.GetVeiculo(veiculoId);
            bool result = bll.Delete(veiculoId);

            return RedirectToAction("Index");
        }

        public string VerificaNumeroPassageiros(Veiculo veiculo)
        {
            string msgErro = String.Empty;
            if (veiculo.IdTipoVeiculo == 1 && veiculo.NumeroPassageiros != 2)
            {
                msgErro = "Tipo de veículo Caminhão deve ter sempre 2 passageiros";
            }
            else if (veiculo.IdTipoVeiculo == 2 && veiculo.NumeroPassageiros != 42)
            {
                msgErro = "Tipo de veículo ônibus deve ter sempre 42 passageiros";
            }
            return msgErro;
        }

        public string VerificaChassi(Veiculo veiculo)
        {
            string msgErro = String.Empty;
            Veiculo veiculoBusca = bll.GetVeiculoByChassi(veiculo.Chassi);
            if (veiculoBusca != null)
            {
                msgErro = "Chassi já cadastrado. Altere o chassi para salvar.";
            }
            return msgErro;
        }

        [HttpPost]
        public ActionResult FiltrarChassi(string chassi)
        {
            Veiculo veiculoBusca = bll.GetVeiculoByChassi(chassi);
            List<Veiculo> listVeiculo = new List<Veiculo>();
            listVeiculo.Add(veiculoBusca);
            return PartialView("_ListVeiculos", listVeiculo);
        }
    }
}