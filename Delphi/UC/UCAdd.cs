using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Utility;
using Datastructure;
using Apolly;

namespace Delphi
{
    public partial class UCAdd : UserControl
    {

        private WordBuilder wrdBuilder;
        private DelphiMain delphiMain;
        private Regex rgx = new Regex(@"^[a-zA-Z0-9_;]+$");
        private Regex rgxText = new Regex(@"^[a-zA-Z0-9_ \n]+$");
        private DictManger dictManger = DictManger.Manger();

        public void bindDelphiMain(DelphiMain delphi)
        { delphiMain = delphi;}

        public UCAdd()
        {
            InitializeComponent();
            initComponents();
        }

        private void initComponents()
        {
            wrdBuilder = WordBuilder.wordBuilder();
            txtTradu.Enabled = false;
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            
            if (rgx.IsMatch(txtWord.Text))
            {
                wrdBuilder.setTitle(txtWord.Text);

                if (rgxText.IsMatch(txtOri.Text))
                    wrdBuilder.setOrigin(txtOri.Text);
                else wrdBuilder.setOrigin("");

                if (rgxText.IsMatch(txtNote.Text))
                    wrdBuilder.setNote(txtNote.Text);
                else wrdBuilder.setNote("");

                if (rgx.IsMatch(txtType.Text))
                    wrdBuilder.setType(txtType.Text);
                else wrdBuilder.setType("");
                
                
                dictManger.CurDict().add(wrdBuilder.build());
                clrTextFields();
            }
            else
            {
                MessageBox.Show("Inserire una parola!");
            }

            
        }

        private void clrTextFields()
        {
            clrDef();
            txtNote.Clear();
            txtOri.Clear();
            txtType.Clear();
            txtWord.Clear();
        }

        private void btnAddDef_Click(object sender, EventArgs e)
        {

            if(rgxText.IsMatch(txtDefinizione.Text)  )
            {
                Definition defDef = new Definition(txtDefinizione.Text);
                if ( txtSino.Text.Length != 0 && rgx.IsMatch(txtSino.Text))
                {
                    string line = txtSino.Text;
                    if ( line.ElementAt(line.Length-1 ) == ';' )
                        line.Remove( line.Length-1);
                    string[] synonyms = line.Split(';');

                    foreach( string syn in synonyms)
                    {
                        Word wrd = dictManger.CurDict().findWord(syn);
                        if(wrd != null)
                        {
                            defDef.addSynonym(wrd);
                            Console.WriteLine(syn +" trovato");
                        }
                        else
                        {
                            Console.WriteLine(syn + " Non trovato");
                        }
                    }


                }


                if (rgx.IsMatch(txtContra.Text))
                {
                    string line = txtContra.Text;
                    if (line.ElementAt(line.Length - 1) == ';')
                        line.Remove(line.Length - 1);
                    string[] contraries = line.Split(';');

                    foreach (string ctr in contraries)
                    {
                        Word wrd = dictManger.CurDict().findWord(ctr);
                        if (wrd != null)
                        {
                            defDef.addContrary(wrd);
                            Console.WriteLine(ctr + " trovato");
                        }
                        else
                        {
                            Console.WriteLine(ctr + " Non trovato");
                        }
                    }

                }

                if (rgx.IsMatch(txtTradu.Text))
                {

                }

                wrdBuilder.addDefinition(defDef);
                clrDef();
            }
            else
            {
                MessageBox.Show("Inserire la definizione!");
            }
        }

        private void clrDef()
        {
            txtDefinizione.Clear();
            txtTradu.Clear();
            txtSino.Clear();
            txtContra.Clear();
        }
    }
}
