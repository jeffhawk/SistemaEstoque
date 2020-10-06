using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Windows.Forms;



namespace SistemaEstoque.Banco
{
    public class tbProdutos
    {
        public int Id_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public string Desc_Produto { get; set; }
        public decimal Peso_Produto { get; set; }

        public bool inserir()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " INSERT INTO Produtos VALUES (@Nome_Produto, @Desc_Produto, @Peso_Produto) ";
                comando.Parameters.AddWithValue("@Nome_Produto", Nome_Produto);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao inserir produto - Descrição : " + ex.Message.ToString());
                return false;
            }
            

        }
    }
}
