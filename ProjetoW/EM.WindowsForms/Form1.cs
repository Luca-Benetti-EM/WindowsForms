using System;
using EM.Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EM.Repository;
using System.Globalization;

namespace EM.WindowsForms
{
    public partial class Form1 : Form
    {
        BindingSource bsListaAlunos = new BindingSource();

        private RepositorioAluno repositorio = new RepositorioAluno();

        public Form1()
        {
            InitializeComponent();

            cboSexo.DataSource = Enum.GetValues(typeof(EnumeradorSexo));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int matricula;
            string nome = txtNome.Text;
            DateTime nascimento = ConverteParaData(txtNascimento.Text);
            EnumeradorSexo sexo = (EnumeradorSexo)cboSexo.SelectedItem;
            string CPF = ConverteParaCPF(txtCPF.Text);

            if (StringVazia(txtMatricula.Text))
            {
                MessageBox.Show("Matrícula não inserida");
                txtMatricula.Focus();
                return;
            } matricula = Convert.ToInt32(txtMatricula.Text);

            if (StringVazia(nome))
            {
                MessageBox.Show("Nome não inserido");
                txtNome.Focus();
                return;
            }

            if (!ValidaData(nascimento))
            {
                MessageBox.Show("Data inserida incorretamente ou data futura");
                txtNascimento.Focus();
                return;
            }

            if (!(ValidaCPF(CPF)))
            {
                MessageBox.Show("CPF não é válido");
                txtCPF.Focus();
                return;
            }

            if(MatriculaJaCadastrada(matricula)) {
                MessageBox.Show("Matrícula já cadastrada, altere para inserir novo aluno");
                txtMatricula.Focus();
                return;
            }
            

            if(CPFJaCadastrado(CPF))
            {
                MessageBox.Show("CPF já cadastrado");
                txtMatricula.Focus();
                return;
            }

            repositorio.Add(new Aluno(matricula, nome, nascimento, CPF, sexo));

            bsListaAlunos.DataSource = repositorio.GetAll();
            AtualizaDGV();

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtNascimento_Leave(object sender, EventArgs e)
        {
            if (!txtNascimento.MaskCompleted)
            {
                MessageBox.Show("Data não preenchida corretamente");

            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnEditar.Visible = false;
            btnNovo.Enabled = true;
            btnNovo.Visible = true;

            btnAdicionar.Enabled = false;
            btnAdicionar.Visible = false;
            btnModificar.Enabled = true;
            btnModificar.Visible = true;

            btnLimpar.Enabled = false;
            btnLimpar.Visible = false;
            btnCancelar.Enabled = true;
            btnCancelar.Visible = true;

            ObterDadosLinha();

            txtMatricula.Enabled = false;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {


            if (!(bsListaAlunos.Count == 0))
            {
                if (MessageBox.Show("Tem certeza que deseja realizar a exclusão do aluno?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    repositorio.Remove(RetornaAlunoMatriculaAtual());

                    bsListaAlunos.DataSource = repositorio.GetAll();
                    AtualizaDGV();
                }

            }

            else
            {
                MessageBox.Show("Não é possível realizar a exclusão pois nenhum aluno foi selecionado!");
            }

        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if(EhInt(txtPesquisa.Text)) {
                bsListaAlunos.DataSource = repositorio.GetByMatricula(Convert.ToInt32(txtPesquisa.Text));
            }

            else {
                bsListaAlunos.DataSource = repositorio.GetByContendoNoNome(txtPesquisa.Text);
            }

            AtualizaDGV();
        }
        
        private void AtualizaDGV()
        {
            dgvListaAlunos.DataSource = bsListaAlunos;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private bool ValidaCPF(string cpf)
        {
            if (StringVazia(cpf)) return true;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private bool ValidaData(DateTime nascimento)
        {
            if (nascimento == new DateTime()) return false;
            if (nascimento.Date > DateTime.Today) return false;
            return true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtMatricula.Enabled = true;
            btnEditar.Enabled = true;
            btnEditar.Visible = true;
            btnNovo.Enabled = false;
            btnNovo.Visible = false;

            btnAdicionar.Enabled = true;
            btnAdicionar.Visible = true;
            btnModificar.Enabled = false;
            btnModificar.Visible = false;

            btnLimpar.Enabled = true;
            btnLimpar.Visible = true;
            btnCancelar.Enabled = false;
            btnCancelar.Visible = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtNome.Text = "";
            cboSexo.SelectedItem = EnumeradorSexo.Masculino;
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtMatricula.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            DateTime nascimento = ConverteParaData(txtNascimento.Text);
            EnumeradorSexo sexo = (EnumeradorSexo)cboSexo.SelectedItem;
            string CPF = ConverteParaCPF(txtCPF.Text);

            Aluno aluno = RetornaAlunoMatriculaAtual();
                

            if (StringVazia(nome))
            {
                MessageBox.Show("Nome não inserido");
                txtNome.Focus();
                return;
            }

            if (!ValidaData(nascimento))
            {
                MessageBox.Show("Data inserida incorretamente ou data futura");
                txtNascimento.Focus();
                return;
            }

            if (!(ValidaCPF(CPF)))
            {
                MessageBox.Show("CPF não é válido");
                txtCPF.Focus();
                return;
            }


            if (CPFJaCadastrado(CPF) && (CPF != aluno.CPF))
            {
                MessageBox.Show("CPF já cadastrado");
                txtMatricula.Focus();
                return;
            }

            repositorio.Update(new Aluno(aluno.Matricula, nome, nascimento, CPF, sexo));

            bsListaAlunos.DataSource = repositorio.GetAll();
            AtualizaDGV();
        }

        private Aluno RetornaAlunoMatriculaAtual()
        {
            return repositorio.GetByMatricula((int)dgvListaAlunos.CurrentRow.Cells[0].Value);
        }

        private void dgvListaAlunos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListaAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnNovo.Enabled)
            {
                ObterDadosLinha();
            }
        }

        private string ConverteParaCPF(string entrada)
        {
            if (StringVazia(entrada)) return entrada;
            else return Convert.ToUInt64(entrada).ToString(@"000\.000\.000\-00");
        }

        //Verifica se existem dados no DataGridView para serem recebidos pelo painel, se verdadeiro, preenche os campos com a linha selecionada
        private bool ObterDadosLinha()
        {
            if (bsListaAlunos.Count == 0)
            {
                return false;
            }
            txtMatricula.Text = dgvListaAlunos.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvListaAlunos.CurrentRow.Cells[1].Value.ToString();
            cboSexo.SelectedItem = dgvListaAlunos.CurrentRow.Cells[2].Value;
            txtNascimento.Text = dgvListaAlunos.CurrentRow.Cells[3].Value.ToString();

            if (!(dgvListaAlunos.CurrentRow.Cells[4].Value.ToString() == "")) //Se houver CPF, retorna apenas os números ao editar
            {
                txtCPF.Text = dgvListaAlunos.CurrentRow.Cells[4].Value.ToString().Substring(0, 3)
                + dgvListaAlunos.CurrentRow.Cells[4].Value.ToString().Substring(4, 3)
                + dgvListaAlunos.CurrentRow.Cells[4].Value.ToString().Substring(8, 3)
                + dgvListaAlunos.CurrentRow.Cells[4].Value.ToString().Substring(12, 2);
            }

            else
            {
                txtCPF.Text = "";
            }

            return true;
        }

        private bool StringVazia(string entrada)
        {
            if (entrada == "") return true;
            else return false;
        }

        private DateTime ConverteParaData(string entrada)
        {
            DateTime data;
            try
            {
               data = DateTime.ParseExact(entrada, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); //Data convertida para padrões BR
            }


            catch (Exception)
            {
                return new DateTime();
            }

            return data;
        }

        private bool MatriculaJaCadastrada(int matricula)
        {
            Aluno aluno = new Aluno(matricula, "", new DateTime(), "", EnumeradorSexo.Masculino);

            if (repositorio.Get(a => a.Matricula == aluno.Matricula) != null)
            {
                return true;
            }

            return false;
        }

        private bool CPFJaCadastrado(string cpf)
        {
            if (StringVazia(cpf)) return false;

            Aluno aluno = new Aluno(0, "", new DateTime(), cpf, EnumeradorSexo.Masculino);

            if (repositorio.Get(a => a.CPF == aluno.CPF) != null)
            {
                return true;
            }

            return false;
        }

        private bool EhInt(string entrada)
        {
            try
            {
                Convert.ToInt32(txtPesquisa.Text);
            }

            catch
            {
                return false;
            }

            return true;
        }
    }
}
