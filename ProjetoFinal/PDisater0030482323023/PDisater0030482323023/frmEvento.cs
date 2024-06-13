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
    public partial class frmEvento : Form
    {
        private BindingSource bnEvento = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsEvento = new DataSet();
        private DataSet dsCidade = new DataSet();
        private DataSet dsTipo = new DataSet();

        public frmEvento()
        {
            InitializeComponent();
        }

        private void frmEvento_Load(object sender, EventArgs e)
        {
            try
            {
                Evento Eve = new Evento();
                dsEvento.Tables.Add(Eve.Listar());
                bnEvento.DataSource = dsEvento.Tables["Evento"];
                dgvEvento.DataSource = bnEvento;
                bnvEvento.BindingSource = bnEvento;

                txtIdEvento.DataBindings.Add("TEXT", bnEvento, "idEvento");
                cbxSeveridade.DataBindings.Add("SelectedItem", bnEvento, "nivelseveridade");
                mskbxAreaAfetada.DataBindings.Add("TEXT", bnEvento, "areaafetada");
                mskbxPopAfetada.DataBindings.Add("TEXT", bnEvento, "pessoasafetadas");
                txtObservacao.DataBindings.Add("TEXT", bnEvento, "observacao");
                dtpDataOcorrencia.DataBindings.Add("TEXT", bnEvento, "dataocorrencia");

                // ligando com Cidade
                Cidade Cid = new Cidade();
                dsCidade.Tables.Add(Cid.Listar());
                cbxCidade.DataSource = dsCidade.Tables["Cidade"];
                cbxCidade.DisplayMember = "nome";
                cbxCidade.ValueMember = "idcidade";
                cbxCidade.DataBindings.Add("SelectedValue", bnEvento, "cidade_idcidade");

                // ligando com Tipo
                Tipo Tip = new Tipo();
                dsTipo.Tables.Add(Tip.Listar());
                cbxTipo.DataSource = dsTipo.Tables["Tipo"];
                cbxTipo.DisplayMember = "descricao";
                cbxTipo.ValueMember = "idtipo";
                cbxTipo.DataBindings.Add("SelectedValue", bnEvento, "tipo_idtipo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tbEvento.SelectedIndex == 0)
            {
                tbEvento.SelectTab(1);
            }
            bnEvento.AddNew();

            /* Reescrever
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
            */

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbEvento.SelectedIndex == 0)
            {
                tbEvento.SelectTab(1);
            }
            /* Reescrever
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
            */

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
            if (txtObservacao.Text == "")
            {
                MessageBox.Show("Descrição inválida!");
            }
            else
            {
                Evento RegEvento = new Evento();
                // Reescrever essa parte
                //RegCidade.Descricao = txtDescricao.Text;
                if (bInclusao)
                { // Inclusão
                    if (RegEvento.Incluir() > 0)
                    {
                        MessageBox.Show("Tipo adicionado com sucesso!");

                        txtObservacao.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarregar o grid
                        dsEvento.Tables.Clear();
                        dsEvento.Tables.Add(RegEvento.Listar());
                        bnEvento.DataSource = dsEvento.Tables["Evento"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar tipo!");
                    }
                }
                else
                { // Alteração
                    RegEvento.IdEvento = Convert.ToInt16(txtIdEvento.Text);

                    if (RegEvento.Alterar() > 0)
                    {
                        MessageBox.Show("Tipo alterdo com sucesso!");

                        txtIdEvento.Enabled = false;
                        txtObservacao.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarregar o grid
                        dsEvento.Tables.Clear();
                        dsEvento.Tables.Add(RegEvento.Listar());
                        bnEvento.DataSource = dsEvento.Tables["Evento"];
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
            if (tbEvento.SelectedIndex == 0)
            {
                tbEvento.SelectTab(1);
            }

            if (MessageBox.Show("Confirma exclusão?", "Sim ou Não",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Evento RegEvento = new Evento();

                RegEvento.IdEvento = Convert.ToInt16(txtIdEvento.Text);

                if (RegEvento.Excluir() > 0)
                {
                    MessageBox.Show("Tipo excluído com sucesso!");

                    Evento R = new Evento();
                    // recarregar o grid
                    dsEvento.Tables.Clear();
                    dsEvento.Tables.Add(R.Listar());
                    bnEvento.DataSource = dsEvento.Tables["Evento"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir evento!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnEvento.CancelEdit();

            txtObservacao.Enabled = false;
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = false;

            bInclusao = false;
        }
    }
}
