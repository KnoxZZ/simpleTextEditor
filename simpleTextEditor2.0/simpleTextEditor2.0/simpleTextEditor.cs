using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace simpleTextEditor2._0
{
    public partial class simpleTextEditor : Form
    {
        public simpleTextEditor()
        {
            InitializeComponent();
            
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
            string Path = ofd.FileName;
            mainTextBox.Text = File.ReadAllText(Path, Encoding.UTF8);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
