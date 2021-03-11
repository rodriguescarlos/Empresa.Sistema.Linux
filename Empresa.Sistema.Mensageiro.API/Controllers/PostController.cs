using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using Infra.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.API.Controllers
{
    //Ex.: http://localhost:5000/api/Post
    [Route("api/Post/")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostApplication app;
        private ILogFacede log;

        public PostController(IPostApplication app, ILogFacede log)
        {
            this.app = app;
            this.log = log;
        }

        #region Sincrono

        [HttpGet()]
        [Route("Post/ObterTodos/")]
        public ActionResult<IEnumerable<Post>> ObterTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                log.Write("ObterTodos");
                return Ok(this.app.ObterTodos());
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpGet()]
        [Route("Post/ObterPorId/{id}")]
        public ActionResult<Post> ObterPorId(int id)
        {
            log.Write("ObterPorId({0})", id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(this.app.ObterPorId(id));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpPost()]
        [Route("Post/Adicionar/")]
        public ActionResult<Post> Adicionar([FromBody] Post tipoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(app.Adicionar(tipoParametro));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut()]
        [Route("Post/Atualizar/")]
        public ActionResult<Post> Atualizar([FromBody] Post tipoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(app.Atualizar(tipoParametro));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete()]
        [Route("Post/Remover/{id}")]
        public ActionResult<bool> Remover(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(app.Remover(id));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet()]
        [Route("Post/ObterQueryManyToMany/")]
        public ActionResult<IEnumerable<Post>> ObterQueryManyToMany()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                log.Write("ObterQueryManyToMany");
                return Ok(this.app.ObterQueryManyToMany());
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpGet()]
        [Route("Post/ObterQueryMultipleRelationships/")]
        public ActionResult<IEnumerable<Post>> ObterQueryMultipleRelationships()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                log.Write("ObterQueryMultipleRelationships");
                return Ok(this.app.ObterQueryMultipleRelationships());
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }
        #endregion
    }
}
