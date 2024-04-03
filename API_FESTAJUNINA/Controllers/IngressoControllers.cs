using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_FESTAJUNINA.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
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
    }
}