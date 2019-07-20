using System;
using System.Windows.Forms;
using Datastructure;

namespace Delphi
{
    public partial class UCText : UserControl
    {

        private DictManger dictManger = DictManger.Manager();
        private Text txt = null;
        private DelphiMain delphi;

        public UCText(Text text,int index)
        {

            txt = text;
            InitializeComponent();
            lblTitle.Text = index.ToString() + ") " + text.title;

            if(text.GetType() == typeof(Word))
            {
                Word wrd = (Word) text;
                lblTitle.Text += "( "+wrd.getType()+" )";
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
            if (txt.GetType() == typeof(Word))
            {
                delphi.UCWordView1.setWord((Word)txt);
                delphi.changePanel(DelphiMain.PNL_VIEW_WORD);
            }

            if (txt.GetType() == typeof(Expression))
            {
                delphi.UCExpView1.setExpression((Expression)txt);
                delphi.changePanel(DelphiMain.PNL_VIEW_EXPRESSION);
            }

            if (txt.GetType() == typeof(Novel))
            {
                delphi.UCNovelView1.setNovel((Novel)txt);
                delphi.changePanel(DelphiMain.PNL_VIEW_NOVEL);
            }

            

        }

        




        private void btnEdit_Click(object sender, EventArgs e)
        {
            

            if (txt.GetType() == typeof(Word))
            {
                delphi.UCWordEdit1.setWord((Word)txt);
                delphi.changePanel(DelphiMain.PNL_EDIT_WORD);
            }

            if (txt.GetType() == typeof(Expression))
            {
                delphi.UCExpEdit1.setExpression((Expression)txt);
                delphi.changePanel(DelphiMain.PNL_EDIT_EXPRESSION);
            }

            if (txt.GetType() == typeof(Novel))
            {
                delphi.UCNovelEdit1.setNovel((Novel)txt);
                delphi.changePanel(DelphiMain.PNL_EDIT_NOVEL);
            }


        }

        public void bindDelphiMain(DelphiMain delphi)
        {
            this.delphi = delphi;
        }

        
    }
}
