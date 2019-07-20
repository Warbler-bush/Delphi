using Datastructure;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utility;

namespace Delphi
{
    public partial class UCAddNovel : UserControl
    {
        private NovelBuilder nvlBuilder = null;
        private DictManger dictManger = DictManger.Manager();

        public UCAddNovel()
        {
            nvlBuilder = NovelBuilder.novelBuilder();
            InitializeComponent();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (!TextBuilder.rgx.IsMatch(txtNovel.Text))
                MessageBox.Show("Insert an adaguate novel");

            if (TextBuilder.rgx.IsMatch(txtTradu.Text))
            {
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
                            if (found != null && found.GetType() == typeof(Novel) )
                            {
                                nvlBuilder.addTranslation(new Translation(language, found));
                                break;
                            }
                        }
                    }
                }

            }

            dictManger.CurDict().add(
                        nvlBuilder.
                        setAuthor(txtAuthor.Text).
                        setTitle(txtNovel.Text).
                        setOrigin(txtOri.Text).
                        setNote(txtNote.Text).
                        build())
            ;

            clearFields();
        }

        private void clearFields()
        {
            txtAuthor.Text = "";
            txtNovel.Text = "";
            txtOri.Text = "";
            txtNote.Text = "";
        }

    }
}
