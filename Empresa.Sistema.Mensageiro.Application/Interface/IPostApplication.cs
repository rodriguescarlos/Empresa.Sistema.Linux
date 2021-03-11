using Empresa.Sistema.Cadastro.Application.Interface.Base;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Interface
{
    public interface IPostApplication : IApplicationServiceSingleDTO<Post>
    {
        IEnumerable<Post> ObterQueryManyToMany();

        IEnumerable<Post> ObterQueryMultipleRelationships();
    }
}
