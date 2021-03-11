using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Entidade
{
    public class Tag : EntityBase
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public List<Post> Posts { get; set; }
    }
}
