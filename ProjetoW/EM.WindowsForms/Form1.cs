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
    public partial class Cadastro : Form
    {
        private BindingSource bsListaAlunos = new BindingSource();
        private RepositorioAluno _repositorio = new RepositorioAluno();

        public Cadastro()
        {
            InitializeComponent();

            cboSexo.DataSource = Enum.GetValues(typeof(EnumeradorSexo));

            dgvListaAlunos.DataSource = bsListaAlunos;
            //dgvListaAlunos.DataSource = AcessoFB.fb_GetDados();
            bsListaAlunos.DataSource = AcessoFB.fb_GetDados();
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
                if (btnAdicionar.Text == "Adicionar") AcessoFB.fb_InserirDados(aluno);
                if (btnAdicionar.Text == "Modificar") _repositorio.Update(aluno);
            }

            catch (Exception erroManipular)
            {
                MessageBox.Show(erroManipular.Message);
                return;
            }



            bsListaAlunos.DataSource = _repositorio.GetAll().OrderBy(a => a.Matricula);
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

            bsListaAlunos.DataSource = _repositorio.GetAll().OrderBy(a => a.Matricula);
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
                _repositorio.Remove((Aluno)bsListaAlunos.Current);

                bsListaAlunos.DataSource = _repositorio.GetAll().OrderBy(a => a.Matricula);
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
                bsListaAlunos.DataSource = _repositorio.GetAll().OrderBy(a => a.Matricula);
                return;
            }

            if (EhInt(txtPesquisa.Text))
            {


                if (_repositorio.GetByMatricula(Convert.ToInt32(txtPesquisa.Text)) == null)
                {
                    MessageBox.Show("Não foram encontrados alunos para a matrícula especificada, tente novamente");
                    txtPesquisa.Focus();
                    txtPesquisa.Text = "";
                    return;
                }

                bsListaAlunos.DataSource = _repositorio.GetByMatricula(Convert.ToInt32(txtPesquisa.Text));
            }

            else
            {
                if (_repositorio.GetByContendoNoNome(txtPesquisa.Text).Count() == 0)
                {
                    MessageBox.Show("Não foram encontrados alunos para o nome especificado, tente novamente");
                    txtPesquisa.Text = "";
                    return;
                }

                bsListaAlunos.DataSource = _repositorio.GetByContendoNoNome(txtPesquisa.Text).OrderBy(a => a.Nome);
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

        #region Métodos Utilitários

        private bool EhInt(string entrada)
        {
            return Int32.TryParse(entrada, out _);
        }

        #endregion
    }
}
