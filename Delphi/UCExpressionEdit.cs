using System;
using System.Windows.Forms;
using Datastructure;

namespace Delphi
{
    public partial class UCExpressionEdit : UserControl
    {

        private Datastructure.Expression exp = null;
        private DictManger dictManger = DictManger.Manager();

        public UCExpressionEdit()
        {
            InitializeComponent();
        }


        public void setExpression(Datastructure.Expression exp)
        {
            clsFields();
            this.exp = exp;

            lblTitle.Text = this.exp.title;
            txtOrigine.Text = this.exp.origin;
            txtNota.Text = this.exp.note;
            txtSpiegazionne.Text = this.exp.explanation;
            txtTesto.Text = this.exp.text;
        }

        private void clsFields()
        {
            txtOrigine.Clear();
            txtNota.Clear();
            txtSpiegazionne.Clear();
            txtTesto.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.exp.title = lblTitle.Text;
            this.exp.origin = txtOrigine.Text;
            this.exp.note = txtNota.Text;
            this.exp.explanation = txtSpiegazionne.Text;
            this.exp.text = txtTesto.Text;
        }

    }
}
