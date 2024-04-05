using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace API_FESTAJUNINA.Models
{
    public class Pedidos
    {

        [Column ("id_pedido")]
        public int? id_pedido { get; set; }

        [Column ("data")]
        public DateTime data {get; set;}

        [Column ("total")]
        public double total {get; set;}

        [Column ("quantidade")]
        public int quantidade {get; set;}

        [Column ("forma_pagamento")]
        public string? forma_pagamento {get; set;}

        [Column ("status")]
         public string? status {get; set;}

        [Column ("validacao_id_usuario")]
        public int validacao_id_usuario {get; set;}

        [Column ("usuario_id_usuario")]
        public int usuario_id_usuario {get; set;}
    }
}