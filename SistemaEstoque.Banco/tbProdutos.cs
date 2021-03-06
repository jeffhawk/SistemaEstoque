﻿using System;
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

        public bool Inserir()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " INSERT INTO Produtos VALUES (@Nome, @Descricao, @Peso) ";
                comando.Parameters.AddWithValue("@Nome", Nome_Produto);
                comando.Parameters.AddWithValue("@Descricao", Desc_Produto);
                comando.Parameters.AddWithValue("@Peso", Peso_Produto);

                comando.ExecuteNonQuery();

                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao inserir produto - Descrição : " + ex.Message.ToString());
                return false;
            }

        }

        public bool Alterar()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = Utilitarios.ConexaoBanco.conexao;
                comando.CommandText = " UPDATE Produtos SET Nome_Produto = @Nome, Desc_Produto = @Descricao, Peso_Produto = @Peso WHERE Id_Produto = @Id) ";
                comando.Parameters.AddWithValue("@Id", Id_Produto);
                comando.Parameters.AddWithValue("@Nome", Nome_Produto);
                comando.Parameters.AddWithValue("@Descricao", Desc_Produto);
                comando.Parameters.AddWithValue("@Peso", Peso_Produto);


                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar produto - Descrição : " + ex.Message.ToString());
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
