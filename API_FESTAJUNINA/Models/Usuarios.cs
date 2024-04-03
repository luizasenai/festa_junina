using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_FESTAJUNINA.Models
{
  public class Usuarios
  {
    [Column("id_usuario")]
    public int IdUsuario { get; set; }
    [Column("nome_inteiro")]
    public string? NomeInteiro { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("senha")]
    public required string Senha { get; set; }
    [Column("telefone")]
    public required string Telefone { get; set; }
    [Column("perfil")]
    public required string Perfil { get; set; }
    [Column("status")]
    public required string Status { get; set; }

  }
}
