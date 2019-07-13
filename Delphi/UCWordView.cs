using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormUtilities;

namespace Delphi
{
    public partial class UCWordView : UserControl
    {
        public UCWordView()
        {
            InitializeComponent();
        }


        

        public void setWord(Datastructure.Word wrd)
        {
            
            lblTitle.Text = wrd.title;
            lblType.Text = wrd.getType();
            
            
            txtOriginText.Text = wrd.origin;
            Tuple<int,int> location = basicUtilities.resizeTextBox(txtOriginText);
            lblNota.Location = new Point ( location.Item1,location.Item2 ) ;

            txtNoteText.Text = wrd.note;
            location = basicUtilities.resizeTextBox(txtNoteText);
            lblForms.Location = new Point(location.Item1, location.Item2);

            // 20 px la distanza in verticale.


            txtFormsText.Text = "";
            foreach (Datastructure.Form frm in wrd.getForms())
            {
                txtFormsText.Text += frm.form + " (" + frm.type + ")" + " ";
            }

            location = basicUtilities.resizeTextBox(txtFormsText);
            lblDefinition.Location = new Point(location.Item1, location.Item2);

            txtDefinitionsText.Text = "";
            
            int i = 0;
            foreach (Datastructure.Definition def in wrd.GetDefinitions())
            {
                txtDefinitionsText.Text += (i+1)+")" + def.definition+ "\r\n";
                txtDefinitionsText.Text += "\r\n"+ "----------------------------------------------------" + "\r\n" + "\r\n";

                i++;
            }
            basicUtilities.resizeTextBox(txtDefinitionsText);
            pnlView.Height = txtDefinitionsText.Location.Y + 10;
        }


    }
}
