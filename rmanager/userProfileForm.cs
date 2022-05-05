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
        //TODO: TEMPORARY - REMOVE WHEN OBSCOLETE
        //private List<string> UserInfo(int user_id)
        //{
        //    Connect.con.Close();
        //    List<string> user_info = new List<string>();
        //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE id = @id;", Connect.con);
        //        cmd.Parameters.Add("@id", MySqlDbType.Int32);
        //        cmd.Parameters["@id"].Value = user_id;
        //    try
        //    {
        //        Connect.con.Open();
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        while(dr.Read())
        //        {
        //            user_info.Add(dr["id"].ToString());
        //            user_info.Add(dr["username"].ToString());
        //            user_info.Add(dr["password"].ToString());
        //            user_info.Add(dr["email"].ToString());
        //            user_info.Add(dr["mobile_number"].ToString());
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    Connect.con.Close();
        //    return user_info;
        //}
        //TODO: TEMPORARY - REMOVE WHEN OBSCOLETE
        //public void showInfo()
        //{
        //    foreach (var item in user_info)
        //    {
        //        MessageBox.Show(item);
        //    }
        //}

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
        //TODO: TEMPORARY - REMOVE WHEN OBSCOLETE
        private void getUserInfoBUtton_Click(object sender, EventArgs e)
        {
            //user_info = UserInfo(user_id);
            //showInfo();
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
    }
    }

