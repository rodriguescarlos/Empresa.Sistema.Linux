using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Empresa.Sistema.Infra.Shared.Data.Repositories.Base;
using Infra.Logging.Interface;

namespace Empresa.Sistema.Cadastro.Infra.Data.Repositories
{
    public class ParametroSistemaRepository : RepositoryBase<ParametroSistema>, IParametroSistemaRepository
    {
        public ParametroSistemaRepository(IDbContext dbContext, ILogFacede logger)
            : base(dbContext, logger)
        {

        }


        public ParametroSistema Obter(string parametro)
        {
            ParametroSistema parametroRetorno = null;
            try
            {
                parametroRetorno = base.Obter(p => p.Nome, parametro).FirstOrDefault();
            }
            catch(Exception ex)
            {
                base._logger.Write(ex);
                throw;
            }

            return parametroRetorno;
        }

        public async Task<ParametroSistema> ObterAsync(string paramento)
        {
            try
            {
                using (var db = _dbContext.GetConnection())
                {
                    var result = await db.QueryAsync<ParametroSistema>("SP_CO_Parametro_Nome"
                        , new
                        {
                            P_Nome = paramento
                        }
                        , commandType: System.Data.CommandType.StoredProcedure);

                    return result.ToList().FirstOrDefault<ParametroSistema>();
                }
            }
            catch (Exception ex)
            {
                base._logger.Write(ex);
                throw;
            }
        }

        public ParametroSistema ObterQuery(string nomeParamentro)
        {
            string query = @"
SELECT  [ID_PARM] 'Identificador',
		[NOM_PARM] 'Nome',
		[DSC_PARM] 'Descricao',
		[CNTD_PARM] 'Conteudo',
		[DTHR_CRIA] 'DataCriacao',
		[DTHR_ALT] 'DataAlteracao',
		[USR_CRIA] 'UsuarioCriacao',
		[USR_ALT] 'UsuarioAlteracao'
FROM    [dbo].[TB_ParametroSistema]
WHERE   NOM_PARM = @P_NOME
            ";

            ParametroSistema parametroRetorno = null;
            using (var db = _dbContext.GetConnection())
            {
                parametroRetorno = db.Query<ParametroSistema>(query
                , new
                {
                    P_Nome = nomeParamentro
                }
                , commandType: System.Data.CommandType.Text).FirstOrDefault();
            }

            return parametroRetorno;
        }

        public ParametroSistema ObterQueryComObjetoFilho(string nomeParamento)
        {
            string query = @"

SELECT		[ID_PARM] 'identificador',
			[NOM_PARM] 'Nome',
			[DSC_PARM] 'Descricao',
			[CNTD_PARM] 'Conteudo',
			[DTHR_CRIA] 'DataCriacao',
			[DTHR_ALT] 'DataAlteracao',
			[USR_CRIA] 'UsuarioCriacao',
			[USR_ALT] 'UsuarioAlteracao',
			B.[ID_TIP_PARM] 'TipoParametroId', 
			[NOM_TIP_PARAM] 'NomeTipoParametro',
			[DTHR_INCL] 'DataHoraCriacao'
FROM		[dbo].[TB_ParametroSistema] A WITH(NOLOCK)
INNER JOIN	[dbo].[TB_TipoParametroSistema] B WITH(NOLOCK)
ON			A.ID_TIP_PARM = B.ID_TIP_PARM
WHERE		NOM_PARM = @P_NOME
            ";

            ParametroSistema parametroRetorno = null;
            using (var db = _dbContext.GetConnection())
            {
                parametroRetorno = db.Query<ParametroSistema, TipoParametroSistema, ParametroSistema>(
                query
                , map: (parametro, tipoParametro) =>
                {
                    parametro.TipoParametro = tipoParametro;
                    return parametro;
                }
                , param: new
                {
                    P_Nome = nomeParamento
                }
                , splitOn: "identificador,TipoParametroId"
                , commandType: System.Data.CommandType.Text
                ).FirstOrDefault();
            }

            return parametroRetorno;
        }

        //public override IEnumerable<Cliente> ObterTodos()
        //{
        //    IEnumerable<Cliente> retorno = null;

        //    using (var db = _dbContext.GetConnection())
        //    {
        //        var sql = @"Select
        //                         A.COD_CLIENTE 'ID'
        //                        , A.CLI_ENDERECO 'Logradouro'
        //                        , A.CLI_BAIRRO 'Bairro'
        //                        , A.CLI_CIDADE 'Cidade'
        //                        , A.CLI_ESTADO 'Estado'
        //                        , A.CLI_SENHA 'Senha'
        //                        , A.CLI_STATUS 'Status'
        //                        , C.COD_CLIENTE 'Cliente_ID'
        //                        , A.CLI_NOME 'NomeCompleto'
        //                        , E.COD_CLIENTE 'Email_ID'
        //                        , A.CLI_EMAIL 'Endereco'
        //                        from CLIENTE A 
        //                        INNER JOIN (SELECT B.COD_CLIENTE, B.CLI_NOME FROM CLIENTE B) C
        //                        ON A.COD_CLIENTE = C.COD_CLIENTE
        //                        INNER JOIN (SELECT D.COD_CLIENTE, D.CLI_NOME FROM CLIENTE D) E
        //                        ON A.COD_CLIENTE = E.COD_CLIENTE";

        //        retorno = db.Query<Cliente, Nome, Email, Cliente>(sql
        //            , (cliente, nome, email) => { 
        //                cliente.Nome = nome; 
        //                cliente.Email = email; 
        //                return cliente; 
        //            }, splitOn: "Cliente_ID,Email_ID", commandType: CommandType.Text).ToList();
        //    }

        //    return retorno;
        //}
    }
}
