using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleTextEditor2._0
{
    public partial class sure : Form
    {
        public event EventHandler ReclickRequest;

        public sure()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnReclickRequest(EventArgs.Empty);
        }

        protected virtual void OnReclickRequest(EventArgs e)
        {
            EventHandler eh = ReclickRequest;
            if (eh != null)
                eh(this, e);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            OnReclickRequest(EventArgs.Empty);
        }
    }
}
