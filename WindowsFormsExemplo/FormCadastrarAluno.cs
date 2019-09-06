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

namespace WindowsFormsExemplo
{
    public partial class FormCadastrarAluno : Form
    {
        public FormCadastrarAluno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                AlunoBD dados = new AlunoBD();
                Aluno a = new Aluno()
                {
                    Matricula = Int32.Parse(textBoxMatricula.Text),
                    Nome = textBoxNome.Text
                };
                dados.Insert(a);
                MessageBox.Show("Aluno cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
