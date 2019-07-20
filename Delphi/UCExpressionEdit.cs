using System;
using System.Linq;
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
            cmbLanguage.Items.AddRange(Dictionary.languages.ToArray());
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

            txtTradu.Text = "";
            foreach (Translation tra in exp.getTranslations())
            {
                txtTradu.Text += tra.getTranslated().title + ";";
            }

            if (txtTradu.Text != "")
                txtTradu.Text = txtTradu.Text.Remove(txtTradu.Text.Length - 1);
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

            string line = txtTradu.Text;
            if (line.ElementAt(line.Length - 1) == ';')
                line.Remove(line.Length - 1);

            string language = (string)cmbLanguage.SelectedItem;
            string[] translations = line.Split(';');
            foreach (string tra in translations)
            {
                for (int cntDict = 0; cntDict < dictManger.getDictCount(); cntDict++)
                {
                    Dictionary dict = dictManger.getDict(cntDict);
                    if (dict.Language == language)
                    {
                        Text found = dict.find(tra);
                        if (found != null && found.GetType() == typeof(Word))
                        {
                            exp.addTranslation(new Translation(cntDict, language, found));
                            break;
                        }
                    }

                }
            }
        }

    }
}
