namespace AutoCheck.ConsoleApp.Models;

public class ItemVistoria
{
    public string Nome { get; set; }
    public string Status { get; private set; }

    public ItemVistoria(string nome, string status)
    {
        this.Nome = nome;
        this.DefinirStatus(status);
    }

    public void DefinirStatus(string status)
    {
        if (status != "Bom" &&
            status != "Regular" &&
            status != "Ruim")
        {
            throw new ArgumentException(
                "O status deve ser Bom, Regular ou Ruim."
            );
        }

        this.Status = status;
    }
}