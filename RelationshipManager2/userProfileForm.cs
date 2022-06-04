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
    //TODO: PUT THE BUTTONS BELOW THE DGV AND MAKE IT LOOK LIKE ACQUAINTANCES
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
            displayMeetings(meetingsDataGridView);
        }

        public userProfileForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;

            displayMeetings(meetingsDataGridView);
        }

        private void displayMeetings(DataGridView dgv)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT DATE_FORMAT(um.date_time, '%m / %d / %Y') AS date, " +
                                                       $"DATE_FORMAT(um.date_time, '%H: %i') as time, " +
                                                       $"(SELECT CONCAT(a.first_name, \" \", a.last_name, \", \", c.city)) AS acquaintance, " +
                                                       $"l.location, " +
                                                       $"r.reason, " +
                                                       $"um.comments " +
                                                $"FROM user_meetings um " +
                                                $"JOIN acquaintances a " +
                                                    $"ON um.acquaintance_id = a.id " +
                                                        $"JOIN cities c " +
                                                        $"ON a.city_id = c.id " +
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
            DataGridViewRow row = meetingsDataGridView.Rows[e.RowIndex]; //TODO: System.ArgumentOutOfRangeException  make try catch 
            if (e.ColumnIndex == 0)
            {
                addMeetingForm edit = new addMeetingForm(this, user_id,
                                                         row.Cells[2].Value.ToString(),
                                                         row.Cells[3].Value.ToString(),
                                                         row.Cells[4].Value.ToString(),
                                                         row.Cells[5].Value.ToString(),
                                                         row.Cells[6].Value.ToString(),
                                                         row.Cells[7].Value.ToString());
                edit.Show();
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you wish to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DateTime date = DateTime.Parse($"{meetingsDataGridView[2, e.RowIndex].Value.ToString()} {meetingsDataGridView[3, e.RowIndex].Value.ToString()}");

                    u.MySqlCommandImproved($"DELETE FROM user_meetings WHERE user_id = {user_id} AND date_time = \'{date.ToString("yyyy-MM-dd HH:mm:ss")}\' AND acquaintance_id = (SELECT a.id FROM acquaintances a JOIN cities c ON a.city_id = c.id WHERE CONCAT(a.first_name, \" \", a.last_name, \", \", c.city) = \'{meetingsDataGridView[4, e.RowIndex].Value.ToString()}\')");
                    
                    refreshMeetingsDataGridView();
                }
            }
        }
        public void refreshMeetingsDataGridView()
        {
            displayMeetings(meetingsDataGridView);
            u.ColorRows(meetingsDataGridView);
        }
        private void addMeetingButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<addMeetingForm>().Count() == 1)
                Application.OpenForms.OfType<addMeetingForm>().First().Close();

            addMeetingForm add = new addMeetingForm(this, user_id);
            add.Show();
        }
    }
}

