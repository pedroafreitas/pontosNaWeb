using Extreme.Mathematics;

public class Program
{
	public static void Main()
	{
		ImprimirParcelas(Sac(80000, 80, 2));
		ImprimirParcelas(Price(80000, 80, 2));
	}

    private static List<Parcela> Sac(decimal saldoDevedor, int prazo, decimal TaxaDeJurosAoAno)
	{
		var parcelas = new List<Parcela>();		
		var jurosAoMes = (TaxaDeJurosAoAno / 100) / 12;
		while (saldoDevedor > 0)
		{ 
			var juros = saldoDevedor * jurosAoMes;
			var amortizacao = saldoDevedor / prazo;
			parcelas.Add(
				new Parcela(prazo, amortizacao, saldoDevedor, juros, amortizacao + juros)
			);
			saldoDevedor -= amortizacao;
			prazo -= 1;
		}
		return parcelas;
	}
	
	private static List<Parcela> Price(decimal saldoDevedor, int prazo, decimal TaxaDeJurosAoAno)
    {		
		var parcelas = new List<Parcela>();
		decimal jurosAoMes = (TaxaDeJurosAoAno / 100) / 12;
		decimal prazoDecimal = prazo;
        var prestacao = saldoDevedor * 
			((DecimalMath.Pow((1 + jurosAoMes), prazoDecimal) * jurosAoMes) / 
			(DecimalMath.Pow((1 + jurosAoMes), prazoDecimal) - 1));
		while(saldoDevedor > 0)
        {
			var juros = saldoDevedor * jurosAoMes;
			var amortizacao = prestacao - juros;
			parcelas.Add(
				new Parcela(prazo, amortizacao, saldoDevedor, juros, prestacao)
			);
			saldoDevedor -= amortizacao;
			prazo -= 1;
		}
		return parcelas;
	}

	private static void ImprimirParcelas(List<Parcela> parcelas)
	{
		foreach (Parcela parcela in parcelas)
		{
			Console.WriteLine(
				"Num: " + parcela.Prazo
				+ "| SD: " + parcela.SaldoDevedor.ToString("#.##")
				+ "| Amort: " + parcela.Amortizacao.ToString("#.##")
				+ "| Juros: " + parcela.Juros.ToString("#.##")
				+ "| Prestacao: " + parcela.Prestacao.ToString("#.##"));
		}
	}
}

public class Parcela
{
	public int Prazo { get; set; }
	public decimal Amortizacao { get; set; }
	public decimal SaldoDevedor { get; set; }
	public decimal Juros { get; set; }
	public decimal Prestacao { get; set; }

    public Parcela(int Parcela, 
		decimal Amortizacao,
		decimal SaldoDevedor,
		decimal Juros, 
		decimal Prestacao) 
	{
		Prazo = Parcela;
		this.Amortizacao = Amortizacao;
		this.SaldoDevedor = SaldoDevedor;
		this.Juros = Juros;
		this.Prestacao = Prestacao;
	}
}
