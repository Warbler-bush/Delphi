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
            
            // 20 px la distanza in verticale.
            pnlView.Height = txtTextText.Location.Y + 10;
        }
    }
}
