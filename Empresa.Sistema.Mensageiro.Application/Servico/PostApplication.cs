using AutoMapper;
using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Servico
{
    public class PostApplication : IPostApplication
    {
        private readonly IMapper _mapper;
        private IPostService _service;
        private ILogFacede _logger;

        public PostApplication(IPostService postService, IMapper mapper, ILogFacede logger)
        {
            this._service = postService;
            this._mapper = mapper;
            this._logger = logger;
        }
        public Post Adicionar(Post parametro)
        {
            return _service.Adicionar(parametro);
        }

        public Post Atualizar(Post parametro)
        {
            return _service.Atualizar(parametro);
        }

        public Post ObterPorId(int id)
        {
            return _service.ObterPorId(id);
        }

        public IEnumerable<Post> ObterQueryManyToMany()
        {
            return _service.ObterQueryManyToMany();
        }

        public IEnumerable<Post> ObterTodos()
        {
            return _service.ObterTodos();
        }

        public bool Remover(int id)
        {
            Post post = new Post();
            post.PostId = id;

            return _service.Remover(post);
        }

        public IEnumerable<Post> ObterQueryMultipleRelationships()
        {
            return _service.ObterQueryMultipleRelationships();
        }
    }
}
