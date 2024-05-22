using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCRUD
{
    // Implementação da interface IContatoRepository
    public class ContatoRepository : IContatoRepository
    {
        // Lista de contatos
        private List<Contato> contatos = new List<Contato>();

        // Variável para gerar IDs únicos
        private int nextId = 1;

        // Criação de um novo contato
        public void Create(Contato contato)
        {
            contato.Id = nextId++; // Incrementa o ID para o próximo contato
            contatos.Add(contato); // Adiciona o contato à lista
        }

        // Leitura de um contato pelo ID
        public Contato Read(int id)
        {
            return contatos.FirstOrDefault(c => c.Id == id); // Retorna o contato ou null
        }

        // Leitura de todos os contatos
        public List<Contato> ReadAll()
        {
            return new List<Contato>(contatos); // Retorna uma cópia da lista de contatos
        }

        // Atualização de um contato existente
        public void Update(Contato contato)
        {
            var existingContato = Read(contato.Id); // Encontra o contato existente
            if (existingContato != null)
            {
                existingContato.Nome = contato.Nome; // Atualiza o nome
                existingContato.Telefone = contato.Telefone; // Atualiza o telefone
            }
        }

        // Remoção de um contato pelo ID
        public void Delete(int id)
        {
            var contato = Read(id); // Encontra o contato
            if (contato != null)
            {
                contatos.Remove(contato); // Remove o contato da lista
            }
        }
    }
}
