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

    private UsuariosDAO _usuariosDAO;

    public UsuariosController()
    {
        _usuariosDAO = new UsuariosDAO();
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = _usuariosDAO.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
        var usuario = _usuariosDAO.GetId(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult CriarUsuarios(Usuarios Usuarios)
    {
       _usuariosDAO.CriarUsario(Usuarios);
       return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarUsuarios(int id, Usuarios usuarios)
    {
        if (_usuariosDAO.GetId(id) == null)
        {
            return NotFound();
        }

        _usuariosDAO.AtualizarUsuarios(id, usuarios);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeletarUsuarios(int id, Usuarios usuarios)
    {
        if(_usuariosDAO.GetId(id) == null)
        {
            return NotFound();
        }
        _usuariosDAO.DeletarUsuario(id);
        return Ok();
    }


}