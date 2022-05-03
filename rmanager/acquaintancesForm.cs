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
        private ToolTip toolTip1 = new ToolTip();
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
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["first_name"] = u.CapitalizeFirstLetters(dt.Rows[i]["first_name"].ToString());
                dt.Rows[i]["last_name"] = u.CapitalizeFirstLetters(dt.Rows[i]["last_name"].ToString());

                if (dt.Rows[i]["gender"].ToString() == "m") dt.Rows[i]["gender"] = "Male";
                else dt.Rows[i]["gender"] = "Female";

                dt.Rows[i]["occupation"] = u.CapitalizeFirstLetters(dt.Rows[i]["occupation"].ToString());
                dt.Rows[i]["city"] = u.CapitalizeFirstLetters(dt.Rows[i]["city"].ToString());
                if(dt.Rows[i]["address"].ToString() != "") dt.Rows[i]["address"] = u.CapitalizeFirstLetters(dt.Rows[i]["address"].ToString());
                dt.Rows[i]["relationship"] = u.CapitalizeFirstLetters(dt.Rows[i]["relationship"].ToString());
            }

            dgv.DataSource = dt;

            

        }
        private void addAcquaintanceButton_Click(object sender, EventArgs e)
        {
            addAcquaintanceForm add = new addAcquaintanceForm(this, user_id);
            add.Show();
        }
        public void refreshAcquaintancesDataGridView()
        {
            displayAcquaintances(acquaintancesDataGridView);
        }
        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acquaintancesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void acquaintancesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                DataGridViewRow row = acquaintancesDataGridView.Rows[e.RowIndex];
                addAcquaintanceForm edit = new addAcquaintanceForm(this, user_id, 
                                                                   row.Cells[2].Value.ToString(),
                                                                   row.Cells[3].Value.ToString(),
                                                                   row.Cells[4].Value.ToString(),
                                                                   row.Cells[5].Value.ToString(),
                                                                   row.Cells[6].Value.ToString(),
                                                                   row.Cells[7].Value.ToString(),
                                                                   row.Cells[8].Value.ToString());
                edit.Show();

                //u.M((this, user_id, )
                //u.M     (row.Cells[2].Value.ToString());
                //   u.M  (row.Cells[3].Value.ToString());
                //    u.M (row.Cells[4].Value.ToString());
                //    u.M (row.Cells[5].Value.ToString());
                //    u.M (row.Cells[6].Value.ToString());
                //    u.M (row.Cells[7].Value.ToString());
                //u.M(row.Cells[8].Value.ToString());


            }else if(e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you wish to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    acquaintancesDataGridView.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void acquaintancesDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < acquaintancesDataGridView.Rows.Count; i += 2)
            {
                acquaintancesDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }
}
