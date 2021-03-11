using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly ILogFacede _logger;

        public PostService(IPostRepository repository, ILogFacede logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public Post Adicionar(Post entidade)
        {
            return _repository.Adicionar(entidade);
        }

        public Post Atualizar(Post entidade)
        {
            return _repository.Atualizar(entidade);
        }

        public Post ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Post> ObterQueryManyToMany()
        {
            return _repository.ObterQueryManyToMany();
        }

        public IEnumerable<Post> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public bool Remover(Post entidade)
        {
            return _repository.Remover(entidade);
        }

        public IEnumerable<Post>  ObterQueryMultipleRelationships()
        {
            return _repository.ObterQueryMultipleRelationships();
        }
    }
}
