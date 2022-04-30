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

            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT * FROM {name} ORDER BY id ASC;", Connect.con);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, name);
            dt = ds.Tables[name];

            for (int i = 0; i < ds.Tables[name].Rows.Count; i++)
            {
                dt.Rows[i][attribute] = Utilities.CapitalizeFirstLetters(dt.Rows[i][attribute].ToString());
            }

            
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb.DisplayMember = attribute;
                cb.ValueMember = "id";
                cb.DataSource = dt;
                cb.SelectedIndex = i;
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
        public void refreshDropdownIfChangesWereMade(bool val, string name, ComboBox dropdown)
        {
            if (val == true) setDropDownValues(user_id, name, dropdown);
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

