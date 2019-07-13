using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormUtilities;

namespace Delphi
{
    public partial class UCNovelView : UserControl
    {
        public UCNovelView()
        {
            InitializeComponent();
        }

        public void setNovel(Datastructure.Novel nvl)
        {

            lblTitle.Text = nvl.title;
            lblAutoreText.Text = nvl.author;

            // ogni volta che richiamo risize, restituisco la stessa posizione ma con la X aggiunta di qualche punto
            txtOriginText.Text = nvl.origin;
            Tuple<int, int> location = basicUtilities.resizeTextBox(txtOriginText);
            lblNota.Location = new Point(location.Item1, location.Item2);

            txtNoteText.Text = nvl.note;
            location = basicUtilities.resizeTextBox(txtNoteText);
            lblText.Location = new Point(location.Item1, location.Item2);

            txtTextText.Text = nvl.text;
            location = basicUtilities.resizeTextBox(txtTextText);

            // 20 px la distanza in verticale.
            pnlView.Height = txtTextText.Location.Y + 10;
        }
    }
}
