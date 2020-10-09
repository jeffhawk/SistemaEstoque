using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SistemaEstoque.Banco
{
    public class tbMovimentação
    {
        public int Id_Movi { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Local { get; set; }
        public DateTime datahora { get; set; }
        public decimal quantidade { get; set; }
        public bool saida { get; set; }
        public string descricao { get; set; }


        public bool Inserir()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " INSERT INTO Produtos VALUES (@ID_Produto, @ID_Local, @datahora, @quantidade, @saida, @descricao) ";
                comando.Parameters.AddWithValue("@ID_Produto", ID_Produto);
                comando.Parameters.AddWithValue("@ID_Local", ID_Local);
                comando.Parameters.AddWithValue("@datahora", datahora);
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@saida", saida);
                comando.Parameters.AddWithValue("@descricao", descricao);


                comando.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir a movimentação de estoque - Descrição : " + ex.Message.ToString());
                return false;
            }

        }

        public bool Alterar()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " UPDATE Movimentacao SET ID_Produto =  ID_Produto,  IDLocal = @ID_Local, datahora = @datahora, quantidade = @quantidade, saida = @saida, descricao = @descricao WHERE Id_Movi = @Id) ";
                comando.Parameters.AddWithValue("@Id", Id_Movi);
                comando.Parameters.AddWithValue("@ID_Produto", ID_Produto);
                comando.Parameters.AddWithValue("@ID_Local", ID_Local);
                comando.Parameters.AddWithValue("@datahora", datahora);
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@saida", saida);
                comando.Parameters.AddWithValue("@descricao", descricao);


                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar movimentação de estoque - Descrição : " + ex.Message.ToString());
                return false;
            }
        }

        public bool Excluir()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " DELETE FROM Produtos WHERE Id_Produto = @Id) ";
                comando.Parameters.AddWithValue("@Id", Id_Produto);


                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto - Descrição : " + ex.Message.ToString());
                return false;
            }
        }

        public DataTable Consulta()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " SELECT * FROM Produtos WHERE Id_Produto = @Id) ";


                DataTable dtRetorno = new DataTable();
                dtRetorno.Load(comando.ExecuteReader());

                return dtRetorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Consultar produto - Descrição : " + ex.Message.ToString());
                return null;
            }
        }
    
    }
}
