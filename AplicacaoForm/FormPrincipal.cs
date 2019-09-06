
using Biblioteca.conexao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacaoForm
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroAluno form = new FormCadastroAluno();
            form.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsulta form = new FormConsulta();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConexaoSqlServer conn = new ConexaoSqlServer();
                conn.AbrirConexao();
                MessageBox.Show("Conectou");
                conn.FecharConexao();
                MessageBox.Show("Desconectou");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
