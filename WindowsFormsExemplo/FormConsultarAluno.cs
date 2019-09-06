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
    public partial class FormConsultarAluno : Form
    {
        List<Aluno> retorno;
        public FormConsultarAluno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoBD dados = new AlunoBD();
                this.retorno = dados.Select(new Aluno());
                //limpar o listView
                listView1.Items.Clear();
                foreach (Aluno a in this.retorno)
                {
                    //valor para a primeira coluna
                    ListViewItem item = listView1.Items.Add(a.Matricula.ToString());
                    item.SubItems.Add(a.Nome);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
