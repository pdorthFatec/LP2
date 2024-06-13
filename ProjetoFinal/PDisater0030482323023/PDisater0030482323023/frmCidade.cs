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
    public partial class frmCidade : Form
    {
        private BindingSource bnCidade = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsCidade = new DataSet();

        public frmCidade()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCidade_Load(object sender, EventArgs e)
        {
            try
            {
                Cidade Cip = new Cidade();
                dsCidade.Tables.Add(Cip.Listar());
                bnCidade.DataSource = dsCidade.Tables["Cidade"];
                dgvCidade.DataSource = bnCidade;
                bnvCidade.BindingSource = bnCidade;

                // Pegar os campos das colunas
                txtID.DataBindings.Add("TEXT", bnCidade, "idCidade");
				txtNome.DataBindings.Add("TEXT", bnCidade, "nome");
				cbxUF.DataBindings.Add("SelectedItem", bnCidade, "uf");
				mskbxPopulacao.DataBindings.Add("TEXT", bnCidade, "populacao");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            bnCidade.AddNew();

            txtNome.Enabled = true;
			cbxUF.Enabled = true;
			cbxUF.SelectedIndex = 0;
			mskbxPopulacao.Enabled = true;
            txtNome.Focus();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }

            txtNome.Enabled = true;
            cbxUF.Enabled = true;
            mskbxPopulacao.Enabled = true;
            
            txtNome.Focus();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int auxiliar = 0;

            // valida os dados
            if (txtNome.Text == "")
            {
                MessageBox.Show("Nome inválida!");
            }
            else if (!int.TryParse(mskbxPopulacao.Text, out auxiliar) || (auxiliar == 0))
            {
                MessageBox.Show("População inválida!");
            }
            else
            {
                Cidade RegCidade = new Cidade();
                RegCidade.Nome = txtNome.Text;
                RegCidade.Uf = cbxUF.SelectedItem.ToString();
                RegCidade.Populacao = Convert.ToInt32(mskbxPopulacao.Text);

                // Reescrever essa parte
                //RegCidade.Descricao = txtDescricao.Text;
                if (bInclusao)
                { // Inclusão
                    if (RegCidade.Incluir() > 0)
                    {
                        MessageBox.Show("Cidade adicionada com sucesso!");

                        txtID.Enabled = false;
                        txtNome.Enabled = false;
                        cbxUF.Enabled = false;
                        mskbxPopulacao.Enabled = false;

                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarregar o grid
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCidade.Listar());
                        bnCidade.DataSource = dsCidade.Tables["Cidade"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!");
                    }
                }
                else
                { // Alteração
                    RegCidade.IdCidade = Convert.ToInt16(txtID.Text);

                    if (RegCidade.Alterar() > 0)
                    {
                        MessageBox.Show("Cidade alterada com sucesso!");

                        txtID.Enabled = false;
                        txtNome.Enabled = false;
                        cbxUF.Enabled = false;
                        mskbxPopulacao.Enabled = false;

                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarregar o grid
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCidade.Listar());
                        bnCidade.DataSource = dsCidade.Tables["Cidade"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar cidade!");
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }

            if (MessageBox.Show("Confirma exclusão?", "Sim ou Não",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cidade RegCidade = new Cidade();

                RegCidade.IdCidade = Convert.ToInt16(txtID.Text);

                if (RegCidade.Excluir() > 0)
                {
                    MessageBox.Show("Cidade excluído com sucesso!");

                    Cidade R = new Cidade();
                    // recarregar o grid
                    dsCidade.Tables.Clear();
                    dsCidade.Tables.Add(R.Listar());
                    bnCidade.DataSource = dsCidade.Tables["Cidade"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir cidade!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnCidade.CancelEdit();

            txtID.Enabled = false;
            txtNome.Enabled = false;
            cbxUF.Enabled = false;
            mskbxPopulacao.Enabled = false;

            txtNome.Enabled = false;
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = false;

            bInclusao = false;
        }
    }
}
