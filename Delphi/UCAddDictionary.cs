using Datastructure;
using System.Collections.Generic;
using System.Windows.Forms;
using Utility;

namespace Delphi
{
    public partial class UCAddDictionary : UserControl
    {

        private DictBuilder dictBuilder = null;
        private DictManger manger = DictManger.Manager();
        //
        //es -> spanish
        //
        private List<string> languages = new List<string>{ "it","en","de","fr","es"};

        public UCAddDictionary()
        {
            InitializeComponent();
            dictBuilder = DictBuilder.dictBuilder();
            cmbLanguage.Items.AddRange(languages.ToArray());
            cmbLanguage.SelectedItem = languages[0];
        }

        // si pressupone di effettuare i controlli nel builder.
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            manger.addDict( 
                dictBuilder.
                setName(txtDictionary.Text).
                setLanguage((string)cmbLanguage.SelectedItem).
                build()
            );

            clearFields();
        }

        private void clearFields()
        {
            txtDictionary.Text = "";
        }
    }
}
