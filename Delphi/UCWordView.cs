using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            lblTipo.Text = wrd.getType();
            lblOrigineTesto.Text = wrd.origin;
            lblNotaTesto.Text = wrd.note;

            lblFormTesto.Text = "";
            foreach (Datastructure.Form frm in wrd.getForms())
            {
                lblFormTesto.Text += frm.form + " (" + frm.type + ")" + " ";
            }

            lblDefinitionsTesto.Text = "";
            int i = 0;
            foreach (Datastructure.Definition def in wrd.GetDefinitions())
            {
                lblDefinitionsTesto.Text += i+")" + def.definition+ "\n";
                i++;
            }
        }

        
    }
}
