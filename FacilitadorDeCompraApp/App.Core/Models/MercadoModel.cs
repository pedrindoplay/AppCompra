namespace App.Core.Model
{
	public class MercadoModel
	{
		public string Nome { get; set; } = string.Empty;
		public static List<ProdutoModel> ProdutoList { get; set; } = new();
	}
}