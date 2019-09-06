using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciaFrota.Models
{
    public class FrotaContext : DbContext
    {
        public FrotaContext() : base("name=FrotaContextDB")
        {            
        }

        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<TipoVeiculo> TipoVeiculos { get; set; }
    }
}