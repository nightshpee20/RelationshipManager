using MySql.Data.MySqlClient;
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
        private DataTable dta, dtl, dtr;
        private string attribute;
        private List<string> oldValues;
        public addMeetingForm(userProfileForm parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;

            addMeetingHour.SelectedIndex = 12;
            addMeetingMinute.SelectedIndex = 29;

            setDropDownValues(user_id, "acquaintances", acquaintancesDropDown, ref dta);
            setDropDownValues(user_id, "locations", locationsDropDown, ref dtl);
            setDropDownValues(user_id, "reasons", reasonsDropDown, ref dtr);

        }

        public addMeetingForm(userProfileForm parent, int user_id, string date, string acquaintance, string location, string reason, string comments)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
            this.Text = "Edit Meeting";
            mainLabel.Text = "Edit Meeting:";
            addButton.Text = "Commit";

            setOldValues(date, acquaintance, location, reason, comments);
        }

        private void setDropDownValues(int user_id, string name, ComboBox cb, ref DataTable dt)
        {
            cb.DataSource = null;

            switch (name)
            {
                case "acquaintances":
                    attribute = "acquaintance";
                    break;
                case "locations":
                    attribute = "location";
                    break;
                case "reasons":
                    attribute = "reason";
                    break;
            }

            MySqlDataAdapter da = new MySqlDataAdapter();
            if (name == "acquaintances")
            {
                da = new MySqlDataAdapter($"SELECT" +
                                               $"(SELECT CONCAT(first_name, \" \", last_name, \", \", (SELECT city FROM cities c WHERE c.id = a.city_id)) " +
                                               $"FROM acquaintances a WHERE a.id = ua.acquaintance_id) AS acquaintance " +
                                          $"FROM user_acquaintance_relationships ua " +
                                          $"WHERE user_id = 1", Connect.con);
            }
            else
            {
                da = new MySqlDataAdapter($"SELECT n.{attribute}, n.id, un.user_id " +
                                          $"FROM user_{name} un " +
                                          $"JOIN {name} n ON un.{attribute}_id = n.id " +
                                          $"WHERE user_id = {user_id} " +
                                          $"ORDER BY n.{attribute} ASC;", Connect.con);
            }
            
            
            DataSet ds = new DataSet();
            dt = new DataTable();
            
            da.Fill(ds, name);
            dt = ds.Tables[name];
            
            
            for (int i = 0; i < ds.Tables[name].Rows.Count; i++)
            {
                dt.Rows[i][attribute] = u.CapitalizeFirstLetters(dt.Rows[i][attribute].ToString());
            }
            
            cb.DisplayMember = attribute;
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(addButton.Text == "Add")
            {
          
                u.M($"{addMeetingDate.SelectionStart.ToString("yyyy-MM-dd")}");


                //u.MySqlCommandImproved($"CALL sp_insertUserMeeting({user_id}, {})");
            }else if (addButton.Text == "Commit")
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT a.id FROM acquaintances a JOIN cities c ON a.city_id = c.id WHERE CONCAT(a.first_name, \' \', a.last_name, \', \', c.city) = \'{oldValues[1]}\'", Connect.con);

                Connect.con.Open();

                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();

                    u.M(dr.GetInt32(0).ToString());
                }

                Connect.con.Close();
            }

            parent.refreshMeetingsDataGridView();
        }

        public void setOldValues(string date, string acquaintance, string location, string reason, string comments)
        {
            this.oldValues = new List<string>();
            addButton.Text = "Commit";

            commentsTextBox.Text = comments;
            oldValues.Add(comments);
 
            setDropDownValues(user_id, "acquaintances", acquaintancesDropDown, ref dta);
            for (int i = 0; i < dta.Rows.Count; i++)
            {
                if (acquaintance == dta.Rows[i][0].ToString()) { acquaintancesDropDown.SelectedIndex = i; oldValues.Add(dta.Rows[i][0].ToString()); }
            }

            setDropDownValues(user_id, "locations", locationsDropDown, ref dtl);
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                if (location == u.CapitalizeFirstLetters(dtl.Rows[i][0].ToString())) { locationsDropDown.SelectedIndex = i; oldValues.Add(dtl.Rows[i][0].ToString()); }
            }

            setDropDownValues(user_id, "reasons", reasonsDropDown, ref dtr);
            for (int i = 0; i < dtr.Rows.Count; i++)
            {
                if (reason == dtr.Rows[i][0].ToString()) { reasonsDropDown.SelectedIndex = i; oldValues.Add(dtr.Rows[i][0].ToString()); }
            }

            DateTime datetime = DateTime.Parse(date);
            oldValues.Add(date);

            addMeetingDate.SetDate(datetime);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

