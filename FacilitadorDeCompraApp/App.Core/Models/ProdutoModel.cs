using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Core.Model
{
    public class ProdutoModel
    {

        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Ean { get; set; } = string.Empty;
        public string UnidadeDeVendas { get; set; } = string.Empty;
        public double Preco { get; set; } = 0;

        public string MercadoNome { get; set; } = string.Empty;

        public static ProdutoModel? ConvertCsvTextLineToModel(string? text)
        {
            // string[] parts = text.Split(";");
            // Cebola,7891234560140,Comidas,Kg,Atacadão,7.09

            if (text == null) return null;
            string[] parts = text.Split(',');

            if (parts.Count() < 6) 
            {
                return null;

            }

            ProdutoModel model = new();

            model.Nome = parts[0];
            model.Ean = parts[1];
            model.Categoria = parts[2];
            model.UnidadeDeVendas = parts[3];
            model.MercadoNome = parts[4];
            model.Preco = Double.Parse(parts[5]);

            return model;
        }
    }
}