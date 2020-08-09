﻿using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;
using EasyFreteApp.Presentation.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace EasyFreteApp.Presentation.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaioPrecoController : ControllerBase
    {
        private readonly IRaioPrecoService _service;

        public RaioPrecoController(IRaioPrecoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RaioPrecoDomain), 200)]
        public ActionResult<RaioPrecoDomain> Get(int id)
        {
            var user = _service.GetById(id);

            if (user == null)
                return NotFound();

            return user;
        }


        [HttpPost("list")]
        [ProducesResponseType(typeof(IEnumerable<RaioPrecoDomain>), 200)]
        public ActionResult List([FromBody] RaioPrecoSeletor seletor)
        {
            try
            {
                if (seletor == null)
                    throw new Exception("Filtro inválido");

                return Ok(new ResponseViewModel
                {
                    Data = _service.GetList(seletor),
                    Count = _service.Count(seletor)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(RaioPrecoDomain), 200)]
        public ActionResult Insert([FromBody] RaioPrecoDomain domain)
        {
            try
            {
              return StatusCode((int)HttpStatusCode.Created, _service.Insert(domain));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
