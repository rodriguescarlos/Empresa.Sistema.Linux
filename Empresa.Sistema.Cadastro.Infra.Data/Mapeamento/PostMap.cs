using DapperExtensions.Mapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.Data.Mapeamento
{
    public class PostMap : ClassMapper<Post>
    {
        public PostMap()
        {
            Table("Post");
            this.AddIdentityColumn();
            this.AddColumnMap();
        }

        public virtual void AddIdentityColumn()
        {
            Map(u => u.PostId).Column("PostId").Key(KeyType.Identity);
        }

        public virtual void AddColumnMap()
        {
            Map(u => u.Content).Column("Content");
            Map(u => u.DateCeated).Column("DateCeated");
            Map(u => u.DateUpdated).Column("DateUpdated");
            Map(u => u.Headline).Column("Headline");
        }
    }
}
