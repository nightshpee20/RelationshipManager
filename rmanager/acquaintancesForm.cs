using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmanager
{
    public partial class acquaintancesForm : Form
    {
        private userProfileForm parent;
        private int user_id;
        public acquaintancesForm(userProfileForm parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
        }

        private void addAcquaintanceButton_Click(object sender, EventArgs e)
        {
            addAcquaintanceForm add = new addAcquaintanceForm(this, user_id);
            add.Show();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acquaintancesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
