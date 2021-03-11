﻿using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Services
{
    public interface IPostService : IRepository<Post>
    {
        IEnumerable<Post> ObterQueryManyToMany();

        IEnumerable<Post> ObterQueryMultipleRelationships();
    }
}
