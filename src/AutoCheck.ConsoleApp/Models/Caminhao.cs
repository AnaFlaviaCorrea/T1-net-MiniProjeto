namespace AutoCheck.ConsoleApp.Models;

public class Caminhao : Veiculo
{
    public double CapacidadeCargaToneladas { get; set; }
    public int QuantidadeEixos { get; set; }

    public Caminhao(
        string marca,
        string modelo,
        int ano,
        double quilometragem,
        double capacidadeCargaToneladas,
        int quantidadeEixos)
        : base(marca, modelo, ano, quilometragem)
    {
        this.CapacidadeCargaToneladas = capacidadeCargaToneladas;
        this.QuantidadeEixos = quantidadeEixos;
    }

    public override List<string> ObterChecklistObrigatorio()
    {
        List<string> checklistCaminhao =
            base.ObterChecklistObrigatorio();

        checklistCaminhao.Add("Funcionamento do Tacógrafo");
        checklistCaminhao.Add("Trava e Lona da Caçamba");
        checklistCaminhao.Add("Sistema de Freios a Ar");

        return checklistCaminhao;
    }
}