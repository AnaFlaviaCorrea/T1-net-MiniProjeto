using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

Console.WriteLine();
Console.WriteLine("==============================================");
Console.WriteLine("         TESTE DA CLASSE CAMINHÃO");
Console.WriteLine("==============================================");

Caminhao caminhao = new Caminhao(
    marca: "Volvo",
    modelo: "FH 540",
    ano: 2022,
    quilometragem: 150000,
    capacidadeCargaToneladas: 25.0,
    quantidadeEixos: 4
    
);
caminhao.AdicionarItemVistoriado(
    "Nível de Óleo do Motor",
    "Bom"
);

caminhao.AdicionarItemVistoriado(
    "Bateria e Sistema Elétrico",
    "Bom"
);

caminhao.AdicionarItemVistoriado(
    "Documentação Regularizada",
    "Regular"
);

caminhao.AdicionarItemVistoriado(
    "Sistema de Freios",
    "Bom"
);

caminhao.AdicionarItemVistoriado(
    "Pneus em bom estado",
    "Regular"
);

caminhao.AdicionarItemVistoriado(
    "Sistema de Iluminação",
    "Ruim"
);

Console.WriteLine();
Console.WriteLine("DADOS DO VEÍCULO");
Console.WriteLine($"Marca: {caminhao.Marca}");
Console.WriteLine($"Modelo: {caminhao.Modelo}");
Console.WriteLine($"Ano: {caminhao.Ano}");
Console.WriteLine(
    $"Quilometragem: {caminhao.Quilometragem:N0} km"
);
Console.WriteLine(
    $"Quantidade de eixos: {caminhao.QuantidadeEixos}"
);
Console.WriteLine(
    $"Capacidade de carga: " +
    $"{caminhao.CapacidadeCargaToneladas:N1} toneladas"
);

Console.WriteLine();
Console.WriteLine("CHECKLIST OBRIGATÓRIO");

List<string> checklistCaminhao =
    caminhao.ObterChecklistObrigatorio();

foreach (string item in checklistCaminhao)
{
    Console.WriteLine($"- {item}");
}

MotorVistoria motor = new MotorVistoria();

motor.ExibirRelatorio(caminhao);
