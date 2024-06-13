using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDisater0030482323023
{
    internal class Cidade
    { // Propriedades
        public int IdCidade { get; set; }

        public String Nome { get; set; }

        public String Uf { get; set; }

        public int Populacao { get; set; }

        public DataTable Listar()
        {
            SqlDataAdapter daCidade;
            DataTable dtCidade = new DataTable();

            try
            {
                daCidade = new SqlDataAdapter(
                    "SELECT * FROM Cidade ORDER BY NOME",
                    frmPrincipal.conexao);
                daCidade.Fill(dtCidade);
                daCidade.FillSchema(dtCidade, SchemaType.Source);
            }
            catch (Exception)
            {
                throw;
            }

            return dtCidade;
        }

        public int Incluir() // Incluir
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand(
                    "INSERT INTO Cidade VALUES (@NOME, @UF, @POPULACAO)",
                    frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@UF", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@POPULACAO", SqlDbType.Int));

                mycommand.Parameters["@NOME"].Value = Nome;
                mycommand.Parameters["@UF"].Value = Uf;
                mycommand.Parameters["@POPULACAO"].Value = Populacao;

                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        public int Excluir()
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("DELETE FROM Cidade WHERE IDCidade=@IDCidade", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@IDCIdade", SqlDbType.Int));
                mycommand.Parameters["@IDCidade"].Value = IdCidade;

                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        public int Alterar()
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("UPDATE Cidade SET NOME=@NOME, UF=@UF, POPULACAO=@POPULACAO " +
                    "WHERE IDCidade=@IDCidade", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@IDCIdade", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@NOME", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@UF", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@POPULACAO", SqlDbType.Int));

                mycommand.Parameters["@IDCidade"].Value = IdCidade;
                mycommand.Parameters["@NOME"].Value = Nome;
                mycommand.Parameters["@UF"].Value = Uf;
                mycommand.Parameters["@POPULACAO"].Value = Populacao;

                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }
    }
}
