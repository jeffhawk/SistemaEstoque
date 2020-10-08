using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaEstoque.Banco
{
    public class tbLocalEstoque
    {
        public int Id_Local { get; set; }
        public string Nome_Local { get; set; }


        public bool Inserir()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " INSERT INTO LocalEstoque VALUES (@Nome) ";
                comando.Parameters.AddWithValue("@Nome", Nome_Local);

                comando.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Local - Descrição : " + ex.Message.ToString());
                return false;
            }

        }

        public bool Alterar()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " UPDATE LocalEstoque SET Nome_Local = @Nome WHERE Id_Local = @Id) ";
                comando.Parameters.AddWithValue("@Id", Id_Local);
                comando.Parameters.AddWithValue("@Nome", Nome_Local);
                


                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar Local - Descrição : " + ex.Message.ToString());
                return false;
            }
        }

        public bool Excluir()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " DELETE FROM LocalEstoque WHERE Id_Local = @Id) ";
                comando.Parameters.AddWithValue("@Id", Id_Local);


                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir Local - Descrição : " + ex.Message.ToString());
                return false;
            }
        }

        public DataTable Consulta()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " SELECT * FROM LocalEstoque WHERE Id_Local = @Id) ";


                DataTable dtRetorno = new DataTable();
                dtRetorno.Load(comando.ExecuteReader());

                return dtRetorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Consultar Local - Descrição : " + ex.Message.ToString());
                return null;
            }
        }
    }

}

