using System;
using System.Linq;
using System.Windows.Forms;

using Datastructure;
using System.Text.RegularExpressions;

namespace Delphi
{
    public partial class UCWordEdit : UserControl
    {

        private Datastructure.Word wrd = null;
        private int curDef = 0;
        private Regex rgx = new Regex(@"^[a-zA-Z0-9_;]+$");
        private Regex rgxText = new Regex(@"^[a-zA-Z0-9_ \n]+$");
        private DictManger dictManger = DictManger.Manager();

        public UCWordEdit()
        {
            InitializeComponent();
            cmbTipo.Items.AddRange(Datastructure.Dict_ITA.POS.ToArray());
            cmbLanguage.Items.AddRange(Dictionary.languages.ToArray());
        }


        public void setDefinition(int index)
        {
            if (index > wrd.getDefinitionCount() || index < 0)
                return;

            Definition def = wrd.getDefinition(index);
            txtDefinizione.Text = def.definition;


            //synonyms
            foreach(Text syn in def.getSynonyms())
            {
                txtSino.Text = syn.title + ";";
            }

            if (txtSino.Text.Length > 0)
                txtSino.Text.Remove(txtSino.Text.Length - 1);



            // contraries
            foreach (Text contr in def.getContraries())
            {
                txtContra.Text = contr.title + ";";
            }

            if (txtContra.Text.Length > 0)
                txtContra.Text.Remove(txtContra.Text.Length - 1);
            
            // translations
            foreach(Translation tran in wrd.getTranslations(def))
            {
                txtTradu.Text += tran.getTranslated().title + ";";
            }

            if (txtContra.Text.Length > 0)
                txtContra.Text.Remove(txtContra.Text.Length - 1);

        }

        public void setWord(Datastructure.Word wrd)
        {
            clsFields();
            this.wrd = wrd;

            lblTitle.Text = wrd.title;
            cmbTipo.Text = wrd.getType();
            txtOrigine.Text = wrd.origin;
            txtNota.Text = wrd.note;

            foreach(Datastructure.Form frm in wrd.getForms())
            {
                txtForme.Text += frm.form + " (" + frm.type + "),";
            }

            if(txtForme.Text.Length > 0)
                txtForme.Text.Remove(txtForme.Text.Length-1);


            lblNumDef.Text = wrd.getDefinitionCount().ToString();
            if (wrd.getDefinitionCount() == 0)
                lblCurDef.Text = "0";
            else { 
                setDefinition(0);
                lblCurDef.Text = "1";
            }
        }

        private void clsDef()
        {
            txtDefinizione.Text = "";
            txtContra.Text = "";
            txtSino.Text = "";
            txtTradu.Text = "";
        }

        private void clsFields()
        {
            txtOrigine.Text = "";
            txtNota.Text = "";
            txtForme.Text = "";
            cmbTipo.Text = "";
            clsDef();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if ( curDef >= wrd.getDefinitionCount() - 1)
            {
                Definition def = new Definition("");
                wrd.addDefinition(def);
                lblNumDef.Text = (curDef + 2).ToString();
            }
                

            curDef++;
            setDefinition(curDef);
            lblCurDef.Text = (curDef+1).ToString();
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if (curDef <= 0)
                return;

            curDef--;
            setDefinition(curDef);
            lblCurDef.Text = (curDef + 1).ToString();
        }


        private void cambiaDef()
        {

            Definition defDef = wrd.getDefinition(curDef);

            if (rgxText.IsMatch(txtDefinizione.Text))
            {

                defDef.definition = txtDefinizione.Text;
                defDef.clearSynonyms();
                defDef.clearContraries();

                if (txtSino.Text.Length != 0 && rgx.IsMatch(txtSino.Text))
                {
                    string line = txtSino.Text;
                    if (line.ElementAt(line.Length - 1) == ';')
                        line.Remove(line.Length - 1);
                    string[] synonyms = line.Split(';');

                    foreach (string syn in synonyms)
                    {
                        Word wrd = dictManger.CurDict().findWord(syn);
                        if (wrd != null)
                        {
                            defDef.addSynonym(wrd);
                            Console.WriteLine(syn + " trovato");
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
                    string line = txtTradu.Text;
                    if (line.ElementAt(line.Length - 1) == ';')
                        line.Remove(line.Length - 1);

                    string language = (string)cmbLanguage.SelectedItem;
                    string[] translations = line.Split(';');
                    foreach (string tra in translations)
                    {
                        for (int cntDict = 0; cntDict < dictManger.getDictCount(); cntDict++)
                        {
                            Dictionary dict = dictManger.getDict(cntDict);
                            if (dict.Language == language)
                            {
                                Text found = dict.find(tra);
                                if (found != null && found.GetType() == typeof(Word))
                                {
                                    wrd.addTranslation(new Translation(cntDict, language, found),defDef);
                                    break;
                                }
                            }

                        }
                    }
            }
            }
            else
            {
                MessageBox.Show("Inserire la definizione!");
            }
        }

        private void btnCambDef_Click(object sender, EventArgs e)
        {
            cambiaDef();

            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            wrd.setType ((String)cmbTipo.SelectedValue);
            wrd.origin  = txtOrigine.Text;
            wrd.note    = txtNota.Text;
            cambiaDef();

            string line = txtTradu.Text;
            if (line.ElementAt(line.Length - 1) == ';')
                line.Remove(line.Length - 1);

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            wrd.removeDefinition(curDef);


            if (curDef == 0 && wrd.getDefinitionCount() == 0)
            {
                lblCurDef.Text = "0";
                clsDef();
                curDef--;
            }
            else setDefinition(curDef);
                
            lblNumDef.Text = wrd.getDefinitionCount().ToString();
        }
    }
}
