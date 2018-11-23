using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace Catalogo
{
    public class ConexaoBD
    {
        // Variável global da classe
        private static SqlConnection strConexao = default(SqlConnection);

        /// <summary>
        /// Método cria e abre a conexão com o banco de dados
        /// </summary>
        /// <param name="pstrMsg"></param>
        /// <param name="pbooRetorno"></param>
        /// <returns>SqlConnection</returns>
        public static SqlConnection CriarConexao(out String pstrMsg, out Boolean pbooRetorno)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(@"..\..\"));

            pstrMsg = default(String);
            pbooRetorno = default(Boolean);

            try
            {
                /* 
                  - [NomeDaStringDeConexao]: é o nome configurado dentro do arquivo app.config na string de conexão
                  - A classe ConfigurationManager.ConnectionStrings, busca direto do meu app.config a minha string de conexão.
                */
                strConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["cnCatalogo"].ConnectionString);

                if (strConexao.State == ConnectionState.Closed)
                {
                    strConexao.Open();

                    pbooRetorno = true;
                }
            }
            catch (SqlException ex)
            {
                pstrMsg = ex.Message;

                pbooRetorno = false;
            }
            return strConexao;
        }
    }
}
