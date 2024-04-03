using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_FESTAJUNINA.Models
{
    public class Ingresso
    {

        [Column("id_ingresso")]
        public int IdIngresso { get; set; }

        [Column("valor")]
        public string Valor { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("codigo_qr")]
        public string CodigoQr { get; set; }

        [Column("usuario_id_usuario")]
        public int UsuarioId { get; set; }

        [Column("usuario_pedido_id_usuario")]
        public int UsuarioPedido { get; set; }

        [Column("lotes_id_lotes")]
        public int LotesId { get; set; }
    }
}