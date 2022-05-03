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
        //public addAcquaintanceForm(int user_id)
        //{
        //    InitializeComponent();
        //    this.user_id = user_id;
        //    setDropDownValues(user_id, "occupations", occupationsDropDown, ref dto);
        //    setDropDownValues(user_id, "cities", citiesDropDown, ref dtc);
        //    setDropDownValues(user_id, "relationships", relationshipsDropDown, ref dtr);
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
        private void addAcquaintanceButton_Click(object sender, EventArgs e)
        {
            char gender = 'm';
            if (femaleRadioButton.Checked) gender = 'f';
            
            u.MySqlCommandImproved($"CALL sp_insertUserAcquaintance({user_id}, " +
                                                                  $"\'{firstNameTextBox.Text}\', " +
                                                                  $"\'{lastNameTextBox.Text}\', " +
                                                                  $"\'{gender}\', " +
                                                                  $"{getDropDownItemIndex(occupationsDropDown, dto)}, " +
                                                                  $"{getDropDownItemIndex(citiesDropDown, dtc)}, " +
                                                                  $"\'{addressTextBox.Text}\', " +
                                                                  $"{getDropDownItemIndex(relationshipsDropDown, dtr)})");
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            maleRadioButton.Checked = true;
            occupationsDropDown.SelectedIndex = 0;
            citiesDropDown.SelectedIndex = 0;
            addressTextBox.Text = "";
            relationshipsDropDown.SelectedIndex = 0;
        }
        private int getDropDownItemIndex(ComboBox cb, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cb.Text == dt.Rows[i][0].ToString())
                {
                    return (int)dt.Rows[i][1];
                }
            }
            return -1;
        }

        private void exitAcquaintnaceButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refreshDropdownIfChangesWereMade(string name)
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

