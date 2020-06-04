using System.Drawing;

namespace EM.WindowsForms
{
    partial class CadastroDeAlunos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroDeAlunos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblCadastroDeAlunos = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNascimento = new System.Windows.Forms.MaskedTextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblNascimento = new System.Windows.Forms.Label();
            this.cboSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblNovoAluno = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dgvListaAlunos = new System.Windows.Forms.DataGridView();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.pnlSuperior.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSuperior.Controls.Add(this.lblCadastroDeAlunos);
            resources.ApplyResources(this.pnlSuperior, "pnlSuperior");
            this.pnlSuperior.Name = "pnlSuperior";
            // 
            // lblCadastroDeAlunos
            // 
            resources.ApplyResources(this.lblCadastroDeAlunos, "lblCadastroDeAlunos");
            this.lblCadastroDeAlunos.Name = "lblCadastroDeAlunos";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.txtCPF);
            this.pnlPrincipal.Controls.Add(this.txtMatricula);
            this.pnlPrincipal.Controls.Add(this.txtNascimento);
            this.pnlPrincipal.Controls.Add(this.btnAdicionar);
            this.pnlPrincipal.Controls.Add(this.btnLimpar);
            this.pnlPrincipal.Controls.Add(this.lblCPF);
            this.pnlPrincipal.Controls.Add(this.lblNascimento);
            this.pnlPrincipal.Controls.Add(this.cboSexo);
            this.pnlPrincipal.Controls.Add(this.lblSexo);
            this.pnlPrincipal.Controls.Add(this.txtNome);
            this.pnlPrincipal.Controls.Add(this.lblNome);
            this.pnlPrincipal.Controls.Add(this.lblMatricula);
            resources.ApplyResources(this.pnlPrincipal, "pnlPrincipal");
            this.pnlPrincipal.Name = "pnlPrincipal";
            // 
            // txtCPF
            // 
            resources.ApplyResources(this.txtCPF, "txtCPF");
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
            // 
            // txtMatricula
            // 
            resources.ApplyResources(this.txtMatricula, "txtMatricula");
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // txtNascimento
            // 
            resources.ApplyResources(this.txtNascimento, "txtNascimento");
            this.txtNascimento.Name = "txtNascimento";
            this.txtNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.btnAdicionar, "btnAdicionar");
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.btnLimpar, "btnLimpar");
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblCPF
            // 
            resources.ApplyResources(this.lblCPF, "lblCPF");
            this.lblCPF.Name = "lblCPF";
            // 
            // lblNascimento
            // 
            resources.ApplyResources(this.lblNascimento, "lblNascimento");
            this.lblNascimento.Name = "lblNascimento";
            // 
            // cboSexo
            // 
            this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Items.AddRange(new object[] {
            resources.GetString("cboSexo.Items"),
            resources.GetString("cboSexo.Items1")});
            resources.ApplyResources(this.cboSexo, "cboSexo");
            this.cboSexo.Name = "cboSexo";
            // 
            // lblSexo
            // 
            resources.ApplyResources(this.lblSexo, "lblSexo");
            this.lblSexo.Name = "lblSexo";
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // lblNome
            // 
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.Name = "lblNome";
            // 
            // lblMatricula
            // 
            resources.ApplyResources(this.lblMatricula, "lblMatricula");
            this.lblMatricula.Name = "lblMatricula";
            // 
            // lblNovoAluno
            // 
            resources.ApplyResources(this.lblNovoAluno, "lblNovoAluno");
            this.lblNovoAluno.Name = "lblNovoAluno";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.btnPesquisar, "btnPesquisar");
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.btnEditar, "btnEditar");
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.btnExcluir, "btnExcluir");
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvListaAlunos
            // 
            this.dgvListaAlunos.AllowUserToAddRows = false;
            this.dgvListaAlunos.AllowUserToDeleteRows = false;
            this.dgvListaAlunos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaAlunos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaAlunos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaAlunos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaAlunos.EnableHeadersVisualStyles = false;
            this.dgvListaAlunos.GridColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.dgvListaAlunos, "dgvListaAlunos");
            this.dgvListaAlunos.Name = "dgvListaAlunos";
            this.dgvListaAlunos.ReadOnly = true;
            this.dgvListaAlunos.RowHeadersVisible = false;
            this.dgvListaAlunos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaAlunos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaAlunos_CellClick);
            this.dgvListaAlunos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaAlunos_CellDoubleClick);
            this.dgvListaAlunos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListaAlunos_KeyDown);
            // 
            // txtPesquisa
            // 
            resources.ApplyResources(this.txtPesquisa, "txtPesquisa");
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisa_KeyPress);
            // 
            // Cadastro
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.dgvListaAlunos);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.lblNovoAluno);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Cadastro";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Panel pnlSuperior;
		private System.Windows.Forms.Label lblCadastroDeAlunos;
		private System.Windows.Forms.Panel pnlPrincipal;
		private System.Windows.Forms.Label lblNovoAluno;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.Label lblMatricula;
		private System.Windows.Forms.Label lblCPF;
		private System.Windows.Forms.Label lblNascimento;
		private System.Windows.Forms.ComboBox cboSexo;
		private System.Windows.Forms.Label lblSexo;
		private System.Windows.Forms.Button btnAdicionar;
		private System.Windows.Forms.Button btnLimpar;
		private System.Windows.Forms.Button btnPesquisar;
		private System.Windows.Forms.Button btnEditar;
		private System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.DataGridView dgvListaAlunos;
		private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.MaskedTextBox txtNascimento;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtMatricula;
    }
}

