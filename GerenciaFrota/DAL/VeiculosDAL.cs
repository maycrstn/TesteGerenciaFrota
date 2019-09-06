using GerenciaFrota.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciaFrota.DAL
{
    
    public class VeiculosDAL
    {
        private FrotaContext db = new FrotaContext();

        public void Insert(Veiculo veiculo)
        {
            db.Veiculos.Add(veiculo);
            db.SaveChanges();
        }

        public void Update(Veiculo veiculo)
        {   
            db.Veiculos.Attach(veiculo);
            db.Entry(veiculo).Property("Cor").IsModified = true;
            db.SaveChanges();
        }
        public Veiculo GetVeiculo(int veiculoId)
        {
            return db.Veiculos.Find(veiculoId);
        }

        public List<Veiculo> GetVeiculos()
        {
            return db.Veiculos.Include(v => v.TipoVeiculo).ToList();
        }

        public void Delete(int veiculoId)
        {
            Veiculo veiculo = db.Veiculos.Find(veiculoId);
            db.Veiculos.Remove(veiculo);
            db.SaveChanges();
        }

        public List<TipoVeiculo> GetTiposVeiculos()
        {
            return db.TipoVeiculos.ToList();
        }

        public Veiculo GetVeiculoByChassi(string chassi)
        {
            Veiculo retornoVeiculo = db.Veiculos.Include(v => v.TipoVeiculo).Where(veiculo => veiculo.Chassi.Equals(chassi)).FirstOrDefault();
            return retornoVeiculo;
        }
        

    }
}