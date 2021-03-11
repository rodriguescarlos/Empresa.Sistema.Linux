using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Interface.Base
{
    public interface IApplicationServiceSingleDTO<TEntityDTO>
        where TEntityDTO : class
    {
        TEntityDTO Adicionar(TEntityDTO parametro);

        TEntityDTO Atualizar(TEntityDTO parametro);

        TEntityDTO ObterPorId(int id);

        IEnumerable<TEntityDTO> ObterTodos();

        bool Remover(int id);
    }
}
