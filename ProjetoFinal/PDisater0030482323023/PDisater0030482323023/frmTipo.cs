using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDisater0030482323023
{
    public partial class frmTipo : Form
    {
        private BindingSource bnTipo = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsTipo = new DataSet();

        public frmTipo()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tbTipo.SelectedIndex == 0)
            {
                tbTipo.SelectTab(1);
            }
            bnTipo.AddNew();

            txtDescricao.Enabled = true;
            txtDescricao.Focus();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = true;
        }

        private void frmTipo_Load(object sender, EventArgs e)
        {
            try
            {
                Tipo Tip = new Tipo();
                dsTipo.Tables.Add(Tip.Listar());
                bnTipo.DataSource = dsTipo.Tables["Tipo"];
                dgvTipo.DataSource = bnTipo;
                bnvTipo.BindingSource = bnTipo;

                txtID.DataBindings.Add("TEXT", bnTipo, "idTipo");
                txtDescricao.DataBindings.Add("TEXT", bnTipo, "descricao");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbTipo.SelectedIndex == 0)
            {
                tbTipo.SelectTab(1);
            }
            txtDescricao.Enabled = true;
            txtDescricao.Focus();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // valida os dados
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Descrição inválida!");
            }
            else
            {
                Tipo RegTip = new Tipo();
                RegTip.Descricao = txtDescricao.Text;
                if (bInclusao)
                { // Inclusão
                    if (RegTip.Incluir() > 0)
                    {
                        MessageBox.Show("Tipo adicionado com sucesso!");

                        txtDescricao.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarregar o grid
                        dsTipo.Tables.Clear();
                        dsTipo.Tables.Add(RegTip.Listar());
                        bnTipo.DataSource = dsTipo.Tables["Tipo"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar tipo!");
                    }
                }
                else
                { // Alteração
                    RegTip.IdTipo = Convert.ToInt32(txtID.Text);

                    if (RegTip.Alterar() > 0)
                    {
                        MessageBox.Show("Tipo alterdo com sucesso!");

                        txtID.Enabled = false;
                        txtDescricao.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarregar o grid
                        dsTipo.Tables.Clear();
                        dsTipo.Tables.Add(RegTip.Listar());
                        bnTipo.DataSource = dsTipo.Tables["Tipo"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar tipo!");
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tbTipo.SelectedIndex == 0)
            {
                tbTipo.SelectTab(1);
            }

            if (MessageBox.Show("Confirma exclusão?", "Sim ou Não",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Tipo RegTip = new Tipo();

                RegTip.IdTipo = Convert.ToInt16(txtID.Text);

                if (RegTip.Excluir() > 0)
                {
                    MessageBox.Show("Tipo excluído com sucesso!");

                    Tipo R = new Tipo();
                    // recarregar o grid
                    dsTipo.Tables.Clear();
                    dsTipo.Tables.Add(R.Listar());
                    bnTipo.DataSource = dsTipo.Tables["Tipo"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir tipo!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnTipo.CancelEdit();

            txtDescricao.Enabled = false;
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = false;

            bInclusao = false;
        }
    }
}
