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
    public partial class FormConsulta : Form
    {
        List<Aluno> listaAlunos = new List<Aluno>();
        public FormConsulta()
        {
            InitializeComponent();
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoBD dados = new AlunoBD();
                Aluno filtro = new Aluno();
                if (textBoxMatricula.Text.Trim().Equals("") == false)
                {
                    filtro.Matricula = Int32.Parse(textBoxMatricula.Text.Trim()); 
                }
                filtro.Nome = textBoxNome.Text;
                listaAlunos = dados.Select(filtro);
                listViewAlunos.Items.Clear();
                foreach (Aluno a in listaAlunos)
                {
                    ListViewItem linha = listViewAlunos.Items.Add(a.Matricula.ToString());
                    linha.SubItems.Add(a.Nome);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
