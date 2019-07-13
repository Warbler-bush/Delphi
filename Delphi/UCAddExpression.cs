using Datastructure;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utility;

namespace Delphi
{
    public partial class UCAddExpression : UserControl
    {
        private ExpressionBuilder expBuilder = null;
        private Regex rgx = new Regex(@"^[a-zA-Z0-9_;]+$");
        private Regex rgxText = new Regex(@"^[a-zA-Z0-9_ \n]+$");
        private DictManger dictManger = DictManger.Manager();

        public UCAddExpression()
        {
            expBuilder = ExpressionBuilder.expressionBuilder();
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

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
