using Datastructure;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormUtilities;

namespace Delphi
{
    public partial class UCExpressionView : UserControl
    {
        public UCExpressionView()
        {
            InitializeComponent();
        }


        public void setExpression(Datastructure.Expression exp)
        {
            pnlView.Height = 600;
            lblTitle.Text = exp.title;
            
            // ogni volta che richiamo risize, restituisco la stessa posizione ma con la X aggiunta di qualche punto
            txtOriginText.Text = exp.origin;
            Tuple<int, int> location = basicUtilities.resizeTextBox(txtOriginText);
            lblNota.Location = new Point(location.Item1, location.Item2);

            txtNoteText.Text = exp.note;
            location = basicUtilities.resizeTextBox(txtNoteText);
            lblExplanation.Location = new Point(location.Item1, location.Item2);

            txtExplanationText.Text = exp.explanation;
            location = basicUtilities.resizeTextBox(txtExplanationText);
            lblText.Location = new Point(location.Item1, location.Item2);

            txtTextText.Text = exp.text;
            location = basicUtilities.resizeTextBox(txtTextText);
            lblTranslation.Location = new Point(location.Item1, location.Item2+5);
            
            txtTranslation.Text = "";
            foreach (Translation trans in exp.getTranslations())
                txtTranslation.Text += trans.getTranslated().title + ",";

            txtTranslation.Text = txtTranslation.Text.Remove(txtTranslation.Text.Length-1);
            basicUtilities.resizeTextBox(txtTranslation);
            // 20 px la distanza in verticale.

            pnlView.Height = txtTranslation.Location.Y + 10;
        }
    }
}
