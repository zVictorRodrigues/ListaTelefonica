using System;

namespace ConsoleAppCRUD
{
    // Classe Contato representa um contato na lista telefônica
    public class Contato
    {
        // Propriedade ID do contato
        public int Id { get; set; }

        // Propriedade Nome do contato
        public string Nome { get; set; }

        // Propriedade Telefone do contato
        public string Telefone { get; set; }

        // Construtor da classe Contato
        public Contato(int id, string nome, string telefone)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
        }

        // Método ToString sobrescrito para exibir informações do contato
        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Telefone: {Telefone}";
        }
    }
}
