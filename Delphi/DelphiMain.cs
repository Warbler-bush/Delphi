using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Datastructure;
using Utility;
using System.Threading;

namespace Delphi
{
    public partial class DelphiMain : System.Windows.Forms.Form
    {
        // Dicionaries manger
        private DictManger dictManger;

        //list that manages the controls
        private List<Control> visualized_controls;

        //list that manages the history of operations
        private List<int> chronology;
            //it's a index of which panel atm the user is visualizing 
        private int curPanelIdx;

        // Remind
        private RichTextBox txtRemind;
        private Panel pnlRemind;

        // Table
        private Panel pnlTable;
        private RichTextBox txtTable;

        // AddWord
        private Panel pnlAddWord;
        private Delphi.UCAddWord UCAddWord;

        //AddExpr
        private Panel pnlAddExpression;
        private UCAddExpression UCAddExpression;

        //AddNovel
        private Panel pnlAddNovel;
        private UCAddNovel UCAddNovel;

        //AddDictionary 
        private Panel pnlAddDictionary;
        private UCAddDictionary UCAddDictionary;

        //View W/E/N
        private Panel pnlWordView;
        private UCWordView UCWordView;


        private Panel pnlExpView;
        private UCExpressionView UCExpView;

        private Panel pnlNovelView;
        private UCNovelView UCNovelView;

        
        //Edit W/E/N
        private Panel pnlWordEdit;
        private UCWordEdit UCWordEdit;

        private Panel pnlExpEdit;
        private UCExpressionEdit UCExpEdit;

        private Panel pnlNovelEdit;
        private UCNovelEdit UCNovelEdit;

        //Search
        private TableLayoutPanel pnlSearch;
        private Label lblInfoSearching; 
        public static Color PNL_SEARCH_COLOR = Color.White;
        public static  Color GAINSBORO = Color.FromArgb(220,220,220);

        // 0 -> P 1 -> N 2-> E
        private int curFlag = Dictionary.FLAG_W | Dictionary.FLAG_N | Dictionary.FLAG_E;
        

        // const means const and static 
        public const int TXT_MAIN = 0;
        public const int PNL_REMIND = 1;
        public const int PNL_ADD = 2;
        public const int PNL_TABLE = 3;
        public const int PNL_SEARCH = 4;
        public const int PNL_VIEW_WORD = 5;
        public const int PNL_VIEW_NOVEL = 6;
        public const int PNL_VIEW_EXPRESSION = 7; 

        public const int PNL_EDIT_WORD = 8;
        public const int PNL_EDIT_EXPRESSION = 9;
        public const int PNL_EDIT_NOVEL = 10;

        public const int PNL_ADD_WORD = 11;
        public const int PNL_ADD_EXPRESSION = 12;
        public const int PNL_ADD_NOVEL = 13;
        public const int PNL_ADD_DICT = 14;


        private const int N_WORD_TO_RIMIND = 20;

        public UCExpressionView UCExpView1 { get => UCExpView; set => UCExpView = value; }
        public UCNovelView UCNovelView1 { get => UCNovelView; set => UCNovelView = value; }
        public UCExpressionEdit UCExpEdit1 { get => UCExpEdit; set => UCExpEdit = value; }
        public UCNovelEdit UCNovelEdit1 { get => UCNovelEdit; set => UCNovelEdit = value; }
        public UCWordView UCWordView1 { get => UCWordView; set => UCWordView = value; }
        public UCWordEdit UCWordEdit1 { get => UCWordEdit; set => UCWordEdit = value; }

        private static void runShell()
        {
            DShell shell = new DShell();
            shell.Run();
            Application.Exit();
        }
        public DelphiMain()
        {
            Thread thr = new Thread(runShell);
            thr.Start();
            InitializeComponent();
            dictManger = DictManger.Manager();
            initControls();
        }
        /*---------------------------------------------------------*/

        

        //init panel
        private void initPnl(Panel pnl)
        {
            pnl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnl.AutoScroll = true;
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
            pnlMain.GetType();
            // init the name of current dictionary
            lblDictName.Text = dictManger.CurDict().Name + " ("+dictManger.CurDict().Language+") ";

            // manger the chronology of clicks and visualization
            visualized_controls = new List<Control>() ;
            visualized_controls.Add(txtMain);

            chronology = new List<int>();
            
            //---------------------------------
            //creating panelTable
            //---------------------------------
            pnlTable = new Panel();
            txtTable = new RichTextBox();

            initPnlTxt(pnlTable, txtTable);
            visualized_controls.Add(pnlTable);
            pnlMain.Controls.Add(pnlTable);


            //---------------------------------
            // creating panelRemind
            //---------------------------------
            pnlRemind = new Panel();
            txtRemind = new RichTextBox();
            

            initPnlTxt(pnlRemind, txtRemind);
            visualized_controls.Add(pnlRemind);
            pnlMain.Controls.Add(pnlRemind);


            //---------------------------------
            //creating panel Search
            //---------------------------------
            pnlSearch = new TableLayoutPanel();
            lblInfoSearching = new Label();

            
            pnlSearch.BackColor = PNL_SEARCH_COLOR;
            pnlSearch.ColumnCount = 1;
            pnlSearch.RowCount = 0;

            lblInfoSearching.Font = new Font(FontFamily.GenericMonospace,15) ;
            lblInfoSearching.Dock = DockStyle.Fill;


            initPnl(pnlSearch);
            pnlSearch.Dock = DockStyle.None;
            pnlSearch.Size = txtMain.Size;
            


            visualized_controls.Add(pnlSearch);
            pnlMain.Controls.Add(pnlSearch);

            lblAll.ForeColor = Color.Red;


            //---------------------------------
            //creating panel View
            //---------------------------------
            pnlWordView = new TableLayoutPanel();
            pnlExpView = new TableLayoutPanel();
            pnlNovelView = new TableLayoutPanel();

            UCWordView = new UCWordView();
            UCExpView = new UCExpressionView();
            UCNovelView = new UCNovelView();



            initPnl(pnlWordView);
            visualized_controls.Add(pnlWordView);
            pnlMain.Controls.Add(pnlWordView);

            initPnl(pnlExpView);
            visualized_controls.Add(pnlExpView);
            pnlMain.Controls.Add(pnlExpView);


            initPnl(pnlNovelView);
            visualized_controls.Add(pnlNovelView);
            pnlMain.Controls.Add(pnlNovelView);


           
            UCWordView.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            
            UCExpView.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            
            UCNovelView.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            pnlWordView.Controls.Add(UCWordView);
            pnlExpView.Controls.Add(UCExpView);
            pnlNovelView.Controls.Add(UCNovelView);


            //---------------------------------
            //creating panel Edit
            //---------------------------------
            pnlWordEdit = new TableLayoutPanel();
            pnlExpEdit = new TableLayoutPanel();
            pnlNovelEdit = new TableLayoutPanel();

            UCWordEdit = new UCWordEdit();
            UCExpEdit = new UCExpressionEdit();
            UCNovelEdit = new UCNovelEdit();


            

            initPnl(pnlWordEdit);
            visualized_controls.Add(pnlWordEdit);
            pnlMain.Controls.Add(pnlWordEdit);

            initPnl(pnlExpEdit);
            visualized_controls.Add(pnlExpEdit);
            pnlMain.Controls.Add(pnlExpEdit);

            initPnl(pnlNovelEdit);
            visualized_controls.Add(pnlNovelEdit);
            pnlMain.Controls.Add(pnlNovelEdit);

            
            UCWordEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            
            UCExpEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            
            UCNovelEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            pnlWordEdit.Controls.Add(UCWordEdit);
            pnlExpEdit.Controls.Add(UCExpEdit);
            pnlNovelEdit.Controls.Add(UCNovelEdit);


            //---------------------------------
            //creating panelAddWord
            //---------------------------------
            pnlAddWord = new Panel();
            UCAddWord = new Delphi.UCAddWord();

            //init UCAddWord
            pnlAddWord.Controls.Add(UCAddWord);
            UCAddWord.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            initPnl(pnlAddWord);
            visualized_controls.Add(pnlAddWord);
            this.Controls.Add(pnlAddWord);

            pnlMain.Controls.Add(pnlAddWord);

            //---------------------
            //init pnlAddExpre
            //----------------------
            pnlAddExpression = new Panel();
            UCAddExpression = new Delphi.UCAddExpression();

            //init UCAddWord
            pnlAddExpression.Controls.Add(UCAddExpression);
            UCAddExpression.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            initPnl(pnlAddExpression);
            visualized_controls.Add(pnlAddExpression);
            this.Controls.Add(pnlAddExpression);

            //init pnlAdd
            pnlMain.Controls.Add(pnlAddExpression);


            //---------------------
            //init pnlAddNovel
            //----------------------
            pnlAddNovel = new Panel();
            UCAddNovel = new Delphi.UCAddNovel();

            //init UCAddWord
            pnlAddNovel.Controls.Add(UCAddNovel);
            UCAddNovel.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            initPnl(pnlAddNovel);
            visualized_controls.Add(pnlAddNovel);
            this.Controls.Add(pnlAddNovel);

            //init pnlAdd
            pnlMain.Controls.Add(pnlAddNovel);


            //---------------------
            //init pnlAddDictionary
            //----------------------
            pnlAddDictionary = new Panel();
            UCAddDictionary = new Delphi.UCAddDictionary();

            //init UCAddWord
            pnlAddDictionary.Controls.Add(UCAddDictionary);
            UCAddDictionary.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            visualized_controls.Add(pnlAddDictionary);
            this.Controls.Add(pnlAddDictionary);

            //init pnlAdd
            pnlAddDictionary.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlAddDictionary.AutoSize = true;
            pnlMain.Controls.Add(pnlAddDictionary);

            //adding panelAddChoice
            visualized_controls.Add(pnlAddChoice);

            //---------------------------------
            //init and add scrollbar
            //---------------------------------
            addScrollBarToPanel(pnlAll);
            addScrollBarToPanel(pnlRemind);

            //SET CONTROLS ATTRIBUTES
            //-assign MouseEvent for cut/paste/copy
            txtRemind.MouseUp += new MouseEventHandler(this.txt_MouseUp);
            txtRemind.MouseUp += new MouseEventHandler(this.txt_MouseUp);
            
            changePanel(PNL_REMIND);
            remindFunction(N_WORD_TO_RIMIND);
        }

        private bool remindFunction(int n)
        {
            txtRemind.Clear();
            List<Word> wrdRemind = dictManger.CurDict().wrdRemind(n);
            
            txtRemind.AppendText(list(wrdRemind) );
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

        private void reload()
        {
            remindFunction(N_WORD_TO_RIMIND);
            showAllWords();
            lblDictName.Text = dictManger.CurDict().Name + " (" + dictManger.CurDict().Language + ")";
        }

        public void visualize(int controlID)
        {
            foreach (Control frm in visualized_controls)
                frm.Visible = false;


            if (TXT_MAIN == controlID)
                txtMain.Visible = true;

            if (PNL_ADD == controlID)
                pnlAddChoice.Visible = true;
                
            if (PNL_REMIND == controlID)
            {
                pnlRemind.Visible = true;
                remindFunction(N_WORD_TO_RIMIND);
            }

            if (PNL_TABLE == controlID)
            {
                pnlTable.Visible = true;
                showAllWords();
            }

            if (PNL_SEARCH == controlID)
            {
                pnlSearch.Visible = true;
            }

            if (PNL_VIEW_WORD == controlID)
            {
                pnlWordView.Visible = true;
            }

            if (PNL_VIEW_EXPRESSION == controlID)
            {
                pnlExpView.Visible = true;
            }

            if (PNL_VIEW_NOVEL == controlID)
            {
                pnlNovelView.Visible = true;
            }

            if (PNL_EDIT_WORD == controlID)
            {
                pnlWordEdit.Visible = true;
            }


            if (PNL_EDIT_EXPRESSION == controlID)
            {
                pnlExpEdit.Visible = true;
            }

            if (PNL_EDIT_NOVEL == controlID)
            {
                pnlNovelEdit.Visible = true;
            }


            if (PNL_ADD_WORD == controlID)
            {
                pnlAddWord.Visible = true;
            }

            if(PNL_ADD_EXPRESSION == controlID)
            {
                pnlAddExpression.Visible = true;
            }
            
            if(PNL_ADD_NOVEL == controlID)
            {
                pnlAddNovel.Visible = true;
            }

            if(PNL_ADD_DICT == controlID)
            {
                pnlAddDictionary.Visible = true;
            }
            

        }

        public void changePanel(int controlID)
        {
            if(curPanelIdx != chronology.Count - 1 && chronology.Count != 0)
            {
                chronology.RemoveRange(curPanelIdx+1,chronology.Count-curPanelIdx-1);
            }

            chronology.Remove(controlID);
            chronology.Add(controlID);
            curPanelIdx = chronology.Count-1;


            visualize(controlID);
        }

        private void showAllWords()
        {
            txtTable.Clear();
            string list = dictManger.CurDict().list(Dictionary.FLAG_E | Dictionary.FLAG_N | Dictionary.FLAG_W);
            txtTable.AppendText( list+ "\r\n");
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
                changePanel(PNL_TABLE);
                return true;
            }

            if (keyData == (Keys.Control | Keys.R))
            {
                changePanel(PNL_REMIND);
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                txtSearched.Focus();
                return true;
            }

            if (keyData == (Keys.Control | Keys.A))
            {
                changePanel(PNL_ADD);
                return true;
            }

            if (keyData == (Keys.Control | Keys.M))
            {
                changePanel(TXT_MAIN);
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
            changePanel(PNL_TABLE);
        }

        private void btnRemind_Click(object sender, EventArgs e)
        {
            changePanel(PNL_REMIND);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            changePanel(TXT_MAIN);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private bool search()
        {
            pnlSearch.Controls.Clear();

            pnlSearch.RowCount ++;
            pnlSearch.Controls.Add(lblInfoSearching);

            Utilities.startTimer();
            List<Text> text = dictManger.CurDict().PBS(txtSearched.Text);
            long ms = Utilities.endTimer();


            lblInfoSearching.Text = "found:" + text.Count + "  time used:" + ms + " ms";
            if (text.Count == 0) {
                lblInfoSearching.Text = "not " + lblInfoSearching.Text;
                return true;
            }


            
            for(int i = 0; i< text.Count; i++) { 
                pnlSearch.RowCount += 2;
                UCText uText = new UCText(text[i], i+1);
                pnlSearch.Controls.Add(uText);
                uText.bindDelphiMain(this);
            }



            changePanel(PNL_SEARCH);

            return false;
        }

        private void lblWord_Click(object sender, EventArgs e)
        {
            lblWord.ForeColor = Color.Red;
            lblExpre.ForeColor = Color.Black;
            lblNovel.ForeColor = Color.Black;
            lblAll.ForeColor = Color.Black;
            curFlag = Datastructure.Dictionary.FLAG_W;
        }

        private void lblExpre_Click(object sender, EventArgs e)
        {

            lblWord.ForeColor = Color.Black;
            lblExpre.ForeColor = Color.Red;
            lblNovel.ForeColor = Color.Black;
            lblAll.ForeColor = Color.Black;
            curFlag = Datastructure.Dictionary.FLAG_E;
        }

        private void lblNovel_Click(object sender, EventArgs e)
        {

            lblWord.ForeColor = Color.Black;
            lblExpre.ForeColor = Color.Black;
            lblNovel.ForeColor = Color.Red;
            lblAll.ForeColor = Color.Black;
            curFlag = Datastructure.Dictionary.FLAG_N;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            changePanel(PNL_ADD);
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            lblWord.ForeColor = Color.Black;
            lblExpre.ForeColor = Color.Black;
            lblNovel.ForeColor = Color.Black;
            lblAll.ForeColor = Color.Red;
            curFlag = Datastructure.Dictionary.FLAG_E | Datastructure.Dictionary.FLAG_W | Datastructure.Dictionary.FLAG_N;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if(curPanelIdx < chronology.Count - 1)
            {
                curPanelIdx++;
                visualize(chronology[curPanelIdx]);
            }

        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if(curPanelIdx > 0)
            {
                curPanelIdx--;
                visualize(chronology[curPanelIdx]);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            visualize(chronology[curPanelIdx]);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog(this);
            Dictionary curDict = dictManger.CurDict();
            if (lblDictName.Text != (curDict.Name + " (" + curDict.Language + ")" ) )
            {
                reload();
            }

        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            changePanel(PNL_ADD_WORD);
        }

        private void btnExpression_Click(object sender, EventArgs e)
        {
            changePanel(PNL_ADD_EXPRESSION);
        }

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            changePanel(PNL_ADD_DICT);
        }

        private void btnNovel_Click(object sender, EventArgs e)
        {
            changePanel(PNL_ADD_NOVEL);
        }
    }
        
    
}
