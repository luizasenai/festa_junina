using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_FESTAJUNINA.Models;
using Microsoft.AspNetCore.Mvc;
using API_FESTAJUNINA.DAO;

namespace API_FESTAJUNINA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{

    private UsuariosDAO _UsuariosDAO;
    private object usuarios;

    public UsuariosController()
    {
        _UsuariosDAO = new UsuariosDAO();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var personagem = _UsuariosDAO.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
        var Usuarios = _UsuariosDAO.;
        if (Usuarios == null)
        {
            return NotFound();
        }
        return Ok(Usuarios);
    }

    // [HttpPost]
    // public IActionResult CriarUsuarios(Usuarios Usuarios)
    // {
    //     _UsuariosDAO.CriarUsuarios(Usuarios)
    //     }


}