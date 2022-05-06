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
using System.Data.SqlClient;

namespace rmanager
{
    public partial class userProfileForm : Form
    {
        private int user_id;
        private mainForm parent;
        public List<string> user_info = new List<string>();
       

        public userProfileForm(mainForm parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
        }

        public userProfileForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;

            displayMeetings(meetingsDataGridView);
        }

        private void displayMeetings(DataGridView dgv)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT DATE_FORMAT(um.date_time, '%d / %m / %Y') AS date, " +
                                                       $"CONCAT(a.first_name, \" \", a.last_name) AS acquaintance, " +
                                                       $"l.location, " +
                                                       $"r.reason, " +
                                                       $"um.comments " +
                                                $"FROM user_meetings um " +
                                                $"JOIN acquaintances a " +
                                                    $"ON um.acquaintance_id = a.id " +
                                                $"JOIN locations l " +
                                                    $"ON um.location_id = l.id " +
                                                $"JOIN reasons r " +
                                                    $"ON um.reason_id = r.id " +
                                                $"WHERE user_id = {user_id} " +
                                                $"ORDER BY date_time DESC, acquaintance ASC, location ASC;", Connect.con);

            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["acquaintance"] = u.CapitalizeFirstLetters(dt.Rows[i]["acquaintance"].ToString());
                dt.Rows[i]["location"] = u.CapitalizeFirstLetters(dt.Rows[i]["location"].ToString());
                dt.Rows[i]["reason"] = u.CapitalizeFirstLetters(dt.Rows[i]["reason"].ToString());

                if (dt.Rows[i]["comments"].ToString() != "") dt.Rows[i]["comments"] = char.ToUpper(dt.Rows[i]["comments"].ToString()[0]) + dt.Rows[i]["comments"].ToString().Substring(1);
            }

            dgv.DataSource = dt;
        }
        
        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void browseAcquaintancesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            acquaintancesForm acquaintances = new acquaintancesForm(this, user_id);
            acquaintances.Show();
        }

        private void meetingsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            u.ColorRows(meetingsDataGridView);
        }

        private void meetingsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = acquaintancesDataGridView.Rows[e.RowIndex];
            //if (e.ColumnIndex == 0)
            //{
            //
            //    addAcquaintanceForm edit = new addAcquaintanceForm(this, user_id,
            //                                                       row.Cells[2].Value.ToString(),
            //                                                       row.Cells[3].Value.ToString(),
            //                                                       row.Cells[4].Value.ToString(),
            //                                                       row.Cells[5].Value.ToString(),
            //                                                       row.Cells[6].Value.ToString(),
            //                                                       row.Cells[7].Value.ToString(),
            //                                                       row.Cells[8].Value.ToString());
            //    edit.Show();
            //}
            //else if (e.ColumnIndex == 1)
            //{
            //    if (MessageBox.Show("Are you sure you wish to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        int acq_id = -1;
            //
            //        MySqlCommand cmd = new MySqlCommand($"SELECT id FROM acquaintances WHERE first_name = \'{row.Cells[2].Value.ToString()}\' AND last_name = \'{row.Cells[3].Value.ToString()}\' AND city_id = (SELECT id FROM cities WHERE city = \'{row.Cells[6].Value.ToString()}\')", Connect.con);
            //
            //        Connect.con.Open();
            //
            //        var dr = cmd.ExecuteReader();
            //        if (dr.HasRows)
            //        {
            //            dr.Read();
            //            acq_id = dr.GetInt32(0);
            //        }
            //
            //        Connect.con.Close();
            //
            //        //u.M(acq_id.ToString());
            //
            //        u.MySqlCommandImproved($"DELETE FROM user_acquaintance_relationships WHERE user_id = {user_id} AND acquaintance_id = {acq_id}");
            //        refreshAcquaintancesDataGridView();
            //    }
            //}
        }

        private void addMeetingButton_Click(object sender, EventArgs e)
        {
            addMeetingForm add = new addMeetingForm(this, user_id);
            add.Show();
        }
    }
    }

