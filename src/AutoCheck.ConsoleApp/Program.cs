using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

List<Veiculo> vistorias = new List<Veiculo>();

MotorVistoria motor = new MotorVistoria();

bool sistemaEmExecucao = true;

while (sistemaEmExecucao)
{
    Console.WriteLine();
    Console.WriteLine(
        "=================================================="
    );
    Console.WriteLine(
        "       AUTOCHECK - MOTOR DE VISTORIA VEICULAR"
    );
    Console.WriteLine(
        "=================================================="
    );
    Console.WriteLine("1 - Realizar nova vistoria");
    Console.WriteLine("2 - Exibir relatório das vistorias");
    Console.WriteLine("0 - Sair");
    Console.WriteLine(
        "--------------------------------------------------"
    );
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine() ?? "";

    Console.WriteLine();

    switch (opcao)
    {
        case "1":
            Veiculo novoVeiculo = RealizarNovaVistoria();

            vistorias.Add(novoVeiculo);

            Console.WriteLine();
            Console.WriteLine(
                "Vistoria registrada com sucesso!"
            );
            break;

        case "2":
            if (vistorias.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma vistoria realizada até o momento."
                );
            }
            else
            {
                Console.WriteLine(
                    $"TOTAL DE VISTORIAS: {vistorias.Count}"
                );

                for (int i = 0; i < vistorias.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        $"VISTORIA {i + 1} DE {vistorias.Count}"
                    );

                    motor.ExibirRelatorio(vistorias[i]);
                }
            }
            break;

        case "0":
            sistemaEmExecucao = false;

            Console.WriteLine(
                "Sistema encerrado. Até a próxima!"
            );
            break;

        default:
            Console.WriteLine(
                "Opção inválida. Escolha 1, 2 ou 0."
            );
            break;
    }
}
static Veiculo RealizarNovaVistoria()
{
    Console.WriteLine(
        "=================================================="
    );
    Console.WriteLine("REALIZAR NOVA VISTORIA");
    Console.WriteLine(
        "=================================================="
    );

    Console.WriteLine("1 - Carro");
    Console.WriteLine("2 - Moto");
    Console.WriteLine("3 - Caminhão");

    string tipo;

    while (true)
    {
        Console.Write("Escolha o tipo de veículo: ");
        tipo = Console.ReadLine() ?? "";

        if (tipo == "1" || tipo == "2" || tipo == "3")
        {
            break;
        }

        Console.WriteLine(
            "Tipo inválido. Escolha 1, 2 ou 3."
        );
    }

    Console.WriteLine();
    Console.WriteLine("DADOS DO VEÍCULO");

    string marca = LerTextoObrigatorio("Marca: ");
    string modelo = LerTextoObrigatorio("Modelo: ");
    int ano = LerNumeroInteiro("Ano: ");
    double quilometragem =
        LerNumeroDecimal("Quilometragem: ");

    Veiculo veiculo;

    if (tipo == "1")
    {
        int quantidadePortas =
            LerNumeroInteiro("Quantidade de portas: ");

        veiculo = new Carro(
            marca,
            modelo,
            ano,
            quilometragem,
            quantidadePortas
        );
    }
    else if (tipo == "2")
    {
        int cilindradas =
            LerNumeroInteiro("Cilindradas: ");

        veiculo = new Moto(
            marca,
            modelo,
            ano,
            quilometragem,
            cilindradas
        );
    }
    else
    {
        int quantidadeEixos =
            LerNumeroInteiro("Quantidade de eixos: ");

        double capacidadeCargaToneladas =
            LerNumeroDecimal(
                "Capacidade de carga em toneladas: "
            );

        veiculo = new Caminhao(
            marca,
            modelo,
            ano,
            quilometragem,
            capacidadeCargaToneladas,
            quantidadeEixos
        );
    }

    Console.WriteLine();
    Console.WriteLine("AVALIAÇÃO DO CHECKLIST");
    Console.WriteLine(
        "Informe: Bom, Regular ou Ruim."
    );

    List<string> checklist =
        veiculo.ObterChecklistObrigatorio();

    foreach (string nomeItem in checklist)
    {
        Console.WriteLine();
        Console.WriteLine($"Item: {nomeItem}");

        string status = LerStatus();

        veiculo.AdicionarItemVistoriado(
            nomeItem,
            status
        );
    }

    return veiculo;
}
static string LerTextoObrigatorio(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);

        string texto = Console.ReadLine() ?? "";

        texto = texto.Trim();

        if (texto != "")
        {
            return texto;
        }

        Console.WriteLine(
            "Este campo não pode ficar vazio."
        );
    }
}
static int LerNumeroInteiro(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);

        string entrada = Console.ReadLine() ?? "";

        bool conversaoValida =
            int.TryParse(entrada, out int numero);

        if (conversaoValida && numero >= 0)
        {
            return numero;
        }

        Console.WriteLine(
            "Digite um número inteiro válido."
        );
    }
}
static double LerNumeroDecimal(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);

        string entrada = Console.ReadLine() ?? "";

        bool conversaoValida =
            double.TryParse(entrada, out double numero);

        if (conversaoValida && numero >= 0)
        {
            return numero;
        }

        Console.WriteLine(
            "Digite um número válido."
        );
    }
}
static string LerStatus()
{
    while (true)
    {
        Console.Write("Status: ");

        string status = Console.ReadLine() ?? "";

        status = status.Trim();

        if (status.Equals(
            "Bom",
            StringComparison.OrdinalIgnoreCase))
        {
            return "Bom";
        }

        if (status.Equals(
            "Regular",
            StringComparison.OrdinalIgnoreCase))
        {
            return "Regular";
        }

        if (status.Equals(
            "Ruim",
            StringComparison.OrdinalIgnoreCase))
        {
            return "Ruim";
        }

        Console.WriteLine(
            "Status inválido. Digite Bom, Regular ou Ruim."
        );
    }
}