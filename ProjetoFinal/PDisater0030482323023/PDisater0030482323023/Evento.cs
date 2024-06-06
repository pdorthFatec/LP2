using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDisater0030482323023
{
    internal class Evento
    {
        public int IdEvento { get; set; }
        public int Tipo_IdTipo { get; set; }
        public int Cidade_IdCidade { get; set; }
        public char NivelSerevidade { get; set; }
        public int AreaAfetada { get; set; }
        public int PessoasAfetadas { get; set; }
        public string Observacao { get; set; }
        public DateTime DataOcorrencia { get; set; }

        public DataTable Listar()
        {
            SqlDataAdapter daCidade;
            DataTable dtCidade = new DataTable();

            try
            {
                daCidade = new SqlDataAdapter(
                    "SELECT * FROM Evento ORDER BY DataOcorrencia DESC",
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
                    "INSERT INTO Evento VALUES = (@IDTIPO, @IDCIDADE, @NIVELSEREVIDADE, @AREAAFETADA, @PESSOASAFETADAS, @OBSERVACAO, @DATAOCORRENCIA)",
                    frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@IDTIPO", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IDCIDADE", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@NIVELSEREVIDADE", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@AREAAFETADA", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@PESSOASAFETADAS", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@OBSERVACAO", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@DATAOCORRENCIA", SqlDbType.DateTime));

                mycommand.Parameters["@IDTIPO"].Value = Tipo_IdTipo;
                mycommand.Parameters["@IDCIDADE"].Value = Cidade_IdCidade;
                mycommand.Parameters["@NIVELSEREVIDADE"].Value = NivelSerevidade;
                mycommand.Parameters["@AREAAFETADA"].Value = AreaAfetada;
                mycommand.Parameters["@PESSOASAFETADAS"].Value = PessoasAfetadas;
                mycommand.Parameters["@OBSERVACAO"].Value = Observacao;
                mycommand.Parameters["@DATAOCORRENCIA"].Value = DataOcorrencia;

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
                mycommand = new SqlCommand("DELETE FROM Evento WHERE IDEvento=@IdEvento", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@IdEvento", SqlDbType.Int));
                mycommand.Parameters["@IdEvento"].Value = IdEvento;

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
                mycommand = new SqlCommand("UPDATE Evento SET " +
                    "   TIPO_IDTIPO=@IDTIPO, " +
                    "   CIDADE_IDCIDADE=@IDCIDADE, " +
                    "   NIVELSEREVIDADE=@NIVELSEREVIDADE, " +
                    "   AREAAFETADA=@AREAAFETADA, " +
                    "   PESSOASAFETADAS=@PESSOASAFETADAS, " +
                    "   OBSERVACAO=@OBSERVACAO, " +
                    "   DATAOCORRENCIA=@DATAOCORRENCIA" +
                    "WHERE IDEvento=@IdEvento", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@IdEvento", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IDTIPO", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IDCIDADE", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@NIVELSEREVIDADE", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@AREAAFETADA", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@PESSOASAFETADAS", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@OBSERVACAO", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@DATAOCORRENCIA", SqlDbType.DateTime));

                mycommand.Parameters["@IdEvento"].Value = IdEvento;
                mycommand.Parameters["@IDTIPO"].Value = Tipo_IdTipo;
                mycommand.Parameters["@IDCIDADE"].Value = Cidade_IdCidade;
                mycommand.Parameters["@NIVELSEREVIDADE"].Value = NivelSerevidade;
                mycommand.Parameters["@AREAAFETADA"].Value = AreaAfetada;
                mycommand.Parameters["@PESSOASAFETADAS"].Value = PessoasAfetadas;
                mycommand.Parameters["@OBSERVACAO"].Value = Observacao;
                mycommand.Parameters["@DATAOCORRENCIA"].Value = DataOcorrencia;

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
