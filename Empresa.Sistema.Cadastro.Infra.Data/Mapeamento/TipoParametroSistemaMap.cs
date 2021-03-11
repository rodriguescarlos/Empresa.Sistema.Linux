using DapperExtensions.Mapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;

namespace Empresa.Sistema.Cadastro.Infra.Data.Mapeamento
{
    public class TipoParametroSistemaMap : ClassMapper<TipoParametroSistema>
    {
        public TipoParametroSistemaMap()
        {
            Table("TB_TipoParametroSistema");
            this.AddIdentityColumn();
            this.AddColumnMap();
        }

        public virtual void AddIdentityColumn()
        {
            Map(u => u.TipoParametroId).Column("ID_TIP_PARM").Key(KeyType.Identity);
        }

        public virtual void AddColumnMap()
        {
            Map(u => u.NomeTipoParametro).Column("NOM_TIP_PARAM");
            Map(u => u.DataHoraCriacao).Column("DTHR_INCL");
        }
    }
}
