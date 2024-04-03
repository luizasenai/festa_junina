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
    public string NomeInteiro { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("senha")]
    public string Senha { get; set; }
    [Column("telefone")]
    public string Telefone { get; set; }
    [Column("perfil")]
    public string Perfil { get; set; }
    [Column("status")]
    public string Status { get; set; }

  }
}
