using System;

namespace ConsoleAppCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Lista Telefônica"; // Define o título do console

            // Define as cores para os textos
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Limpa a tela inicialmente
            Console.Clear();

            // Criação do repositório de contatos
            IContatoRepository contatoRepository = new ContatoRepository();

            // Criação do serviço de contatos
            ContatoService contatoService = new ContatoService(contatoRepository);

            // Loop principal do programa
            while (true)
            {
                // Exibe opções para o usuário
                Console.WriteLine();
                Console.WriteLine("========== Lista Telefônica ==========");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Adicionar Contato");
                Console.WriteLine("2. Listar Contatos");
                Console.WriteLine("3. Atualizar Contato");
                Console.WriteLine("4. Remover Contato");
                Console.WriteLine("5. Sair");
                Console.WriteLine("======================================");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                // Executa a ação correspondente à opção escolhida
                switch (opcao)
                {
                    case "1":
                        AdicionarContato(contatoService);
                        break;
                    case "2":
                        ListarContatos(contatoService);
                        break;
                    case "3":
                        AtualizarContato(contatoService);
                        break;
                    case "4":
                        RemoverContato(contatoService);
                        break;
                    case "5":
                        Console.WriteLine("Saindo do programa...");
                        return; // Sai do programa
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        // Método para adicionar um contato
        private static void AdicionarContato(ContatoService contatoService)
        {
            Console.WriteLine();
            Console.WriteLine("===== Adicionar Contato =====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine(); // Lê o nome do contato
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine(); // Lê o telefone do contato

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Nome e Telefone não podem estar vazios.");
                Console.ResetColor();
            }
            else
            {
                contatoService.AdicionarContato(nome, telefone); // Adiciona o contato usando o serviço
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Contato adicionado com sucesso.");
                Console.ResetColor(); // Reseta as cores
            }
            Console.WriteLine("===============================");
        }

        // Método para listar todos os contatos
        private static void ListarContatos(ContatoService contatoService)
        {
            Console.WriteLine();
            Console.WriteLine("===== Lista de Contatos =====");
            var contatos = contatoService.ObterTodosContatos(); // Obtém todos os contatos

            if (contatos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum contato encontrado.");
                Console.ResetColor();
            }
            else
            {
                foreach (var contato in contatos)
                {
                    Console.WriteLine(contato); // Exibe cada contato
                }
            }
            Console.WriteLine("=============================");
        }

        // Método para atualizar um contato
        private static void AtualizarContato(ContatoService contatoService)
        {
            Console.WriteLine();
            Console.WriteLine("===== Atualizar Contato =====");
            Console.Write("ID do contato a atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: ID inválido.");
                Console.ResetColor();
                return;
            }

            var contatoExistente = contatoService.ObterContato(id);
            if (contatoExistente == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Contato não encontrado.");
                Console.ResetColor();
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine(); // Lê o novo nome do contato
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine(); // Lê o novo telefone do contato

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Nome e Telefone não podem estar vazios.");
                Console.ResetColor();
            }
            else
            {
                contatoService.AtualizarContato(id, nome, telefone); // Atualiza o contato usando o serviço
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Contato atualizado com sucesso.");
                Console.ResetColor(); // Reseta as cores
            }
            Console.WriteLine("===============================");
        }

        // Método para remover um contato
        private static void RemoverContato(ContatoService contatoService)
        {
            Console.WriteLine();
            Console.WriteLine("===== Remover Contato =====");
            Console.Write("ID do contato a remover: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: ID inválido.");
                Console.ResetColor();
                return;
            }

            var contatoExistente = contatoService.ObterContato(id);
            if (contatoExistente == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Contato não encontrado.");
                Console.ResetColor();
                return;
            }

            contatoService.RemoverContato(id); // Remove o contato usando o serviço
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contato removido com sucesso.");
            Console.ResetColor(); // Reseta as cores
            Console.WriteLine("===============================");
        }
    }
}
