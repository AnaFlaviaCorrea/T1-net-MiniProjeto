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
}


