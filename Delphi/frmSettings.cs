using System;
using System.Windows.Forms;
using Datastructure;

namespace Delphi
{
    public partial class frmSettings : System.Windows.Forms.Form
    {
        private DictManger dictManger = DictManger.Manager();

        public frmSettings()
        {
            InitializeComponent();

            for(int i= 0; i< dictManger.getDictCount(); i++)
            {
                cmbDictToSelect.Items.Add(dictManger.getDict(i).Name+ " (" + dictManger.getDict(i).Language+")");
            }

            cmbDictToSelect.SelectedIndex = dictManger.getDictIdx(dictManger.CurDict());

            setFields();
            
        }


        public void setFields()
        {
            Dictionary dict = dictManger.CurDict();

            lblCurDict.Text = "Current Dictionary: " + dict.Name;
            lblLanguage.Text = "Language: "+ dict.Language;
            lblWordsCount.Text = "Words Count:"+dict.getWordsCount().ToString();
            lblExprCount.Text = "Expressions Count: " + dict.getExpressionsCount().ToString();
            lblNovelCount.Text = "Novels Count: "+ dict.getNovelsCount().ToString();
            lblDataCreation.Text = "Data Creation: " + dict.DataCreation.ToShortDateString();
        }



        //reload all things...
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbDictToSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            dictManger.setCurDict(cmbDictToSelect.SelectedIndex);
            setFields();
        }

        
    }
}
