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
        private userProfileForm2 parent;
        private int user_id;
        public acquaintancesForm(userProfileForm2 parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
            displayData(acquaintancesDataGridView);
        }
        //REMOVE AFTER TESTING
        public acquaintancesForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            displayData(acquaintancesDataGridView);

            
        }
        private void displayData(DataGridView dgv)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT a.first_name, " +
                                                       $"a.last_name, " +
                                                       $"a.gender, " +
                                                       $"o.occupation, " +
                                                       $"c.city, " +
                                                       $"a.address, " +
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
                                                $"WHERE user_id = {user_id} " +
                                                $"ORDER BY first_name ASC, last_name ASC, city ASC;", Connect2.con);
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

        public void refreshAcquaintancesDataGridView()
        {
            displayData(acquaintancesDataGridView);
            u.ColorRows(acquaintancesDataGridView);
        }
        private void addAcquaintanceButton_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<addAcquaintanceForm>().Count() == 1) 
                Application.OpenForms.OfType<addAcquaintanceForm>().First().Close();

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

        private void acquaintancesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = acquaintancesDataGridView.Rows[e.RowIndex];
            if (e.ColumnIndex == 0)
            {
                
                addAcquaintanceForm edit = new addAcquaintanceForm(this, user_id, 
                                                                   row.Cells[2].Value.ToString(),
                                                                   row.Cells[3].Value.ToString(),
                                                                   row.Cells[4].Value.ToString(),
                                                                   row.Cells[5].Value.ToString(),
                                                                   row.Cells[6].Value.ToString(),
                                                                   row.Cells[7].Value.ToString(),
                                                                   row.Cells[8].Value.ToString());
                edit.Show();
            }else if(e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you wish to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int acq_id = -1;

                    MySqlCommand cmd = new MySqlCommand($"SELECT id FROM acquaintances WHERE first_name = \'{row.Cells[2].Value.ToString()}\' AND last_name = \'{row.Cells[3].Value.ToString()}\' AND city_id = (SELECT id FROM cities WHERE city = \'{row.Cells[6].Value.ToString()}\')", Connect2.con);

                    Connect2.con.Open();

                    var dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        dr.Read();
                        acq_id = dr.GetInt32(0);
                    }

                    Connect2.con.Close();

                    u.MySqlCommandImproved($"DELETE FROM user_acquaintance_relationships WHERE user_id = {user_id} AND acquaintance_id = {acq_id}");
                    refreshAcquaintancesDataGridView();
                }
            }
        }

        private void acquaintancesDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            u.ColorRows(acquaintancesDataGridView);   
        }

        
    }
}
