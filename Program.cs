using System.Text;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
Suite? suite = null;
Reserva? reserva = null;

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("       SISTEMA DE HOSPEDAGEM HOTEL      ");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Cadastrar Suíte");
    Console.WriteLine("2. Cadastrar Hóspedes e Definir Estadia");
    Console.WriteLine("3. Exibir Resumo da Reserva");
    Console.WriteLine("4. Sair");
    Console.WriteLine("========================================");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("--- CADASTRO DE SUÍTE ---");
            Console.Write("Digite o tipo da suíte (Ex: Premium, Luxo, Master): ");
            string tipo = Console.ReadLine() ?? "Padrão";

            Console.Write("Digite a capacidade de pessoas: ");
            if (int.TryParse(Console.ReadLine(), out int capacidade))
            {
                Console.Write("Digite o valor da diária (Ex: 80.00): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal valorDiaria))
                {
                    suite = new Suite(tipo, capacidade, valorDiaria);
                    Console.WriteLine("\nSuíte cadastrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nValor da diária inválido.");
                }
            }
            else
            {
                Console.WriteLine("\nCapacidade inválida.");
            }
            break;

        case "2":
            Console.Clear();
            if (suite == null)
            {
                Console.WriteLine("Atenção: Você precisa cadastrar uma suíte primeiro (Opção 1)!");
                break;
            }

            Console.WriteLine("--- CADASTRO DE HÓSPEDES ---");
            hospedes.Clear();

            Console.Write("Quantos hóspedes deseja cadastrar? ");
            if (int.TryParse(Console.ReadLine(), out int qtdHospedes))
            {
                try
                {
                    for (int i = 0; i < qtdHospedes; i++)
                    {
                        Console.WriteLine($"\n--- Hóspede {i + 1} ---");
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine() ?? "";
                        Console.Write("Sobrenome: ");
                        string sobrenome = Console.ReadLine() ?? "";

                        hospedes.Add(new Pessoa(nome, sobrenome));
                    }

                    Console.Write("\nQuantos dias de reserva? ");
                    if (int.TryParse(Console.ReadLine(), out int dias))
                    {
                        reserva = new Reserva(dias);
                        reserva.CadastrarSuite(suite);
                        reserva.CadastrarHospedes(hospedes);

                        Console.WriteLine("\nHóspedes cadastrados e reserva efetuada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nQuantidade de dias inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro ao cadastrar hóspedes: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("\nQuantidade inválida.");
            }
            break;

        case "3":
            Console.Clear();
            if (reserva == null || suite == null)
            {
                Console.WriteLine("Nenhuma reserva efetuada no momento.");
            }
            else
            {
                Console.WriteLine("--- RESUMO DA RESERVA ---");
                Console.WriteLine($"Tipo da Suíte: {suite.TipoSuite} (Capacidade: {suite.Capacidade} pessoas)");
                Console.WriteLine($"Valor da Diária: {suite.ValorDiaria:C}");
                Console.WriteLine($"Total de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
                Console.WriteLine($"Valor Total da Estadia: {reserva.CalcularValorDiaria():C}");
                if (reserva.DiasReservados > 10)
                {
                    Console.WriteLine("*(Desconto de 10% aplicado para estadias acima de 10 dias)*");
                }
            }
            break;

        case "4":
            exibirMenu = false;
            Console.WriteLine("\nObrigado por usar o sistema de hotelaria. Até logo!");
            break;

        default:
            Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para tentar novamente.");
            break;
    }

    if (exibirMenu)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}