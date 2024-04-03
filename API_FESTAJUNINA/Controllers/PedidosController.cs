using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_FESTAJUNINA.DAO;
using API_FESTAJUNINA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_FESTAJUNINA.Controllers
{
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private PedidoDAO _PedidoDAO;

        public PedidosController()
        {
            _PedidoDAO = new PedidoDAO();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Pedidos = _PedidoDAO.GetAll();
            return Ok(Pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var Pedidos = _PedidoDAO.GetId(id);
            if(Pedidos==null)
            {
                return NotFound();
            }
            return Ok(Pedidos);
        }
         [HttpPost]
            public IActionResult FazerPedido (Pedidos pedido)
            {
                _PedidoDAO.FazerPedido(pedido);
                return Ok();
            }
            [HttpPut("{id}")]
            public IActionResult AtualizarPedido (int id, Pedidos pedido)
            {
                if(_PedidoDAO.GetId(id) ==null)
                {
                    return NotFound();
                }
                _PedidoDAO.AtualizarPedido(id,pedido);

                return Ok();
        }
        [HttpDelete("{id}")]
    public IActionResult DeletarPersonagem(int id)
    {
        if (_PedidoDAO.GetId(id) == null)
        {
            return NotFound();
        }
    _PedidoDAO.DeletarPedido(id);
    
    return Ok ();
    }
    }
}
    
