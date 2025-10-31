namespace App.Core.Model
{
	public class ComparadorProdutoMercadoModel
	{

		public static ProdutoModel ProdutoComMenorPreco(List<ProdutoModel> produtoLista, string ean)
		{
			ProdutoModel produtoSelecionado;

			List<ProdutoModel> produtoComEanLista = new();

			foreach (ProdutoModel produto in produtoLista)
			{                                             
				if (produto.Ean.Equals(ean))
				{
					produtoComEanLista.Add(produto);
				}
			}

			if (produtoComEanLista.Count == 0)
			{
				throw new Exception("Não existe produto na lista");
			}

			produtoSelecionado = produtoComEanLista[0];

			foreach (ProdutoModel produto in produtoComEanLista)
			{
				if (produtoSelecionado.Preco > produto.Preco)
				{
					produtoSelecionado = produto;
				}
			}


			return produtoSelecionado;
		}
	}
}