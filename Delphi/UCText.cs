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
            resetVisibilityOfViews();
            if (txt.GetType() == typeof(Word))
            {
                delphi.UCWordView1.setWord((Word)txt);
                delphi.UCWordView1.Visible = true;
            }

            if (txt.GetType() == typeof(Expression))
            {
                delphi.UCExpView1.setExpression((Expression)txt);
                delphi.UCExpView1.Visible = true;
            }

            if (txt.GetType() == typeof(Novel))
            {
                delphi.UCNovelView1.setNovel((Novel)txt);
                delphi.UCNovelView1.Visible = true;
            }

            delphi.changePanel(DelphiMain.PNL_VIEW);

        }

        private void resetVisibilityOfViews()
        {
            delphi.UCWordView1.Visible = false;
            delphi.UCExpView1.Visible = false;
            delphi.UCNovelView1.Visible = false;
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {

            resetVisibilityOfEdits();

            if (txt.GetType() == typeof(Word))
            {
                delphi.UCWordEdit1.setWord((Word)txt);
                delphi.UCWordEdit1.Visible = true;
            }

            if (txt.GetType() == typeof(Expression))
            {
                delphi.UCExpEdit1.setExpression((Expression)txt);
                delphi.UCExpEdit1.Visible = true;
            }

            if (txt.GetType() == typeof(Novel))
            {
                delphi.UCNovelEdit1.setNovel((Novel)txt);
                delphi.UCNovelEdit1.Visible = true;
            }

            delphi.changePanel(DelphiMain.PNL_EDIT);

        }

        private void resetVisibilityOfEdits()
        {
            delphi.UCWordEdit1.Visible = false;
            delphi.UCExpEdit1.Visible = false;
            delphi.UCNovelEdit1.Visible = false;
        }

        public void bindDelphiMain(DelphiMain delphi)
        {
            this.delphi = delphi;
        }

        
    }
}
