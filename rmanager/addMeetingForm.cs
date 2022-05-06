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
    public partial class addMeetingForm : Form
    {
        private userProfileForm parent;
        private int user_id;
        public addMeetingForm(userProfileForm parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;

        }
    }
}
