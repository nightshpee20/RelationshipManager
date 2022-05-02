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
        private mainForm main;
        public List<string> user_info = new List<string>();
       

        public userProfileForm(mainForm main, int user_id)
        {
            InitializeComponent();
            this.main = main;
            this.user_id = user_id;
        }

        //TODO: TEMPORARY - REMOVE WHEN OBSCOLETE
        private List<string> UserInfo(int user_id)
        {
            Connect.con.Close();
            List<string> user_info = new List<string>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE id = @id;", Connect.con);
                cmd.Parameters.Add("@id", MySqlDbType.Int32);
                cmd.Parameters["@id"].Value = user_id;
            try
            {
                Connect.con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    user_info.Add(dr["id"].ToString());
                    user_info.Add(dr["username"].ToString());
                    user_info.Add(dr["password"].ToString());
                    user_info.Add(dr["email"].ToString());
                    user_info.Add(dr["mobile_number"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Connect.con.Close();
            return user_info;
        }
        //TODO: TEMPORARY - REMOVE WHEN OBSCOLETE
        public void showInfo()
        {
            foreach (var item in user_info)
            {
                MessageBox.Show(item);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }
        //TODO: TEMPORARY - REMOVE WHEN OBSCOLETE
        private void getUserInfoBUtton_Click(object sender, EventArgs e)
        {
            user_info = UserInfo(user_id);
            showInfo();
        }

        private void browseAcquaintancesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            acquaintancesForm acquaintances = new acquaintancesForm(this, user_id);
            //addAcquaintanceForm form = new addAcquaintanceForm(this, user_id);
            acquaintances.Show();
        }
    }
    }

