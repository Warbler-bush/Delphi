using System;
using System.Linq;
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
            cmbLanguage.Items.AddRange(Dictionary.languages.ToArray());
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

            txtTradu.Text = "";
            foreach(Translation tra in nvl.getTranslations())
            {
                txtTradu.Text += tra.getTranslated().title+";";
            }

            if (txtTradu.Text != "")
                txtTradu.Text = txtTradu.Text.Remove(txtTradu.Text.Length - 1);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.nvl.title = lblTitle.Text;
            this.nvl.origin = txtOrigine.Text;
            this.nvl.note = txtNota.Text;
            this.nvl.author = txtAuthor.Text;
            this.nvl.text = txtTesto.Text;

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
                            nvl.addTranslation(new Translation(cntDict, language, found));
                            break;
                        }
                    }

                }
            }

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
