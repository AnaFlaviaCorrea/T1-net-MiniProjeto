namespace AutoCheck.ConsoleApp.Models;

public class Moto : Veiculo
{
    public int Cilindradas { get; set; }
    public Moto(
        string marca,
        string modelo,
        int ano,
        double quilometragem,
        int cilindradas)

        : base(marca, modelo, ano, quilometragem)
    {

    }

    public override List<string> ObterChecklistObrigatorio()
    {
        List<string> checklistMoto =
            base.ObterChecklistObrigatorio();

        checklistMoto.Add("Estado da Corrente");
        checklistMoto.Add("Desgaste dos Pneus");
        checklistMoto.Add("Sistema de Freios");


        return checklistMoto;
    }
}
