using System;
using System.Windows.Forms;
using Datastructure;

namespace Delphi
{
    public partial class UCNovelEdit : UserControl
    {

        private Datastructure.Novel nvl = null;
        private DictManger dictManger = DictManger.Manager();

        public UCNovelEdit()
        {
            InitializeComponent();
        }

        public void setNovel(Datastructure.Novel nvl)
        {
            clsFields();
            this.nvl = nvl;

            lblTitle.Text = this.nvl.title;
            txtOrigine.Text = this.nvl.origin;
            txtNota.Text = this.nvl.note;
            txtAuthor.Text = this.nvl.author;
            txtTesto.Text = this.nvl.text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.nvl.title = lblTitle.Text;
            this.nvl.origin = txtOrigine.Text;
            this.nvl.note = txtNota.Text;
            this.nvl.author = txtAuthor.Text;
            this.nvl.text = txtTesto.Text;
        }

        private void clsFields()
        {
            txtOrigine.Clear();
            txtNota.Clear();
            txtAuthor.Clear();
            txtTesto.Clear();
        }

    }
}
