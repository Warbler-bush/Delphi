using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datastructure;
using Apolly;

namespace Delphi
{
    public partial class UCText : UserControl
    {

        private DictManger dictManger = DictManger.Manger();
        private Text txt = null;
        private DelphiMain delphi;

        public UCText(Text text,int index)
        {
            txt = text;
            InitializeComponent();
            lblIndex.Text = index.ToString()+")";
            lblWord.Text = text.title;

            if(text.GetType() == typeof(Word))
            {
                Word wrd = (Word) text;
                lblWord.Text += "( "+wrd.getType()+" )";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("remove complete of " + txt.title);
            //devo creare una form per ottenere un message box che non sia bloccante.
            dictManger.CurDict().remove(txt);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            delphi.getUCWordView().setWord((Word)txt);
            delphi.visualize(DelphiMain.PNL_VIEW);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            delphi.getUCWordEdit().setWord((Word)txt);
            delphi.visualize(DelphiMain.PNL_EDIT);
        }


        public void bindDelphiMain(DelphiMain delphi)
        {
            this.delphi = delphi;
        }

        
    }
}
