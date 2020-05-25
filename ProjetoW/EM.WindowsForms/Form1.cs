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
		private bool Estado = true;

		RepositorioAluno repositorio = new RepositorioAluno();

		BindingSource bsAluno = new BindingSource();

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
			Aluno aluno = new Aluno(12345789, "Luca", new DateTime(2000 - 01 - 25), "123456789", EnumeradorSexo.Masculino);
			repositorio.Add(aluno);

			BindingSource bs = new BindingSource();
			bs.DataSource = repositorio.GetAll();

			dgvListaAlunos.AutoGenerateColumns = false;
			dgvListaAlunos.DataSource = bs;


			MessageBox.Show(Convert.ToString(aluno.Sexo));
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
			if(Estado)
			{
				lblNovoAluno.Text = "Editando aluno";
				btnAdicionar.Text = "Modificar";
				btnLimpar.Text = "Cancelar";
				btnEditar.Text = "Novo";
				Estado = false;
			}
			else
			{
				lblNovoAluno.Text = "Novo aluno";
				btnAdicionar.Text = "Adicionar";
				btnLimpar.Text = "Limpar";
				btnEditar.Text = "Adicionar";
				Estado = true;
			}
			
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Deseja realmente excluir o aluno?");
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

		private void btnPesquisar_Click(object sender, EventArgs e)
		{

		}
	}
}
