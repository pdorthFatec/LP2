using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;


namespace PDisater0030482323023
{
    public partial class frmPrincipal : Form
    {
        public static SqlConnection conexao;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            var nome = Environment.MachineName;
            //var nomeCompleto = Dns.GetHostEntry(nome).HostName;

            //Console.WriteLine(nome); //PC-162
            //Console.WriteLine(nomeCompleto); //PC-162.meudominio.com.br

            //Console.Read();

            try
            {
                if (nome.Equals("LAPTOP-1T8S0NB9"))
                {
                    conexao = new SqlConnection(
                        "Data Source=LAPTOP-1T8S0NB9\\SQLEXPRESS;" +
                        "Initial Catalog=LP2;Persist Security Info=True;" +
                        "User ID=programador;" +
                        "Password=programador;" +
                        "Encrypt=False");
                }

                conexao.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro de banco de dados =/" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Outros erros =/" + ex.Message);
            }
        }

        private void cadastroDeTiposDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmTipo>().Count() > 0)
            {
                Application.OpenForms["frmTipo"].BringToFront();
            }
            else
            {
                frmTipo objFrm2 = new frmTipo();
                objFrm2.MdiParent = this;
                objFrm2.WindowState = FormWindowState.Maximized;
                objFrm2.Show();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cadastroDeCidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmCidade>().Count() > 0)
            {
                Application.OpenForms["frmCidade"].BringToFront();
            }
            else
            {
                frmCidade objFrm2 = new frmCidade();
                objFrm2.MdiParent = this;
                objFrm2.WindowState = FormWindowState.Maximized;
                objFrm2.Show();
            }
        }

        private void cadastroDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmEvento>().Count() > 0)
            {
                Application.OpenForms["frmEvento"].BringToFront();
            }
            else
            {
                frmEvento objFrm2 = new frmEvento();
                objFrm2.MdiParent = this;
                objFrm2.WindowState = FormWindowState.Maximized;
                objFrm2.Show();
            }
        }
    }
}
