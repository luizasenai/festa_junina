using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_FESTAJUNINA.DAO;
using API_FESTAJUNINA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_FESTAJUNINA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngressoControllers : ControllerBase
    {
        private IngressoDAO _ingressoDAO;

        public IngressoControllers()
        {
            _ingressoDAO = new IngressoDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ingressos = _ingressoDAO.GetAll();
            return Ok(ingressos);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var ingresso = _ingressoDAO.GetId(id);
            if (ingresso == null)
            {
                return NotFound();
            }
            return Ok(ingresso);
        }

        [HttpPost]
        public IActionResult CriarIngresso(Ingresso ingresso)
        {
            _ingressoDAO.CriarIngresso(ingresso);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ValidarIngresso(int id, Ingresso ingresso)
        {
            if (_ingressoDAO.GetId(id) == null)
            {
                return NotFound();
            }

            _ingressoDAO.ValidarIngresso(id, ingresso);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletarIngresso(int id, Ingresso ingresso)
        {
            if (_ingressoDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _ingressoDAO.DeletarIngresso(id);
            return Ok();
        }
    }
}