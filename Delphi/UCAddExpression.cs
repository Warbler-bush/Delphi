using Datastructure;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utility;

namespace Delphi
{
    public partial class UCAddExpression : UserControl
    {
        private ExpressionBuilder expBuilder = null;
        private DictManger dictManger = DictManger.Manager();

        public UCAddExpression()
        {
            expBuilder = ExpressionBuilder.expressionBuilder();
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (!TextBuilder.rgx.IsMatch(txtExpression.Text))
                MessageBox.Show("Insert an adaguate expression");


            if (TextBuilder.rgx.IsMatch(txtTradu.Text) )
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
                            if (found != null && found.GetType() == typeof(Expression) )
                            {
                                expBuilder.addTranslation(new Translation(language, found));
                                break;
                            }
                        }
                    }
                }

            }


            dictManger.CurDict().add(
                expBuilder.
                setText(txtText.Text).
                setExplanation(txtExplanation.Text).
                setTitle(txtExpression.Text).
                setOrigin(txtOri.Text).
                setNote(txtNote.Text).
                build()
            );

            clearFields();
        }

        private void clearFields()
        {
            txtText.Text = "";
            txtExpression.Text = "";
            txtExplanation.Text = "";
            txtOri.Text = "";
            txtNote.Text = "";
        }
    }
}
