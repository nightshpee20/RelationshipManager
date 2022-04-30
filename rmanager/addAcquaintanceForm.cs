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
        private DataTable dat;
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
            
            //Experimental
            dat = dt;

            for (int i = 0; i < ds.Tables[name].Rows.Count; i++)
            {
                dt.Rows[i][attribute] = u.CapitalizeFirstLetters(dt.Rows[i][attribute].ToString());
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
        public void refreshDropdownIfChangesWereMade(string name)
        {
            switch(name)
            {
                case "cities":
                    setDropDownValues(user_id, name, citiesDropDown);
                    break;
                case "occupations":
                    setDropDownValues(user_id, name, occupationsDropDown);
                    break;
                case "relationships":
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

        private void addAcquaintanceForm_Load(object sender, EventArgs e)
        {
            this.occupationsDropDown.DrawMode = DrawMode.OwnerDrawFixed;
            this.occupationsDropDown.ItemHeight = 40;
            

        }

        private void occupationsDropDown_DrawItem(object sender, DrawItemEventArgs e)
        {
            //USE INDEX TO CYCLE THROUGH THE DATATABLE, MAYBE THE setDropDownValue method can be made obscolete
            //if (e.Index > -1)
            //{
            //    var name = ((Product)this.comboBox1.Items[e.Index]).Name;
            //    var id = ((Product)this.comboBox1.Items[e.Index]).Id; ;
            //    var price = ((Product)this.comboBox1.Items[e.Index]).Price; ;
            //

                if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            else if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, e.Bounds);
            else
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

            e.Graphics.DrawString("what",
            new Font(this.occupationsDropDown.Font, FontStyle.Regular),
            Brushes.Blue,
            new Rectangle(e.Bounds.Left, e.Bounds.Top,
                e.Bounds.Width, this.occupationsDropDown.ItemHeight));

            e.Graphics.DrawString("bruh",
            this.occupationsDropDown.Font,
            Brushes.Red,
            new Rectangle(e.Bounds.Left, e.Bounds.Top + this.occupationsDropDown.ItemHeight / 2,
                e.Bounds.Width / 2, this.occupationsDropDown.ItemHeight));

           
            e.Graphics.DrawString("hi",
                this.occupationsDropDown.Font,
                Brushes.Red,
                new Rectangle(e.Bounds.Left + e.Bounds.Width / 2,
                    e.Bounds.Top + this.occupationsDropDown.ItemHeight / 2,
                    e.Bounds.Width, this.occupationsDropDown.ItemHeight));
        }
    }
}

