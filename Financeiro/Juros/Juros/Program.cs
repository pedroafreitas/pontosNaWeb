public class Program
{
	public static void Main()
	{
		ImprimirParcelas(Sac(80000, 80, 2));
	}

	public static List<ParcelaSac> Sac(decimal saldoDevedor, int prazo, decimal jurosAoAno)
	{
		var parcelas = new List<ParcelaSac>();
		var amortizacao = saldoDevedor / prazo;
		var jurosAoMes = (jurosAoAno/100) / 12;
		while (saldoDevedor > 0)
		{ 
			var juros = saldoDevedor * jurosAoMes; 
			parcelas.Add(
				new ParcelaSac(prazo, amortizacao, saldoDevedor, juros, amortizacao + juros)
			);
			saldoDevedor -= amortizacao;
			prazo -= 1;
		}

		return parcelas;
	}

	public static void ImprimirParcelas(List<ParcelaSac> parcelas)
	{
		foreach (ParcelaSac parcela in parcelas)
		{
			Console.WriteLine(
				"Num: " + parcela.prazo
				+ "| SD: " + parcela.saldoDevedor.ToString("#.##")
				+ "| Amort: " + parcela.amortizacao.ToString("#.##")
				+ "| Juros: " + parcela.juros.ToString("#.##")
				+ "| Prestacao: " + parcela.prestacao.ToString("#.##"));
		}
	}
}

public class ParcelaSac
{
	public int prazo { get; set; }
	public decimal amortizacao { get; set; }
	public decimal saldoDevedor { get; set; }
	public decimal juros { get; set; }
	public decimal prestacao { get; set; }

    public ParcelaSac(int Parcela, 
		decimal Amortizacao,
		decimal SaldoDevedor,
		decimal Juros, 
		decimal Prestacao) 
	{
		prazo = Parcela;
		amortizacao = Amortizacao;
		saldoDevedor = SaldoDevedor;
		juros = Juros;
		prestacao = Prestacao;
	}
}
