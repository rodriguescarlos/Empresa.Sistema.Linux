using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> ObterQueryManyToMany();

        IEnumerable<Post> ObterQueryMultipleRelationships();
    }
}
