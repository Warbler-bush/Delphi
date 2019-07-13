using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Utility;
using Datastructure;

namespace Delphi
{
    public partial class UCAddWord : UserControl
    {

        private WordBuilder wrdBuilder;
        private DelphiMain delphiMain;
        private Regex rgx = new Regex(@"^[a-zA-Z0-9_;]+$");
        private Regex rgxText = new Regex(@"^[a-zA-Z0-9_ \n]+$");
        private DictManger dictManger = DictManger.Manager();

        public void bindDelphiMain(DelphiMain delphi)
        { delphiMain = delphi;}

        public UCAddWord()
        {
            InitializeComponent();
            initComponents();
        }

        private void initComponents()
        {
            wrdBuilder = WordBuilder.wordBuilder();
            txtTradu.Enabled = false;
           
            cmbTipo.Items.AddRange(Datastructure.Dict_ITA.POS.ToArray());
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

                addForm();
                
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

        private void addForm()
        {

            if (rgxText.IsMatch(txtForm.Text) && rgxText.IsMatch(txtTypeForm.Text))
            {
                if (txtForm.Text.Length != 0 && txtTypeForm.Text.Length != 0)
                {
                    string line = txtForm.Text;
                    if (line.ElementAt(line.Length - 1) == ';')
                        line.Remove(line.Length - 1);

                    string[] forms = line.Split(';');


                     line = txtTypeForm.Text;
                    if (line.ElementAt(line.Length - 1) == ';')
                        line.Remove(line.Length - 1);

                    string[] typeForms = line.Split(';');

                    if(typeForms.Length == forms.Length)
                    {

                        for(int i = 0; i< forms.Length; i++)
                        {
                            Datastructure.Form frm = new Datastructure.Form(forms[i],typeForms[i]);
                            wrdBuilder.addForm(frm);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Inserire la form e i loro tipi!");
            }
        }
    }
}
