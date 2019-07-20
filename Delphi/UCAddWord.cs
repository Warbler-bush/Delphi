using System;
using System.Linq;
using System.Windows.Forms;

using Utility;
using Datastructure;

namespace Delphi
{
    public partial class UCAddWord : UserControl
    {

        private WordBuilder wrdBuilder;
        private DelphiMain delphiMain;
        private DictManger dictManger = DictManger.Manager();
        private int cntDef = 0;

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
           
            cmbTipo.Items.AddRange(Dict_ITA.POS.ToArray());
            cmbTipo.SelectedItem = Dict_ITA.POS[0];

            cmbLanguage.Items.AddRange(Dictionary.languages.ToArray());
            cmbLanguage.SelectedItem = Dictionary.languages[0];
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            
            if (TextBuilder.rgx.IsMatch(txtWord.Text))
            {
                wrdBuilder.setTitle(txtWord.Text);

                if (TextBuilder.rgxText.IsMatch(txtOri.Text))
                    wrdBuilder.setOrigin(txtOri.Text);
                else wrdBuilder.setOrigin("");

                if (TextBuilder.rgxText.IsMatch(txtNote.Text))
                    wrdBuilder.setNote(txtNote.Text);
                else wrdBuilder.setNote("");

                addForm();

                wrdBuilder.setType((string)cmbTipo.SelectedItem);
                Word wrd = (Word)wrdBuilder.build();
                dictManger.CurDict().add(wrd);

                clrTextFields();
            }
            else MessageBox.Show("Inserire una parola adatta!");
            

            
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

            if(TextBuilder.rgxText.IsMatch(txtDefinizione.Text)  )
            {
                Definition defDef = new Definition(txtDefinizione.Text);
                
                // insert synonyms
                if ( txtSino.Text.Length != 0 && TextBuilder.rgx.IsMatch(txtSino.Text))
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


                // insert contradiction
                if (TextBuilder.rgx.IsMatch(txtContra.Text))
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

                wrdBuilder.addDefinition(defDef);


                if (TextBuilder.rgx.IsMatch(txtTradu.Text))
                {
                    string line = txtTradu.Text;
                    if (line.ElementAt(line.Length - 1) == ';')
                        line.Remove(line.Length - 1);

                    string language = (string)cmbLanguage.SelectedItem;
                    string[] translations = line.Split(';');
                    foreach (string tra in translations)
                    {
                        for(int cntDict = 0; cntDict < dictManger.getDictCount(); cntDict++)
                        {
                            Dictionary dict = dictManger.getDict(cntDict);
                            if (dict.Language == language )
                            {
                                Text found = dict.find(tra);
                                if(found != null && found.GetType() == typeof(Word) ) {
                                    wrdBuilder.addTranslation(new Translation(cntDict,language, found),cntDef);
                                    break;
                                }
                            }

                        }
                    }

                }

                cntDef++;
                clrDef();
            }
            else
            {
                MessageBox.Show("Inserire una definizione!");
            }
        }



        private void addForm()
        {
            if (string.IsNullOrWhiteSpace(txtForm.Text) || string.IsNullOrWhiteSpace(txtTypeForm.Text))
                return;
            



            if (TextBuilder.rgxText.IsMatch(txtForm.Text) && TextBuilder.rgxText.IsMatch(txtTypeForm.Text))
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
