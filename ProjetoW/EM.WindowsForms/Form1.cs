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

		RepositorioAluno repositorio = new RepositorioAluno();

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
			//Validando entradas	
			try
			{
				string matricula = txtMatricula.Text;
				string nome = txtNome.Text;
				EnumeradorSexo sexo = (EnumeradorSexo)cboSexo.SelectedItem;
				DateTime nascimento = DateTime.ParseExact(txtNascimento.Text, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); //Data convertida para padrões BR
				string CPF = txtCPF.Text;

				//Validando matricula
				if (matricula == "") //Não aceita matrícula vazia
				{
					MessageBox.Show("Matrícula não inserida");
					txtMatricula.Focus();
					return;
				}

				//Validando nome
				if (nome == "") //Não aceita nome vazio
				{
					MessageBox.Show("Nome não inserido");
					txtNome.Focus();
					return;
				}

				//Validando nascimento
				if (!ValidaData(nascimento))
				{
					MessageBox.Show("Não é possível adicionar uma data de nascimento futura");
					txtNascimento.Focus();
					return;
				}

				//Validando CPF
				if (!(CPF == "")) //Aceita CPF Vazio, mas valida quando há algo inserido
				{
					CPF = Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");

					if (!(ValidaCPF(CPF)))
					{
						MessageBox.Show("CPF não é válido");
						txtCPF.Focus();
						return;
					}

				}

				//Passando todos os testes, cria um novo aluno e o insere na lista
				Aluno teste = new Aluno(Convert.ToInt32(matricula), nome, nascimento, CPF, sexo);
				repositorio.Add(teste);
			}

			catch (Exception)
			{
				MessageBox.Show("Data não preenchida corretamente");
			}

			//BindingSource e DataGridView são atualizados
			BindingSource bsListaAlunos = new BindingSource();
			bsListaAlunos.DataSource = repositorio.GetAll();
			dgvListaAlunos.DataSource = bsListaAlunos;


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

			txtMatricula.Text = "";
			txtNome.Text = "";
			cboSexo.SelectedItem = "";
			txtNascimento.Text = "";

			txtMatricula.Enabled = false;

		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Deseja realmente excluir o aluno?");
		}


		private void btnPesquisar_Click(object sender, EventArgs e)
		{

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

		}

		private void dgvListaAlunos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dgvListaAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(btnNovo.Enabled)
			{
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
			}
		}
	}
}
