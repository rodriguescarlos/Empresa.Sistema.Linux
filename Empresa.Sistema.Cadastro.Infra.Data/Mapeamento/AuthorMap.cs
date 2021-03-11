using DapperExtensions.Mapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.Data.Mapeamento
{
    public class AuthorMap : ClassMapper<Author>
    {
        public AuthorMap()
        {
            Table("Author");
            this.AddIdentityColumn();
            this.AddColumnMap();
        }

        public virtual void AddIdentityColumn()
        {
            Map(u => u.AuthorId).Column("AuthorId").Key(KeyType.Identity);
        }

        public virtual void AddColumnMap()
        {
            Map(u => u.FirstName).Column("FirstName");
            Map(u => u.LastName).Column("LastName");
            Map(u => u.BirthdayDate).Column("BirthdayDate");
        }
    }
}
