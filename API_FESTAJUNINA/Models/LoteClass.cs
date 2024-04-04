using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_FESTAJUNINA.Models
{
    
    public class Lote
    {
        [Column("id_lotes")]
        public int idlote { get; set; }
 
        [Column("valor_unitario")]
        public double? ValorUnitario { get; set; }
 
        [Column("quantidade_total")]
        public int? QuantidadeTotal { get; set; }
 
        [Column("saldo")]
        public int? Saldo { get; set; }
 
        [Column("evento_id_evento")]
        public int? IdEvento { get; set; }
        
        [Column("ativo")]
        public bool Ativo { get; set; }
 
        [Column("descricao")]
        public string? Descricao { get; set; }
 
       
 
       
 
         
    }
}
    
