using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Evento
{
    [Column("id")]
    public required int IdEvento { get; set; }
 
    [Column("data_evento")]
    public required DateTime DataEvento { get; set; }
 
    [Column("total_ingressos")]
    public required int TotalIngressos { get; set; }
 
    [Column("descricao")]
    public string? Descricao { get; set; }
 
    [Column("imagem_url")]
    public string? ImagemUrl { get; set; }
 
    [Column("local")]
    public required string Local { get; set; }
 
    [Column("ativo")]
    public required int Ativo { get; set; }
}
}