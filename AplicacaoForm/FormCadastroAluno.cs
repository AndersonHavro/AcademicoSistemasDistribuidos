using Biblioteca;
using Biblioteca.classesBasicas;
using Biblioteca.dados;
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
    public partial class FormCadastroAluno : Form
    {
        public FormCadastroAluno()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno a = new Aluno();
                a.Matricula = Int32.Parse(textBoxMatricula.Text.Trim());
                a.Nome = textBoxNome.Text;
                AlunoBD dados = new AlunoBD();
                dados.Insert(a);
                MessageBox.Show("Aluno cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
