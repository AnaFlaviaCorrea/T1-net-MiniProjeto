using AutoCheck.ConsoleApp.Models;

Console.WriteLine("=================================================");
Console.WriteLine("     AUTOCHECK .NET - TESTE DA CLASSE CARRO");
Console.WriteLine("=================================================");
Console.WriteLine();

Carro carro = new Carro(
    "Toyota",
    "Corolla 2.0 Flex",
    2021,
    45000,
    4
);

Console.WriteLine("DADOS DO VEÍCULO");
Console.WriteLine($"Marca: {carro.Marca}");
Console.WriteLine($"Modelo: {carro.Modelo}");
Console.WriteLine($"Ano: {carro.Ano}");
Console.WriteLine($"Quilometragem: {carro.Quilometragem:N0} km");
Console.WriteLine($"Quantidade de portas: {carro.QuantidadePortas}");

Console.WriteLine();
Console.WriteLine("CHECKLIST OBRIGATÓRIO");

List<string> checklist = carro.ObterChecklistObrigatorio();

foreach (string item in checklist)
{
    Console.WriteLine($"- {item}");
}