using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciaFrota.Models
{
    [Table("TipoVeiculos")]
    public class TipoVeiculo
    {
        [Key]
        public int IdTipoVeiculo { get; set; }
        public string TipoVeiculoDescricao { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; }
    }
}