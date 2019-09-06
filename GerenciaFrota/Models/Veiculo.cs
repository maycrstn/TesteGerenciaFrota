using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciaFrota.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        [DisplayName("Código")]
        public int VeiculoId { get; set; }
        
        public string Chassi { get; set; }
        [DisplayName("Número de Passageiros")]
        public byte NumeroPassageiros { get; set; }
        public string Cor { get; set; }

        [ForeignKey("TipoVeiculo")]
        public int IdTipoVeiculo { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
    }
}