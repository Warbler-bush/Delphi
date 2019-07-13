using Datastructure;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utility;

namespace Delphi
{
    public partial class UCAddNovel : UserControl
    {
        private NovelBuilder nvlBuilder = null;
        private Regex rgx = new Regex(@"^[a-zA-Z0-9_;]+$");
        private Regex rgxText = new Regex(@"^[a-zA-Z0-9_ \n]+$");
        private DictManger dictManger = DictManger.Manager();

        public UCAddNovel()
        {
            nvlBuilder = NovelBuilder.novelBuilder();
            InitializeComponent();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            dictManger.CurDict().add(
                        nvlBuilder.
                        setAuthor(txtAuthor.Text).
                        setTitle(txtNovel.Text).
                        setOrigin(txtOri.Text).
                        setNote(txtNote.Text).
                        build())
            ;

            clearFields();
        }

        private void clearFields()
        {
            txtAuthor.Text = "";
            txtNovel.Text = "";
            txtOri.Text = "";
            txtNote.Text = "";
        }

    }
}
