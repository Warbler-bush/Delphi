using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Datastructure;
using Utility;
using Delphi;
using System.Threading;
using System.Runtime.InteropServices;

namespace Apolly
{


    public partial class DelphiMain : System.Windows.Forms.Form
    {

        private DictManger dictManger;
        private List<Control> visualized_controls;

        // Remind
        private RichTextBox txtRemind;
        private Panel pnlRemind;

        // Table
        private Panel pnlTable;
        private RichTextBox txtTable;

        // Add
        private Panel pnlAdd;
        private Delphi.UCAdd UCAdd;

        //View
        private TableLayoutPanel pnlView;
        private UCWordView UCView;

        //Edit
        private TableLayoutPanel pnlEdit;
        private UCWordEdit UCEdit;

        //Search
        private TableLayoutPanel pnlSearch;

        // 0 -> P 1 -> N 2-> E
        private int curFlag = Datastructure.Dictionary.FLAG_W;
        

        // const means const and static 
        public const int TXT_MAIN = 0;
        public const int PNL_REMIND = 1;
        public const int PNL_ADDWORD = 2;
        public const int PNL_TABLE = 3;
        public const int PNL_SEARCH = 4;
        public const int PNL_VIEW = 5;
        public const int PNL_EDIT = 6;


        private const int N_WORD_TO_RIMIND = 5;

        



        

        private static void runShell()
        {
            Shell shell = new Shell();
            shell.Run();
            Application.Exit();
        }


        public DelphiMain()
        {
            Thread thr = new Thread(runShell);
            thr.Start();
            InitializeComponent();
        }
        /*---------------------------------------------------------*/

        private void ApollyMain_Load(object sender, EventArgs e)
        {   dictManger = DictManger.Manger(); 
            initControls();  
        }

        
        

        //init panel
        private void initPnl(Panel pnl)
        {
            pnl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnl.AutoSize = true;
            pnl.BringToFront();
            pnl.Dock = DockStyle.Fill;
        }

        //init txt

        private void initTxt(RichTextBox txt)
        {
            txt.BackColor = Color.DimGray;
            txt.ForeColor = Color.AntiqueWhite;
            txt.Cursor = System.Windows.Forms.Cursors.Default;
            txt.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txt.Dock = DockStyle.Fill;
            txt.Font = new Font("Courier New", 13);
            txt.ReadOnly = true;
        }

        //init components
        private void initPnlTxt(Panel pnl, RichTextBox txt)
        {
            initTxt(txt);
            initPnl(pnl);
            pnl.Controls.Add(txt);
        }

        public static void addScrollBarToPanel(Panel pnlPanel)
        {

            ScrollBar scrScrollBar = new VScrollBar();
            scrScrollBar.Visible = false;
            pnlPanel.Controls.Add(scrScrollBar);
        }


        
        private void initControls()
        {
            visualized_controls = new List<Control>() ;
            visualized_controls.Add(txtMain);

            
            //creating panelTable
            pnlTable = new Panel();
            txtTable = new RichTextBox();

            initPnlTxt(pnlTable, txtTable);
            visualized_controls.Add(pnlTable);
            pnlMain.Controls.Add(pnlTable);
            

            // creating panelRemind
            pnlRemind = new Panel();
            txtRemind = new RichTextBox();
            

            initPnlTxt(pnlRemind, txtRemind);
            visualized_controls.Add(pnlRemind);
            pnlMain.Controls.Add(pnlRemind);


            //creating panel Search
            pnlSearch = new TableLayoutPanel();
            pnlSearch.ColumnCount = 1;
            pnlSearch.RowCount = 1;


            initPnl(pnlSearch);

            visualized_controls.Add(pnlSearch);
            pnlMain.Controls.Add(pnlSearch);

            lblWord.ForeColor = Color.Red;


            //creating panel View
            pnlView = new TableLayoutPanel();
            UCView = new UCWordView();


            pnlView.ColumnCount = 1;
            pnlView.RowCount = 1;

            initPnl(pnlView);
            visualized_controls.Add(pnlView);
            pnlMain.Controls.Add(pnlView);


            UCView.Dock = DockStyle.Fill;
            UCView.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            pnlView.Controls.Add(UCView);
            UCView.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            //creating panel Edit
            pnlEdit = new TableLayoutPanel();
            UCEdit = new UCWordEdit();


            pnlEdit.ColumnCount = 1;
            pnlEdit.RowCount = 1;

            initPnl(pnlEdit);
            visualized_controls.Add(pnlEdit);
            pnlMain.Controls.Add(pnlEdit);


            UCEdit.Dock = DockStyle.Fill;
            UCEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            pnlEdit.Controls.Add(UCEdit);
            UCEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            //creating panelAdd
            pnlAdd = new Panel();
            UCAdd = new Delphi.UCAdd();


            //init UCAdd
            pnlAdd.Controls.Add(UCAdd);
            UCAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            
            visualized_controls.Add(pnlAdd);
            this.Controls.Add(pnlAdd);

            //init pnlAdd
            pnlAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlAdd.AutoSize = true;
            pnlMain.Controls.Add(pnlAdd);


           

            //init and add scrollbar
            addScrollBarToPanel(pnlAll);
            addScrollBarToPanel(pnlRemind);

            //SET CONTROLS ATTRIBUTES
            //-assign MouseEvent for cut/paste/copy
            txtRemind.MouseUp += new MouseEventHandler(this.txt_MouseUp);
            txtRemind.MouseUp += new MouseEventHandler(this.txt_MouseUp);
            
            visualize(PNL_REMIND);
            remindFunction(N_WORD_TO_RIMIND);
        }

        

        private bool remindFunction(int n)
        {
            txtRemind.Clear();
            List<Word> wrdRemind = dictManger.CurDict().wrdRemind(n);
            txtRemind.AppendText(list(wrdRemind));
            return false;
        }

        private string list(List<Word> list)
        {

            string ret = "";
            for(int i = 0; i< list.Count; i++)
                ret += (i+1) + ". " + list[i].title+"\n";

            return ret;
        }

        private void txt_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {   
                //click event
                //MessageBox.Show("you got it!");
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Cut");
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += new EventHandler(PasteAction);
                contextMenu.MenuItems.Add(menuItem);

                txtMain.ContextMenu = contextMenu;
            }
        }


        /**------------------------
         * COPY , PASTE, CUT 
            -----------------------*/

        void CutAction(object sender, EventArgs e)
        { txtRemind.Cut(); }

        void CopyAction(object sender, EventArgs e)
        { Clipboard.SetText(txtRemind.SelectedText);
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtRemind.Text
                    += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

        private void textMain_TextChanged(object sender, EventArgs e)
        {

        }


        public void visualize(int controlID)
        {

            foreach (Control frm in visualized_controls)
                frm.Visible = false;


            if (TXT_MAIN == controlID)
                txtMain.Visible = true;

            if (PNL_ADDWORD == controlID)
                pnlAdd.Visible = true;

            if (PNL_REMIND == controlID) {
                pnlRemind.Visible = true;
                remindFunction(N_WORD_TO_RIMIND);
            }

            if (PNL_TABLE == controlID)
            {
                pnlTable.Visible = true;
                showAllWords();
            }

            if(PNL_SEARCH == controlID)
            {
                pnlSearch.Visible = true;
            }

            if(PNL_VIEW == controlID)
            {
                pnlView.Visible = true;
            }

            if(PNL_EDIT == controlID)
            {
                pnlEdit.Visible = true;
            }
        }

        private void showAllWords()
        {
            txtTable.Clear();
            List<String> list = dictManger.CurDict().list(Dictionary.FLAG_E | Dictionary.FLAG_N | Dictionary.FLAG_W);

            for(int i = 0; i< list.Count; i++)
                txtTable.AppendText((i + 1) + ") " + list[i] + "\n");
            
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                MessageBox.Show("saved on input1.txt");
                dictManger.save("../../ input1.txt");
                return true;
            }

            if (keyData == (Keys.Control | Keys.T))
            {
                visualize(PNL_TABLE);
                return true;
            }

            if (keyData == (Keys.Control | Keys.R))
            {
                visualize(PNL_REMIND);
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                txtSearched.Focus();
                return true;
            }

            if (keyData == (Keys.Control | Keys.A))
            {
                visualize(PNL_ADDWORD);
                return true;
            }

            if (keyData == (Keys.Control | Keys.M))
            {
                visualize(TXT_MAIN);
                return true;
            }

            if(keyData == Keys.Enter && txtSearched.Focused)
            {
                search();
                return true;
            }

            return false;
        }

        private void btnTabella_Click(object sender, EventArgs e)
        {
            visualize(PNL_TABLE);
        }

        private void btnRemind_Click(object sender, EventArgs e)
        {
            visualize(PNL_REMIND);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            visualize(TXT_MAIN);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private bool search()
        {
            pnlSearch.Controls.Clear();
            pnlSearch.RowCount = pnlSearch.RowCount + 1;
            Text found = dictManger.CurDict().find(txtSearched.Text, curFlag);
            if (found == null)
                return true;

            UCText uText = new UCText(found, 1);
            pnlSearch.Controls.Add(uText);
            uText.bindDelphiMain(this);
            visualize(PNL_SEARCH);

            return false;
        }



        private void lblWord_Click(object sender, EventArgs e)
        {
            lblWord.ForeColor = Color.Red;
            lblExpre.ForeColor = Color.Black;
            lblNovel.ForeColor = Color.Black;
            curFlag = Datastructure.Dictionary.FLAG_W;
        }

        private void lblExpre_Click(object sender, EventArgs e)
        {

            lblWord.ForeColor = Color.Black;
            lblExpre.ForeColor = Color.Red;
            lblNovel.ForeColor = Color.Black;
            curFlag = Datastructure.Dictionary.FLAG_E;
        }

        private void lblNovel_Click(object sender, EventArgs e)
        {

            lblWord.ForeColor = Color.Black;
            lblExpre.ForeColor = Color.Black;
            lblNovel.ForeColor = Color.Red;
            curFlag = Datastructure.Dictionary.FLAG_N;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            visualize(PNL_ADDWORD);
        }

        public UCWordView getUCWordView()
        {
            return UCView;
        }

        public UCWordEdit getUCWordEdit()
        {
            return UCEdit;
        }
    }
        
    
}
