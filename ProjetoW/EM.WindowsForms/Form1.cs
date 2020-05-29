using System;
using EM.Domain;

using System.Data;
using System.Linq;
using System.Windows.Forms;
using EM.Repository;
using System.Globalization;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
