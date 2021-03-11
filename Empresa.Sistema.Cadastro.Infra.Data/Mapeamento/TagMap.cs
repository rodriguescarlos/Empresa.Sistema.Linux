using DapperExtensions.Mapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.Data.Mapeamento
{
    public class TagMap : ClassMapper<Tag>
    {
        public TagMap()
        {
            Table("Tag");
            this.AddIdentityColumn();
            this.AddColumnMap();
        }

        public virtual void AddIdentityColumn()
        {
            Map(u => u.TagId).Column("TagId").Key(KeyType.Identity);
        }

        public virtual void AddColumnMap()
        {
            Map(u => u.TagName).Column("TagName");
        }
    }
}
