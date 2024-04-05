using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Evento
{
    [Column("id_evento")]
    public required int IdEvento { get; set; }

    [Column("valor_unitario")]
    public required double ValorUnitario { get; set; }
 
    [Column("quantidade_total")]
    public required int QuantidadeTotal { get; set; }

    [Column("saldo")]
    public required int Saldo { get; set; }
 
    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("data_evento")]
    public required DateTime DataEvento { get; set; }
 
    [Column("imagem_url")]
    public string? ImagemUrl { get; set; }
 
    [Column("local")]
    public required string Local { get; set; }
 
    [Column("ativo")]
    public required int Ativo { get; set; }
     
}
}