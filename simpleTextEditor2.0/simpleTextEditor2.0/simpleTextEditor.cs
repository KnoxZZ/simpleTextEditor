using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace simpleTextEditor2._0
{
    public partial class simpleTextEditor : Form
    {
        private string Path = null;
        sure op = new sure();

        public simpleTextEditor()
        {
            InitializeComponent();
            
        }
        private void save()
        {
            if(Path == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                DialogResult dr = sfd.ShowDialog();
                Path = sfd.FileName;
                if (dr == DialogResult.OK)
                {
                    File.WriteAllText(Path, mainTextBox.Text, Encoding.Default);
                }
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
                op.Show();

                return false;
            }
            else if (Path == null)
            {
                op.Show();

                return false;
            }
            else
            {
                return true;
            }
        }

        private void open()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();
            Path = ofd.FileName;
            if (dr == DialogResult.OK)
            {
                mainTextBox.Text = File.ReadAllText(Path, Encoding.Default);
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
            open();
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.SelectedText = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTextBox.SelectedText != "")
            {
                mainTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTextBox.SelectedText != "")
            {
                mainTextBox.Copy();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTextBox.CanUndo == true)
            {
                mainTextBox.Undo();
                mainTextBox.ClearUndo();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                save();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                open();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Z))
            {
                if (mainTextBox.CanUndo == true)
                {
                    mainTextBox.Undo();
                    mainTextBox.ClearUndo();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if(mainTextBox.CanRedo == true)
            {
                mainTextBox.Redo();
            }
            */
        }

    }
}
