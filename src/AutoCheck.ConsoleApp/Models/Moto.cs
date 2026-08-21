namespace AutoCheck.ConsoleApp.Models;

public abstract class Moto : Veiculo
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

        checklistMoto.Add("Capacete em bom estado");
        checklistMoto.Add("Luvas de proteção");
        checklistMoto.Add("Jaqueta ou colete refletivo");

        return checklistMoto;
    }
}
