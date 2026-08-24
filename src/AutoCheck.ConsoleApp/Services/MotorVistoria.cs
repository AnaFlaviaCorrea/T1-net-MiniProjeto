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
    public string ObterAcaoCorporativa(Veiculo veiculo)
    {
        if (veiculo.VistoriaRealizada.Count == 0)
        {
            return "Nenhuma ação corporativa definida.";
        }

        double percentual = CalcularPercentual(veiculo);

        if (percentual >= 90)
        {
            return "Liberado para compra ou revenda imediata.";
        }
        else if (percentual >= 60)
        {
            return "Exige negociação de desconto para cobrir os reparos necessários.";
        }
        else
        {
            return "Veículo recusado pela concessionária.";
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

            case "Pneus em bom estado":
                return "Verificar a pressão e o desgaste dos pneus.";

            case "Funcionamento do Tacógrafo":
                return "Revisar e regularizar o funcionamento do tacógrafo.";

            case "Sistema de Freios a Ar":
                return "Realizar revisão imediata do sistema de freios a ar.";

            case "Sistema de Freios":
                return "Inspecionar discos, pastilhas, fluido e demais componentes do sistema de freios.";

            case "Sistema de Iluminação":
                return "Verificar faróis, lanternas, setas, lâmpadas e conexões elétricas.";

            case "Trava e Lona da Caçamba":
                return "Verificar a trava, a fixação e as condições da lona da caçamba.";

            default:
                return "Encaminhar o item para avaliação técnica.";
        }
    }
    public void ExibirRecomendacoes(Veiculo veiculo)
    {
        Console.WriteLine();
        Console.WriteLine(
            "> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:"
        );

        if (veiculo.VistoriaRealizada.Count == 0)
        {
            Console.WriteLine(
                "  A vistoria ainda não possui itens avaliados."
            );

            return;
        }

        bool possuiItemRuim = false;
        bool possuiItemRegular = false;

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Ruim")
            {
                if (!possuiItemRuim)
                {
                    Console.WriteLine(
                        "  🔴 ITENS CRÍTICOS / REPROVADOS " +
                        "(AÇÃO IMEDIATA):"
                    );

                    possuiItemRuim = true;
                }

                Console.WriteLine(
                    $"     - {item.Nome}: " +
                    $"{ObterRecomendacao(item.Nome)}"
                );
            }
        }

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular")
            {
                if (!possuiItemRegular)
                {
                    Console.WriteLine(
                        "  🟡 ITENS DE ATENÇÃO " +
                        "(REVISÃO PREVENTIVA):"
                    );

                    possuiItemRegular = true;
                }

                Console.WriteLine(
                    $"     - {item.Nome}: " +
                    $"{ObterRecomendacao(item.Nome)}"
                );
            }
        }

        if (!possuiItemRuim && !possuiItemRegular)
        {
            Console.WriteLine(
                "  🟢 Nenhuma pendência mecânica identificada. " +
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
    public void ExibirRelatorio(
    Veiculo veiculo,
    int numeroAtual,
    int totalVistorias)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"[{numeroAtual}/{totalVistorias}] PROCESSANDO VISTORIA"
        );
        Console.WriteLine(
            "-------------------------------------------------------------------"
        );

        Console.WriteLine("> DADOS DO VEÍCULO:");

        if (veiculo is Carro carro)
        {
            Console.WriteLine("  - Tipo: Carro");
            Console.WriteLine(
                $"  - Modelo: {carro.Marca} {carro.Modelo}"
            );
            Console.WriteLine(
                $"  - Ano: {carro.Ano} | " +
                $"Quilometragem: {carro.Quilometragem:N0} km"
            );
            Console.WriteLine(
                $"  - Atributo específico: " +
                $"{carro.QuantidadePortas} portas"
            );
        }
        else if (veiculo is Moto moto)
        {
            Console.WriteLine("  - Tipo: Moto");
            Console.WriteLine(
                $"  - Modelo: {moto.Marca} {moto.Modelo}"
            );
            Console.WriteLine(
                $"  - Ano: {moto.Ano} | " +
                $"Quilometragem: {moto.Quilometragem:N0} km"
            );
            Console.WriteLine(
                $"  - Atributo específico: " +
                $"{moto.Cilindradas} cilindradas"
            );
        }
        else if (veiculo is Caminhao caminhao)
        {
            Console.WriteLine("  - Tipo: Caminhão");
            Console.WriteLine(
                $"  - Modelo: {caminhao.Marca} {caminhao.Modelo}"
            );
            Console.WriteLine(
                $"  - Ano: {caminhao.Ano} | " +
                $"Quilometragem: {caminhao.Quilometragem:N0} km"
            );
            Console.WriteLine(
                $"  - Atributo específico: " +
                $"{caminhao.QuantidadeEixos} eixos | " +
                $"Cap. de carga: " +
                $"{caminhao.CapacidadeCargaToneladas:N1} toneladas"
            );
        }

        Console.WriteLine();
        Console.WriteLine(
            $"> AVALIAÇÃO DOS ITENS INSPECIONADOS " +
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
                simbolo = "[ ! ]";
            }
            else
            {
                simbolo = "[ X ]";
            }

            int pontos = ObterPontuacaoItem(item);

            string nomeFormatado =
                item.Nome.PadRight(38, '-');

            Console.WriteLine(
                $"  {simbolo} {nomeFormatado} " +
                $"Status: {item.Status} ({pontos} pts)"
            );
        }

        int pontuacaoObtida =
            CalcularPontuacao(veiculo);

        int pontuacaoMaxima =
            CalcularPontuacaoMaxima(veiculo);

        double percentual =
            CalcularPercentual(veiculo);

        string classificacao =
            ObterClassificacao(veiculo);

        string acaoCorporativa =
            ObterAcaoCorporativa(veiculo);

        Console.WriteLine();
        Console.WriteLine("> RESUMO DA PONTUAÇÃO:");

        Console.WriteLine(
            $"  - Pontuação atingida: {pontuacaoObtida} " +
            $"de {pontuacaoMaxima} pontos possíveis"
        );

        Console.WriteLine(
            $"  - Percentual de aprovação: {percentual:F1}%"
        );

        Console.WriteLine(
            $"  - Classificação final: [ {classificacao} ]"
        );

        Console.WriteLine(
            $"  - Decisão corporativa: {acaoCorporativa}"
        );

        ExibirRecomendacoes(veiculo);

        Console.WriteLine();
        Console.WriteLine(
            "-------------------------------------------------------------------"
        );
    }
}


