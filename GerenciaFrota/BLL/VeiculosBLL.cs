using GerenciaFrota.DAL;
using GerenciaFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaFrota.BLL
{
    public class VeiculosBLL
    {
        private VeiculosDAL dal = new VeiculosDAL();

        public bool Insert(Veiculo veiculo)
        {
            try
            {
                dal.Insert(veiculo);
                return true;
            }
            catch (Exception ex)
            {
                return false;                
            }            
        }

        public bool Update(Veiculo veiculo)
        {
            try
            {
                dal.Update(veiculo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Veiculo GetVeiculo(int veiculoId)
        {
            Veiculo veiculo;
            try
            {
                veiculo = dal.GetVeiculo(veiculoId);
                return veiculo;
            }
            catch (Exception ex)
            {
                return new Veiculo();
            }
            
        }

        public List<Veiculo> GetVeiculos()
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            try
            {
                veiculos = dal.GetVeiculos();
                return veiculos;
            }
            catch (Exception ex)
            {
                return veiculos;
            }
        }

        public bool Delete(int veiculoId)
        {
            try
            {
                dal.Delete(veiculoId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TipoVeiculo> GetTipoVeiculos()
        {
            List<TipoVeiculo> tiposVeiculos = new List<TipoVeiculo>();
            try
            {
                tiposVeiculos = dal.GetTiposVeiculos();
                return tiposVeiculos;
            }
            catch (Exception ex)
            {
                return tiposVeiculos;
            }
        }

        public Veiculo GetVeiculoByChassi(string chassi)
        {
            Veiculo veiculo = null;
            try
            {
                veiculo = dal.GetVeiculoByChassi(chassi);
                return veiculo;
            }
            catch (Exception ex)
            {
                return veiculo;
            }

        }

    }
}