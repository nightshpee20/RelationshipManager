using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            displayAcquaintances(acquaintancesDataGridView);
        }
        //REMOVE AFTER TESTING
        public acquaintancesForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            displayAcquaintances(acquaintancesDataGridView);
        }
        private void displayAcquaintances(DataGridView dgv)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT a.first_name, " +
                                                       $"a.last_name, " +
                                                       $"a.gender, " +
                                                       $"o.occupation, " +
                                                       $"c.city, a.address, " +
                                                       $"r.relationship " +
                                                $"FROM user_acquaintance_relationships uar " +
                                                $"JOIN acquaintances a " +
                                                    $"ON uar.acquaintance_id = a.id " +
                                                $"JOIN cities c " +
                                                    $"ON a.city_id = c.id " +
                                                $"JOIN occupations o " +
                                                    $"ON a.occupation_id = o.id " +
                                                $"JOIN relationships r " +
                                                    $"ON uar.relationship_id = r.id " +
                                                $"WHERE user_id = {user_id};", Connect.con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgv.DataSource = dt;
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
