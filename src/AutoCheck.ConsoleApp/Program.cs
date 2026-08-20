using AutoCheck.ConsoleApp.Models;

Console.WriteLine("AUTOCHECK - TESTE DO ITEM DE VISTORIA");
Console.WriteLine();

ItemVistoria item = new ItemVistoria(
    "Nível de Óleo do Motor",
    "Péssimo"
);

Console.WriteLine($"Item: {item.Nome}");
Console.WriteLine($"Status: {item.Status}");