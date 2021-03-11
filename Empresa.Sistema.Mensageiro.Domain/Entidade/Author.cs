using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Entidade
{
    public class Author : EntityBase
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }

    }
}
