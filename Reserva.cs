public class Reserva
{
    public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
    public Suite Suite { get; set; } = null!;
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        // Validação: Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
        if (Suite != null && Suite.Capacidade >= hospedes.Count)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        // Cálculo básico: Dias reservados * Valor da diária da suíte
        decimal valor = DiasReservados * Suite.ValorDiaria;

        // Regra de negócio: Desconto de 10% para estadias maiores que 10 dias
        if (DiasReservados > 10)
        {
            valor -= valor * 0.10m; // ou valor * 0.9m
        }

        return valor;
    }
}