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
        private userProfileForm user;
        private int user_id;
        public addAcquaintanceForm(userProfileForm user, int user_id)
        {
            InitializeComponent();
            this.user = user;
            this.user_id = user_id;
            setDropDownValues(user_id, "occupations", occupationsDropDown);
            setDropDownValues(user_id, "cities", citiesDropDown);
            setDropDownValues(user_id, "relationships", relationshipsDropDown);
        }
        // REMOVE AFTER DONE WITH TESTING!!
        public addAcquaintanceForm(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            setDropDownValues(user_id, "occupations", occupationsDropDown);
            setDropDownValues(user_id, "cities", citiesDropDown);
            setDropDownValues(user_id, "relationships", relationshipsDropDown);
        }
       
        private void setDropDownValues(int user_id, string name, ComboBox cb)
        {
            string attribute = "";
            switch(name)
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
            DataTable dt = new DataTable();

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
            
                //u.M(maxLength.ToString());
                occupationsDropDown.Width = maxLength * 12 + 24;
                occupationsDropDownEditButton.Left = maxLength * 12 + 48;
            }

            for (int i = 0; i < cb.Items.Count; i++)
            {
                u.M(cb.ValueMember[i].ToString());
            }
        }
        private void addAcquaintanceButton_Click(object sender, EventArgs e)
        {
            char gender;
            if (maleRadioButton.Checked) gender = 'm';
            else gender = 'f';
            MySqlCommand cmd = new MySqlCommand($"CALL sp_insertAcquaintance({user_id}, " +
                                                                           $"{firstNameTextBox.Text}, " +
                                                                           $"{lastNameTextBox.Text}, " +
                                                                           $"{gender}, " +
                                                                           $"{occupationsDropDown.SelectedIndex + 1}, " +
                                                                           $"{addressTextBox.Text}, " +
                                                                           $"{citiesDropDown.SelectedIndex + 1}, " +
                                                                           $"{relationshipsDropDown.SelectedIndex + 1}", Connect.con);

            MessageBox.Show($"CALL sp_insertAcquaintance({user_id}, " +
                                                       $"{firstNameTextBox.Text}, " +
                                                       $"{lastNameTextBox.Text}, " +
                                                       $"{gender}, " +
                                                       $"{occupationsDropDown.SelectedIndex + 1}, " +
                                                       $"{addressTextBox.Text}, " +
                                                       $"{citiesDropDown.SelectedIndex + 1}, " +
                                                       $"{relationshipsDropDown.SelectedIndex + 1}");

            //this.Close();
            //user.Show();

            
        }
        public void refreshDropdownIfChangesWereMade(string name)
        {
            switch(name)
            {
                case "cities":
                    citiesDropDown.Items.Clear();
                    setDropDownValues(user_id, name, citiesDropDown);
                    break;
                case "occupations":
                    occupationsDropDown.Items.Clear();
                    setDropDownValues(user_id, name, occupationsDropDown);
                    break;
                case "relationships":
                    relationshipsDropDown.Items.Clear();
                    setDropDownValues(user_id, name, relationshipsDropDown);
                    MessageBox.Show("bruh");
                    break;
            }
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
       
           editForm edit = new editForm(name, user_id, this);
           edit.Show();
       }
    }
}

