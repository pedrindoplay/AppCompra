
using System.Text.RegularExpressions;
using App.Core.Model;
string caminhoDoArquivo = "FacilitadorDeCompraApp\\lista_de_produto_para_comprar-2.csv";



List<ProdutoModel> produtoList = new();

try
{
    StreamReader StreamReader = new StreamReader(caminhoDoArquivo);

    string? line = StreamReader.ReadLine();
    while (line != null)
    {
        line = StreamReader.ReadLine();
        ProdutoModel? produtoModel = ProdutoModel.ConvertCsvTextLineToModel(line);

        if(produtoModel != null)
        {
            produtoList.Add(produtoModel);
        }

    }
    Console.WriteLine(StreamReader.ReadLine());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine(produtoList.Count());

Dictionary<string, MercadoModel> mercadoDictionary = new();

//Preenche o dicionario com valores 
foreach (ProdutoModel produto in produtoList)
{
    if (mercadoDictionary.ContainsKey(produto.MercadoNome) == false)
    {
        mercadoDictionary.Add(produto.MercadoNome, new MercadoModel()
        {
            Nome = produto.MercadoNome
        });
    }

    MercadoModel mercadoModel = mercadoDictionary[produto.MercadoNome];

    ProdutoModel produtoSelecionado = ComparadorProdutoMercadoModel.ProdutoComMenorPreco(produtoList, produto.Ean);

    if (produtoSelecionado.MercadoNome.Equals(mercadoModel.Nome))
    {
        MercadoModel.ProdutoList.Add(produtoSelecionado);
    }
}

foreach(MercadoModel mercadoModel in mercadoDictionary.Values)
{
    StreamWriter streamWrite = new StreamWriter($"ListaCompras\\{Regex.Replace(mercadoModel.Nome, "[^A-Za-z0-9]", "_")}.txt");

    foreach (ProdutoModel produto in MercadoModel.ProdutoList)
    {
        streamWrite.WriteLine($"Produto:{produto.Nome} custa R${produto.Preco} ({produto.UnidadeDeVendas})");
        streamWrite.Flush();
    }

    streamWrite.Close();
}