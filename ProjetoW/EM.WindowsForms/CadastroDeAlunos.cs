using System;
using EM.Domain;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EM.Repository;
using System.Globalization;
using System.Text.RegularExpressions;
using FirebirdSql.Data.FirebirdClient;

namespace EM.WindowsForms
{
    public partial class CadastroDeAlunos : Form
    {
        private BindingSource bsListaAlunos = new BindingSource();
        private Processo<Aluno> processo = new Processo<Aluno>();

        public CadastroDeAlunos()
        {
            InitializeComponent();

            cboSexo.DataSource = Enum.GetValues(typeof(EnumeradorSexo));

            dgvListaAlunos.DataSource = bsListaAlunos;
            bsListaAlunos.DataSource = processo.GetAll().OrderBy(a => a.Matricula);

            bsListaAlunos.ResetBindings(false);

        }

        #region Ações

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Matricula vazia!");
                txtMatricula.Focus();
                return;
            }

            string cpf = "";
            if (!(string.IsNullOrWhiteSpace(txtCPF.Text)))
            {
                cpf = Convert.ToUInt64(txtCPF.Text).ToString(@"000\.000\.000\-00");
            }

            DateTime data = new DateTime();
            try
            {
                data = DateTime.ParseExact(txtNascimento.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); //Data convertida para padrões BR
            }

            catch(Exception)
            {
                MessageBox.Show("Data não existe ou incorreta!");
                txtNascimento.Focus();
                return;
            }

            Aluno aluno = new Aluno();
            try
            {
                aluno = new Aluno(Convert.ToInt32(txtMatricula.Text), txtNome.Text, data, cpf, (EnumeradorSexo)cboSexo.SelectedItem);
            }

            catch (Exception erroInstancia)
            {
                MessageBox.Show(erroInstancia.Message);
                return;
            }

            try
            {
                if (btnAdicionar.Text == "Adicionar") processo.Add(aluno);
                if (btnAdicionar.Text == "Modificar") processo.Update(aluno);
            }

            catch (Exception erroManipular)
            {
                MessageBox.Show(erroManipular.Message);
                return;
            }

            bsListaAlunos.DataSource = processo.GetAll();
            dgvListaAlunos.DataSource = bsListaAlunos;

            if (btnAdicionar.Text == "Modificar") MessageBox.Show("Modificado com sucesso");
            btnLimpar_Click(sender, e);

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if(btnLimpar.Text == "Limpar")
            {
                txtMatricula.Text = "";
                txtNome.Text = "";
                cboSexo.SelectedItem = EnumeradorSexo.Masculino;
                txtNascimento.Text = "";
                txtCPF.Text = "";
                txtPesquisa.Text = "";
                txtMatricula.Focus();
            }
            
            if(btnLimpar.Text == "Cancelar")
            {
                btnEditar_Click(sender, e);
            }

            bsListaAlunos.DataSource = processo.GetAll().OrderBy(a => a.Matricula);
        }

        

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(!(bsListaAlunos.Current is Aluno))
            {
                MessageBox.Show("Não foi selecionado um aluno para excluir");
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja realizar a exclusão do aluno?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                processo.Remove((Aluno)bsListaAlunos.Current);

                bsListaAlunos.DataSource = processo.GetAll().OrderBy(a => a.Matricula);
                btnLimpar_Click(sender, e);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Novo")
            {

                btnEditar.Text = "Editar";
                btnLimpar.Text = "Limpar";
                btnAdicionar.Text = "Adicionar";

                txtMatricula.Text = "";
                txtNome.Text = "";
                cboSexo.SelectedItem = "";
                txtNascimento.Text = "";
                txtCPF.Text = "";
                txtPesquisa.Text = "";

                txtMatricula.Enabled = true;
                return;
            }

            if (btnEditar.Text == "Editar")
            {
                if (!(bsListaAlunos.Current is Aluno _aluno))
                {
                    MessageBox.Show("Não foi selecionado um aluno para editar");
                    return;
                }

                txtMatricula.Text = Convert.ToString(_aluno.Matricula);
                txtNome.Text = _aluno.Nome;
                cboSexo.SelectedItem = _aluno.Sexo;
                txtNascimento.Text = Convert.ToString(_aluno.Nascimento);
                txtCPF.Text = Regex.Replace(_aluno.CPF, "[-.]", string.Empty);

                btnEditar.Text = "Novo";
                btnLimpar.Text = "Cancelar";
                btnAdicionar.Text = "Modificar";

                txtMatricula.Enabled = false;
                return;
            }

        }

        private void dgvListaAlunos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnEditar.Text == "Editar")
            {
                btnEditar_Click(sender, e);
            }
                
        }

        private void dgvListaAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnEditar.Text == "Novo")
            {
                Aluno _aluno = (Aluno)bsListaAlunos.Current;
                txtMatricula.Text = Convert.ToString(_aluno.Matricula);
                txtNome.Text = _aluno.Nome;
                cboSexo.SelectedItem = _aluno.Sexo;
                txtNascimento.Text = Convert.ToString(_aluno.Nascimento);
                txtCPF.Text = Regex.Replace(_aluno.CPF, "[-.]", string.Empty);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPesquisa.Text) || string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                bsListaAlunos.DataSource = processo.GetAll().OrderBy(a => a.Matricula);
                return;
            }

            try
            {
                bsListaAlunos.DataSource = processo.GetByPesquisa(txtPesquisa.Text);
            }

            catch
            {
                MessageBox.Show("Não foram encontrados alunos para a matrícula ou nome especificados, tente novamente");
                txtPesquisa.Focus();
                txtPesquisa.Text = "";
                return;
            }

        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void dgvListaAlunos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
        }

        #endregion

    }
}
