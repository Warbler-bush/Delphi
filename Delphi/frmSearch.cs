using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apolly;
using Datastructure;

namespace Delphi
{
    public partial class frmSearch : System.Windows.Forms.Form
    {
        private DelphiMain delphiMain;
        private DictManger dictManger = DictManger.Manger();
        

        public frmSearch()
        {
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            txtSearch.KeyDown += txtSearch_KeyDown;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Word wrdWord = (Word)search();
                if (wrdWord != null)
                    Console.WriteLine(wrdWord.toString());
                else Console.WriteLine("Non Trovato");

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyData == Keys.Escape)
            {
                this.Hide();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                this.Hide();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        internal void bindDelphiMain(DelphiMain delphiMain)
        {
            this.delphiMain = delphiMain;
        }


        public Text search()
        {
            string wrd = txtSearch.Text;
            Word wrdWord = dictManger.CurDict().findWord(wrd);
            return wrdWord;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Word wrdWord = (Word)search();
            if (wrdWord != null)
                Console.WriteLine(wrdWord.toString());
            else Console.WriteLine("Non Trovato");

        }

      
    }
}
