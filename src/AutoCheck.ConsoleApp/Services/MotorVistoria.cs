using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services;

public class MotorVistoria
{
    public int CalcularPontuacao(Veiculo veiculo)
    {
        int pontuacaoTotal = 0;

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Bom")
            {
                pontuacaoTotal += 10;
            }
            else if (item.Status == "Regular")
            {
                pontuacaoTotal += 5;
            }
            else if (item.Status == "Ruim")
            {
                pontuacaoTotal += 0;
            }
        }

        return pontuacaoTotal;
    }

    public int CalcularPontuacaoMaxima(Veiculo veiculo)
    {
        int quantidadeItens = veiculo.VistoriaRealizada.Count;
        int pontuacaoMaxima = quantidadeItens * 10;

        return pontuacaoMaxima;
    }

    public double CalcularPercentual(Veiculo veiculo)
    {
        int pontuacaoObtida = CalcularPontuacao(veiculo);
        int pontuacaoMaxima = CalcularPontuacaoMaxima(veiculo);

        if (pontuacaoMaxima == 0)
        {
            return 0;
        }

        double percentual =
            (double)pontuacaoObtida / pontuacaoMaxima * 100;

        return percentual;
    }
    public string ObterClassificacao(Veiculo veiculo)
    {
        if (veiculo.VistoriaRealizada.Count == 0)
        {
            return "VISTORIA NÃO REALIZADA";
        }
        double percentual = CalcularPercentual(veiculo);

        if (percentual >= 90)
        {
            return "APROVADO COM EXCELÊNCIA";
        }
        else if (percentual >= 60)
        {
            return "APROVADO COM APONTAMENTOS";
        }
        else
        {
            return "REPROVADO";
        }
    }
    public string ObterRecomendacao(string nomeItem)
    {
        switch (nomeItem)
        {
            case "Nível de Óleo do Motor":
                return "Verificar o nível e realizar a troca do óleo.";

            case "Bateria e Sistema Elétrico":
                return "Testar a bateria e revisar o sistema elétrico.";

            case "Documentação Regularizada":
                return "Regularizar a documentação do veículo.";

            case "Estepe e Macaco":
                return "Calibrar o estepe e verificar o funcionamento do macaco.";

            case "Triângulo de Sinalização":
                return "Providenciar um triângulo de sinalização adequado.";

            case "Ar Condicionado Funcional":
                return "Realizar higienização e verificar o gás refrigerante.";

            case "Estado da Corrente":
                return "Lubrificar, ajustar ou substituir a corrente.";

            case "Desgaste dos Pneus":
                return "Verificar o desgaste e considerar a troca dos pneus.";

            case "Funcionamento do Tacógrafo":
                return "Revisar e regularizar o funcionamento do tacógrafo.";

            case "Sistema de Freios a Ar":
                return "Realizar revisão imediata do sistema de freios a ar.";

            default:
                return "Encaminhar o item para avaliação técnica.";
        }
    }
    public void ExibirRecomendacoes(Veiculo veiculo)
    {
        Console.WriteLine();
        Console.WriteLine(
            "RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA"
        );

        if (veiculo.VistoriaRealizada.Count == 0)
        {
            Console.WriteLine(
                "A vistoria ainda não possui itens avaliados."
            );

            return;
        }
        bool possuiItemRuim = false;
        bool possuiItemRegular = false;

        Console.WriteLine();
        Console.WriteLine(
            "RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA"
        );

        Console.WriteLine();
        Console.WriteLine(
            "ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):"
        );

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Ruim")
            {
                possuiItemRuim = true;

                Console.WriteLine(
                    $"- {item.Nome}: " +
                    $"{ObterRecomendacao(item.Nome)}"
                );
            }
        }

        if (!possuiItemRuim)
        {
            Console.WriteLine("- Nenhum item crítico.");
        }

        Console.WriteLine();
        Console.WriteLine(
            "ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):"
        );

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular")
            {
                possuiItemRegular = true;

                Console.WriteLine(
                    $"- {item.Nome}: " +
                    $"{ObterRecomendacao(item.Nome)}"
                );
            }
        }

        if (!possuiItemRegular)
        {
            Console.WriteLine("- Nenhum item de atenção.");
        }

        if (!possuiItemRuim && !possuiItemRegular)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Nenhuma pendência mecânica identificada. " +
                "Veículo liberado para operação!"
            );
        }
    }
    public int ObterPontuacaoItem(ItemVistoria item)
    {
        if (item.Status == "Bom")
        {
            return 10;
        }
        else if (item.Status == "Regular")
        {
            return 5;
        }
        else
        {
            return 0;
        }
    }
    public void ExibirRelatorio(Veiculo veiculo)
    {
        Console.WriteLine(
            "============================================================"
        );

        Console.WriteLine("DADOS DO VEÍCULO:");

        if (veiculo is Carro carro)
        {
            Console.WriteLine("- Tipo: Carro");
            Console.WriteLine(
                $"- Marca e modelo: {carro.Marca} {carro.Modelo}"
            );
            Console.WriteLine(
                $"- Ano: {carro.Ano} | " +
                $"Quilometragem: {carro.Quilometragem:N0} km"
            );
            Console.WriteLine(
                $"- Quantidade de portas: {carro.QuantidadePortas}"
            );
        }
        else if (veiculo is Moto moto)
        {
            Console.WriteLine("- Tipo: Moto");
            Console.WriteLine(
                $"- Marca e modelo: {moto.Marca} {moto.Modelo}"
            );
            Console.WriteLine(
                $"- Ano: {moto.Ano} | " +
                $"Quilometragem: {moto.Quilometragem:N0} km"
            );
            Console.WriteLine(
                $"- Cilindradas: {moto.Cilindradas} cc"
            );
        }
        else if (veiculo is Caminhao caminhao)
        {
            Console.WriteLine("- Tipo: Caminhão");
            Console.WriteLine(
                $"- Marca e modelo: " +
                $"{caminhao.Marca} {caminhao.Modelo}"
            );
            Console.WriteLine(
                $"- Ano: {caminhao.Ano} | " +
                $"Quilometragem: {caminhao.Quilometragem:N0} km"
            );
            Console.WriteLine(
                $"- Quantidade de eixos: " +
                $"{caminhao.QuantidadeEixos}"
            );
            Console.WriteLine(
                $"- Capacidade de carga: " +
                $"{caminhao.CapacidadeCargaToneladas:N1} toneladas"
            );
        }

        Console.WriteLine();
        Console.WriteLine(
            $"ITENS INSPECIONADOS " +
            $"({veiculo.VistoriaRealizada.Count} ITENS):"
        );

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            string simbolo;

            if (item.Status == "Bom")
            {
                simbolo = "[OK]";
            }
            else if (item.Status == "Regular")
            {
                simbolo = "[!]";
            }
            else
            {
                simbolo = "[X]";
            }

            int pontos = ObterPontuacaoItem(item);

            Console.WriteLine(
                $"{simbolo} {item.Nome} - " +
                $"Status: {item.Status} ({pontos} pts)"
            );
        }

        int pontuacaoObtida = CalcularPontuacao(veiculo);

        int pontuacaoMaxima =
            CalcularPontuacaoMaxima(veiculo);

        double percentual =
            CalcularPercentual(veiculo);

        string classificacao =
            ObterClassificacao(veiculo);

        Console.WriteLine();
        Console.WriteLine("RESUMO DA PONTUAÇÃO:");

        Console.WriteLine(
            $"- Pontuação atingida: {pontuacaoObtida} " +
            $"de {pontuacaoMaxima} pontos possíveis"
        );

        Console.WriteLine(
            $"- Percentual de aprovação: {percentual:F1}%"
        );

        Console.WriteLine(
            $"- Classificação final: [ {classificacao} ]"
        );

        ExibirRecomendacoes(veiculo);

        Console.WriteLine(
            "============================================================"
        );
    }
}



