using System.Collections.Generic;

namespace ConsoleAppCRUD
{
    // Classe de serviço para gerenciar contatos
    public class ContatoService
    {
        // Campo para armazenar o repositório de contatos (Encapsulamento)
        private readonly IContatoRepository _contatoRepository;

        // Construtor que recebe um repositório de contatos
        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        // Método para adicionar um novo contato
        public void AdicionarContato(string nome, string telefone)
        {
            var contato = new Contato(0, nome, telefone); // Cria um novo objeto Contato
            _contatoRepository.Create(contato); // Adiciona o contato no repositório
        }

        // Método para obter um contato pelo ID
        public Contato ObterContato(int id)
        {
            return _contatoRepository.Read(id); // Retorna o contato do repositório
        }

        // Método para obter todos os contatos
        public List<Contato> ObterTodosContatos()
        {
            return _contatoRepository.ReadAll(); // Retorna todos os contatos do repositório
        }

        // Método para atualizar um contato existente
        public void AtualizarContato(int id, string nome, string telefone)
        {
            var contato = new Contato(id, nome, telefone); // Cria um objeto Contato com o ID existente
            _contatoRepository.Update(contato); // Atualiza o contato no repositório
        }

        // Método para remover um contato pelo ID
        public void RemoverContato(int id)
        {
            _contatoRepository.Delete(id); // Remove o contato do repositório
        }
    }
}
