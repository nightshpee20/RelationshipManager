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

        public addMeetingForm(userProfileForm parent, int user_id, string date, string time, string acquaintance, string location, string reason, string comments)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
            this.Text = "Edit Meeting";
            mainLabel.Text = "Edit Meeting:";
            resetValues.Text = "Reset Old Values";
            addButton.Text = "Commit";

            setOldValues(date, time, acquaintance, location, reason, comments);
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
                                               $"FROM acquaintances a WHERE a.id = ua.acquaintance_id) AS acquaintance, ua.acquaintance_id " +
                                          $"FROM user_acquaintance_relationships ua " +
                                          $"WHERE user_id = 1 " +
                                          $"ORDER BY acquaintance ASC", Connect.con);
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
            //TODO: Finish add and commit functionalities.
            if(addButton.Text == "Add")
            {
          
                u.M($"CALL sp_insertUserMeeting({user_id}, {u.GetDropDownItemIndex(acquaintancesDropDown, dta)}, \'{addMeetingDate.SelectionStart.ToString("yyyy-MM-dd")} {addMeetingHour.SelectedIndex}:{addMeetingMinute.SelectedIndex + 1}\', {u.GetDropDownItemIndex(locationsDropDown, dtl)}, {u.GetDropDownItemIndex(reasonsDropDown, dtr)}, \'{commentsTextBox.Text}\')");

                u.MySqlCommandImproved($"CALL sp_insertUserMeeting({user_id}, {u.GetDropDownItemIndex(acquaintancesDropDown, dta)}, \'{addMeetingDate.SelectionStart.ToString("yyyy-MM-dd")} {addMeetingHour.SelectedIndex}:{addMeetingMinute.SelectedIndex + 1}\', {u.GetDropDownItemIndex(reasonsDropDown, dtr)}, {u.GetDropDownItemIndex(locationsDropDown, dtl)}, \'{commentsTextBox.Text}\')");



            }
            else if (addButton.Text == "Commit")
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

       

        public void setOldValues(string date, string time, string acquaintance, string location, string reason, string comments)
        {
            this.oldValues = new List<string>();
            addButton.Text = "Commit";

            DateTime datetime = DateTime.Parse(date);
            oldValues.Add(date);

            addMeetingDate.SetDate(datetime);

            addMeetingHour.SelectedIndex = int.Parse(time.Substring(0, 2));
            addMeetingMinute.SelectedIndex = int.Parse(time.Substring(4, 2)) - 1;
            oldValues.Add(time);

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

            commentsTextBox.Text = comments;
            oldValues.Add(comments);
        }

        //TODO: MAKE THIS WORK
        private void dropDownEditButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = "";
            switch (btn.Name)
            {
                case "acquaintancesDropDownEditButton":
                    name = "acquaintances";
                    break;
                case "locationsDropDownEditButton":
                    name = "locations";
                    break;
                case "reasonsDropDownEditButton":
                    name = "reasons";
                    break;
            }

            if (Application.OpenForms.OfType<editForm>().Count() == 1)
                Application.OpenForms.OfType<editForm>().First().Close();

            editForm edit = new editForm(name, user_id, this, parent);
            edit.Show();
        }

        private void resetValues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(resetValues.Text == "Reset Values")
            {
                addMeetingDate.SelectionStart = DateTime.Now;
                addMeetingHour.SelectedIndex = 12;
                addMeetingMinute.SelectedIndex = 29;
                acquaintancesDropDown.SelectedIndex = 0;
                locationsDropDown.SelectedIndex = 0;
                reasonsDropDown.SelectedIndex = 0;
                commentsTextBox.Text = "";
            }
            else if(resetValues.Text == "Reset Old Values")
            {
                setOldValues(oldValues[0], oldValues[1], oldValues[2], oldValues[3], oldValues[4], oldValues[5]);
            }
        }
        //EXPERIMENTAL
        public void refreshDropdown(string name)
        {
            switch (name)
            {
                //case "acquaintances":
                //    setDropDownValues(user_id, name, acquaintancesDropDown, ref dta);
                //    break;
                //
                case "locations":
                    setDropDownValues(user_id, name, locationsDropDown, ref dtl);
                    break;

                case "reasons":
                    setDropDownValues(user_id, name, reasonsDropDown, ref dtr);
                    break;
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

