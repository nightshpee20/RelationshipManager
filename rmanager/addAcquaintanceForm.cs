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
    public partial class addAcquaintanceForm : Form
    {
        private acquaintancesForm parent;
        private int user_id;
        private DataTable dtc, dto, dtr;
        private string attribute = "";
        private List<string> oldValues;
        private int oldCityIndex;
        private List<string> newValues;
        public addAcquaintanceForm(acquaintancesForm parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
            setDropDownValues(user_id, "occupations", occupationsDropDown, ref dto);
            setDropDownValues(user_id, "cities", citiesDropDown, ref dtc);
            setDropDownValues(user_id, "relationships", relationshipsDropDown, ref dtr);
            maleRadioButton.Checked = true;
        }
        // REMOVE AFTER DONE WITH TESTING!!
        public addAcquaintanceForm(acquaintancesForm parent, int user_id, string first, string last, string gender, string occ, string city, string address, string rel)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;
            this.Text = "Edit Acquaintance";
            addAcquaintanceButton.Text = "Commit";

            setOldValues(first, last, gender, occ, city, address, rel);
        }
        public addAcquaintanceForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            setDropDownValues(user_id, "occupations", occupationsDropDown, ref dto);
            setDropDownValues(user_id, "cities", citiesDropDown, ref dtc);
            setDropDownValues(user_id, "relationships", relationshipsDropDown, ref dtr);
            maleRadioButton.Checked = true;
        }
        //public addAcquaintanceForm(int user_id, string name_city) ////////IF THE APP WORKS DELETE THIS
        //{
        //    InitializeComponent();
        //    
        //}

        private void setDropDownValues(int user_id, string name, ComboBox cb, ref DataTable dt)
        {
            cb.DataSource = null;
            

            switch (name)
            {
                case "cities":
                    attribute = "city";
                    break;
                case "occupations":
                    attribute = "occupation";
                    break;
                case "relationships":
                    attribute = "relationship";
                    break;
            }

            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT n.{attribute}, n.id, un.user_id " +
                                                       $"FROM user_{name} un " +
                                                       $"JOIN {name} n ON un.{attribute}_id = n.id " +
                                                       $"WHERE user_id = {user_id} " +
                                                       $"ORDER BY n.{attribute} ASC;", Connect.con);
            
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

            if (name == "occupations")
            {
                int maxLength = 0;
            
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][attribute].ToString().Length > maxLength) maxLength = dt.Rows[i][attribute].ToString().Length;
                }
 
                occupationsDropDown.Width = maxLength * 12;
                occupationsDropDownEditButton.Left = maxLength * 12 + 24;
            }
        }
        private void setOldValues(string first, string last, string gender, string occ, string city, string address, string rel)
        {
            this.oldValues = new List<string>();

            firstNameTextBox.Text = first;
            oldValues.Add(first);

            lastNameTextBox.Text = last;
            oldValues.Add(last);

            if (gender == "Female") { femaleRadioButton.Checked = true; oldValues.Add(gender); }
            if (gender == "Male") { maleRadioButton.Checked = true; oldValues.Add(gender); }

            setDropDownValues(user_id, "occupations", occupationsDropDown, ref dto);
            for (int i = 0; i < dto.Rows.Count; i++)
            {
                if (occ == dto.Rows[i][0].ToString()) { occupationsDropDown.SelectedIndex = i; oldValues.Add(dto.Rows[i][0].ToString()); }
            }

            setDropDownValues(user_id, "cities", citiesDropDown, ref dtc);
            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                if (city == u.CapitalizeFirstLetters(dtc.Rows[i][0].ToString())) { citiesDropDown.SelectedIndex = i; oldValues.Add(dtc.Rows[i][0].ToString()); }
            }
            this.oldCityIndex = citiesDropDown.SelectedIndex;

            addressTextBox.Text = address;
            oldValues.Add(address);

            setDropDownValues(user_id, "relationships", relationshipsDropDown, ref dtr);
            for (int i = 0; i < dtr.Rows.Count; i++)
            {
                if (rel == dtr.Rows[i][0].ToString()) { relationshipsDropDown.SelectedIndex = i; oldValues.Add(dtr.Rows[i][0].ToString()); }
            }
        }
        public void refreshDropdown(string name)
        {
            switch(name)
            {
                case "cities":
                    setDropDownValues(user_id, name, citiesDropDown, ref dtc);
                    break;

                case "occupations":
                    setDropDownValues(user_id, name, occupationsDropDown, ref  dto);
                    break;

                case "relationships":
                    setDropDownValues(user_id, name, relationshipsDropDown, ref dtr);
                    break;
            }
        }
        //Events
        private void addAcquaintanceButton_Click(object sender, EventArgs e)
        {
            if (addAcquaintanceButton.Text == "Add")
            {
                char gender = 'm';
                if (femaleRadioButton.Checked) gender = 'f';
                if (firstNameTextBox.Text == "")
                {
                    u.M("First Name is a mandatory field!");
                    return;
                }
                if (lastNameTextBox.Text == "")
                {
                    u.M("Last Name is a mandatory field!");
                    return;
                }

                u.MySqlCommandImproved($"CALL sp_insertUserAcquaintance({user_id}, " +
                                                                    $"\'{firstNameTextBox.Text}\', " +
                                                                    $"\'{lastNameTextBox.Text}\', " +
                                                                    $"\'{gender}\', " +
                                                                      $"{u.GetDropDownItemIndex(occupationsDropDown, dto)}, " +
                                                                      $"{u.GetDropDownItemIndex(citiesDropDown, dtc)}, " +
                                                                    $"\'{addressTextBox.Text}\', " +
                                                                      $"{u.GetDropDownItemIndex(relationshipsDropDown, dtr)})");
                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                maleRadioButton.Checked = true;
                occupationsDropDown.SelectedIndex = 0;
                citiesDropDown.SelectedIndex = 0;
                addressTextBox.Text = "";
                relationshipsDropDown.SelectedIndex = 0;

            }
            else if (addAcquaintanceButton.Text == "Commit")
            {
                this.newValues = new List<string>();

                newValues.Add(firstNameTextBox.Text);
                newValues.Add(lastNameTextBox.Text);
                if (maleRadioButton.Checked == true) newValues.Add("Male");
                if (femaleRadioButton.Checked == true) newValues.Add("Female");
                newValues.Add(occupationsDropDown.GetItemText(occupationsDropDown.SelectedItem));
                newValues.Add(citiesDropDown.GetItemText(citiesDropDown.SelectedItem));
                newValues.Add(addressTextBox.Text);
                newValues.Add(relationshipsDropDown.GetItemText(relationshipsDropDown.SelectedItem));

                for (int i = 0; i < oldValues.Count; i++)
                {
                    if (oldValues[i] != newValues[i])
                    {
                        char gender;
                        if (newValues[2] == "Male") gender = 'm'; else gender = 'f';
                        u.MySqlCommandImproved($"CALL sp_insertUserAcquaintance({user_id}, " +
                                                                            $"\'{firstNameTextBox.Text}\', " +
                                                                            $"\'{lastNameTextBox.Text}\', " +
                                                                            $"\'{gender}\', " +
                                                                              $"{u.GetDropDownItemIndex(occupationsDropDown, dto)}, " +
                                                                              $"{u.GetDropDownItemIndex(citiesDropDown, dtc)}, " +
                                                                            $"\'{addressTextBox.Text}\', " +
                                                                              $"{u.GetDropDownItemIndex(relationshipsDropDown, dtr)})");



                        int acq_id = -1;

                        MySqlCommand cmd = new MySqlCommand($"SELECT id FROM acquaintances WHERE first_name = \'{oldValues[0]}\' AND last_name = \'{oldValues[1]}\' AND city_id = (SELECT id FROM cities WHERE city = \'{citiesDropDown.GetItemText(citiesDropDown.SelectedItem)}\')", Connect.con);

                        Connect.con.Open();

                        var dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            acq_id = dr.GetInt32(0);
                        }

                        Connect.con.Close();

                        u.MySqlCommandImproved($"DELETE FROM user_acquaintance_relationships WHERE user_id = {user_id} AND acquaintance_id = {acq_id}");

                        break;
                    }
                }

                string gen = "";
                if (maleRadioButton.Checked == true) gen = "Male";
                if (femaleRadioButton.Checked == true) gen = "Female";
                setOldValues(firstNameTextBox.Text, lastNameTextBox.Text, gen, occupationsDropDown.GetItemText(occupationsDropDown.SelectedItem), citiesDropDown.GetItemText(citiesDropDown.SelectedItem), addressTextBox.Text, relationshipsDropDown.GetItemText(relationshipsDropDown.SelectedItem));
            }

            if(parent != null) parent.refreshAcquaintancesDataGridView();
        }
        private void exitAcquaintnaceButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dropDownEditButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = "";
            switch (btn.Name)
            {
                case "citiesDropDownEditButton":
                    name = "cities";
                    break;
                case "occupationsDropDownEditButton":
                    name = "occupations";
                    break;
                case "relationshipsDropDownEditButton":
                    name = "relationships";
                    break;
            }

            if (Application.OpenForms.OfType<editForm>().Count() == 1)
                Application.OpenForms.OfType<editForm>().First().Close();

            editForm edit = new editForm(name, user_id, this, parent);
            edit.Show();
        }
    }
}

