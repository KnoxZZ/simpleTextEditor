using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace simpleTextEditor2._0
{
    public partial class simpleTextEditor : Form
    {
        private string Path = null;
        public simpleTextEditor()
        {
            InitializeComponent();
            
        }
        private void save()
        {
            if(Path == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                Path = sfd.FileName;
                File.WriteAllText(Path, mainTextBox.Text, Encoding.Default);
            }
            else
            {
                File.WriteAllText(Path, mainTextBox.Text, Encoding.Default);
            }
        }

        private Boolean exit()
        {

            if (Path != null && !(mainTextBox.Text == File.ReadAllText(Path)))
            {
                sure op = new sure();
                op.Show();

                return false;
            }
            else if (Path == null)
            {
                sure op = new sure();
                op.Show();

                return false;
            }
            else
            {
                return true;
            }
        }

        private void simpleTextEditor_Load(object sender, EventArgs e)
        {

        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();
            Path = ofd.FileName;
            mainTextBox.Text = File.ReadAllText(Path, Encoding.Default);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(exit())
            {
                mainTextBox.Text = null;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Path = null;
            save();
        }
    }
}
