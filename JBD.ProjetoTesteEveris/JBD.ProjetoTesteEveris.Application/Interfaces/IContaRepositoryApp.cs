using JBD.ProjetoTesteEveris.Domain.DTOS;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Application.Interfaces
{
    public interface IContaRepositoryApp
    {
        List<ContaDTO> ListarContas(string agOrigem, string numContaOrigem, string agDestino, string numContaDestino);
        List<ContaDTO> ListarContas(string nome, string cnpjcpf);
        ContaDTO ObterConta(string agConta, string numConta);
        ContaDTO ObterContaById(int Id);
        void Salvar(ContaDTO conta);
        void Atualizar(ContaDTO conta);
        void Deletar(int Id);
    }
}
