using System.Collections.Generic;

namespace ConsoleAppCRUD
{
    // Interface para definir operações CRUD para Contato (Polimorfismo)
    public interface IContatoRepository
    {
        // Método para criar um novo contato
        void Create(Contato contato);

        // Método para ler um contato pelo ID
        Contato Read(int id);

        // Método para ler todos os contatos
        List<Contato> ReadAll();

        // Método para atualizar um contato existente
        void Update(Contato contato);

        // Método para deletar um contato pelo ID
        void Delete(int id);
    }
}
