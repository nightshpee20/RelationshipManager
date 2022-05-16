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
    public partial class editForm : Form
    {
        private int user_id;
        private string name;
        private string column;
        private string oldText;
        private bool changesMade = false;
        private acquaintancesForm grandparent;
        private addAcquaintanceForm parent; 
        private userProfileForm gparent; //EXPERIMENTAL
        private addMeetingForm pparent; //EXPERIMENTAL
        private int max_width;
        private DataTable dt;
        
        public editForm(string name, int user_id, addAcquaintanceForm parent, acquaintancesForm grandparent)
        {
            InitializeComponent();
            this.parent = parent;
            this.grandparent = grandparent;
            this.Text = u.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            this.name = name;
            switch(name)
            {
                case "cities":
                    label1.Text = "Your CITIES:";
                    this.column = "city";
                    break;
                case "occupations":
                    label1.Text = "Your OCCUPATIONS:";
                    this.column = "occupation";
                    break;
                case "relationships":
                    label1.Text = "Your RELATIONSHIPS:";
                    this.column = "relationship";
                    break;
            }
            displayTable(name);
        }
        //                                                                         || || || ||
        //EXPERIMENTAL constructor THIS CONSTRUCTOR CAN BE MERGED WITH THE TOP ONE \/ \/ \/ \/
        public editForm(string name, int user_id, addMeetingForm parent, userProfileForm grandparent)
        {
            InitializeComponent();
            this.pparent = parent;
            this.gparent = grandparent;
            this.Text = u.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            this.name = name;
            switch (name)
            {
                case "acquaintances":
                    label1.Text = "Your \nACQUAINTANCES:";
                    label1.Top += 5;
                    label1.Left += 15;
                    this.column = "acquaintance";
                    break;
                case "locations":
                    label1.Text = "Your LOCATIONS:";
                    this.column = "location";
                    getDropDownValues(user_id, ref dt);
                    break;
                case "reasons":
                    label1.Text = "Your REASONS:";
                    this.column = "reason";
                    break;
            }
            displayTable(name);
        }

        private void displayTable(string name)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            switch(name)
            {
                case "cities":
                    da = new MySqlDataAdapter($"SELECT c.city, c.id, uc.user_id " +
                                              $"FROM user_cities uc " +
                                              $"JOIN cities c ON uc.city_id = c.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY c.city ASC;", Connect.con);
                    break;

                case "occupations":
                    da = new MySqlDataAdapter($"SELECT o.occupation, o.id, uo.user_id " +
                                              $"FROM user_occupations uo " +
                                              $"JOIN occupations o ON uo.occupation_id = o.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY o.occupation ASC;", Connect.con);
                    break;

                case "relationships":
                    da = new MySqlDataAdapter($"SELECT r.relationship, r.id, ur.user_id " +
                                             $"FROM user_relationships ur " +
                                             $"JOIN relationships r ON ur.relationship_id = r.id " +
                                             $"WHERE user_id = {user_id} " +
                                             $"ORDER BY r.relationship ASC;", Connect.con);
                    break;

                //EXPERIMENTAL case
                case "acquaintances":
                    da = new MySqlDataAdapter($"SELECT (SELECT CONCAT(first_name, \" \", last_name, \", \", (SELECT city FROM cities c WHERE c.id = a.city_id)) FROM acquaintances a WHERE a.id = ua.acquaintance_id) AS acquaintance, ua.acquaintance_id AS id, ua.user_id " +
                                              $"FROM user_acquaintance_relationships ua " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY acquaintance ASC;", Connect.con);
                    break;

                //EXPERIMENTAL case
                case "locations":
                    da = new MySqlDataAdapter($"SELECT l.location, l.id, ul.user_id " +
                                              $"FROM user_locations ul " +
                                              $"JOIN locations l ON ul.location_id = l.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY l.location ASC;", Connect.con);
                    break;

                //EXPERIMENTAL case
                case "reasons":
                    da = new MySqlDataAdapter($"SELECT r.reason, r.id, ur.user_id " +
                                              $"FROM user_reasons ur " +
                                              $"JOIN reasons r ON ur.reason_id = r.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY r.reason ASC;", Connect.con);
                    break;
            }
            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
       
            da.Fill(ds, name);
            dt = ds.Tables[name];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (max_width <= dt.Rows[i][0].ToString().Length) max_width = dt.Rows[i][0].ToString().Length;
            }

            if (name != "locations") this.Width = 40 + max_width * 9 + 160;
            else this.Width = 40 + max_width * 18 + 171;

            addRow(0, "", 1);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                addRow(int.Parse(dt.Rows[i]["id"].ToString()), dt.Rows[i][0].ToString(), i + 2);
            }
            
            
            if (dt.Rows.Count > 12)
            {
                this.Height = 119 + 12 * 40;
                this.VerticalScroll.Visible = false;
                this.AutoScroll = true;
            }
            else
            {
                this.Height = 119 + (dt.Rows.Count) * 40;
            }
        }
        public static int GetDropDownItemIndex(ComboBox cb, DataTable dt)
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
        private void getDropDownValues(int user_id, ref DataTable dt)
        {
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT l.id, l.location, c.id, c.city " +
                                                       $"FROM user_locations ul " +
                                                       $"JOIN locations l ON ul.location_id = l.id " +
                                                       $"JOIN cities c ON l.city_id = c.id " +
                                                       $"WHERE user_id = {user_id} " +
                                                       $"ORDER BY c.city ASC;", Connect.con);

            DataSet ds = new DataSet();
            dt = new DataTable();

            da.Fill(ds, name);
            dt = ds.Tables[name];


            for (int i = 0; i < ds.Tables[name].Rows.Count; i++)
            {
                dt.Rows[i]["city"] = u.CapitalizeFirstLetters(dt.Rows[i]["city"].ToString());
            }
        }
        private void setDropDownValues(ComboBox cb)
        {
            cb.DisplayMember = "city";
            cb.ValueMember = "id";
            cb.DataSource = dt;
        }
        private TextBox addTextBox(int id, string txtValue, int count)
        {
            TextBox txt = new TextBox();
           
            txt.Name = "txt" + count;
            if(txtValue != "") txt.ReadOnly = true;
            txt.TabIndex = id;

            if(txtValue != "") txt.Text = u.CapitalizeFirstLetters(txtValue);
            txt.Font = new Font(txt.Font.FontFamily, 12);
            txt.TextAlign = HorizontalAlignment.Center;

            txt.Top = 3;
            txt.Width = max_width * 9;

            return txt;
        }
        private Button addButton(int count, string type)
        {
            Button btn = new Button();
            btn.Height = 32;
            btn.Width = 80;
            btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size, FontStyle.Bold);

            switch (type)
            {
                case "edit":
                    btn.Text = "Edit";
                    btn.Name = "editButton" + count; //DELETED '_' at the end
                    btn.TabIndex = count;
                    break;

                case "edit_cities":
                    btn.Text = "Edit Cities";
                    btn.Name = "editCitiesButton";
                    break;

                case "delete":
                    btn.Text = "Delete";
                    btn.Name = "deleteButton" + count; //DELETED '_' at the end
                    btn.TabIndex = count;
                    break;

                case "add":
                    btn.Text = "Add New";
                    btn.Name = "addButton";
                    break;

                case "exit":
                    btn.Text = "Exit";
                    btn.Name = "exitButton";
                    btn.BackColor = Color.DarkGray;
                    break;
            }

            btn.Click += new System.EventHandler(this.btn_Click);

            return btn;
        }
        private void addRow(int id, string txtValue, int count)
        {
            Panel pnl = new Panel();
            this.Controls.Add(pnl);
            pnl.Name = "row" + count;
            pnl.Top = 40 * count;
            pnl.Left = 8;
            pnl.Height = 40;
            pnl.Width = max_width * 9 + 168;
            if(name == "locations") pnl.Width = max_width * 18 + 180;
            TextBox txt = addTextBox(id, txtValue, count);
            pnl.Controls.Add(txt);

            ComboBox cmb = new ComboBox();

            if (name == "locations")
            {
                cmb.Width = max_width * 9;
                cmb.Font = new Font(txt.Font.FontFamily, 12);
                cmb.Top = 2;
                cmb.Left += txt.Width + 8;
                setDropDownValues(cmb);
                pnl.Controls.Add(cmb);
            }

            Button btn = new Button(); 
            if(txtValue != "")
            {
                
                btn = addButton(count, "edit");
                btn.Left += txt.Width + 8;
                if (name == "locations") btn.Left += cmb.Width + 8;
                pnl.Controls.Add(btn);

                btn = addButton(count, "delete");
                btn.Left += txt.Width + 8 + btn.Width;
                if (name == "locations") btn.Left += cmb.Width + 12;
                pnl.Controls.Add(btn);
            }
            else
            {
                pnl.Controls.Remove(cmb);
                btn = addButton(count, "add");
                btn.Left += txt.Width + 8;
                if (name == "acquaintances" || name == "locations")
                {
                    if(name == "locations") btn.Left = -1;
                    pnl.Controls.Remove(txt);
                }
                pnl.Controls.Add(btn);

                if (name == "locations")
                {
                    btn = addButton(count, "edit_cities");
                    btn.Left += txt.Width + 7;
                    pnl.Controls.Add(btn);
                }

                btn = addButton(count, "exit");
                btn.Left += txt.Width + 8 + btn.Width;
                if (name == "locations") btn.Left += cmb.Width + 12;
                pnl.Controls.Add(btn);
            }
        }
        private void removeTable()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Panel) this.Controls[i].Dispose();
            }
        }
        private void btn_Click(object Sender, EventArgs e)
        {
            Button btn = Sender as Button;

            var arr = this.Controls.Find("txt" + btn.TabIndex, true);
            TextBox txt = (TextBox)arr[0];

            if (name == "acquaintances" || name == "locations")
            {
                if (Application.OpenForms.OfType<addAcquaintanceForm>().Count() == 1)
                    Application.OpenForms.OfType<addAcquaintanceForm>().First().Close();

                switch (btn.Text)
                {
                    case "Add New":
                        addAcquaintanceForm add = new addAcquaintanceForm(user_id);
                        add.Show();
                        break;

                    case "Edit":
                        if (name == "acquaintances")
                        {
                            string name_city = txt.Text;
                            name_city = name_city.Replace(",", ""); // MOVE THIS TO EDIT FORM BEFORE THE CONSTRUCTOR IS CALLED
                            string[] arr1 = name_city.Split(' ');

                            MySqlCommand cmd = new MySqlCommand($"SELECT a.first_name, a.last_name, a.gender, o.occupation, c.city, a.address, r.relationship " +
                                                                $"FROM user_acquaintance_relationships ua " +
                                                                $"JOIN acquaintances a ON ua.acquaintance_id = a.id " +
                                                                $"JOIN cities c ON a.city_id = c.id " +
                                                                $"JOIN occupations o ON a.occupation_id = o.id " +
                                                                $"JOIN relationships r ON ua.relationship_id = r.id " +
                                                                $"WHERE ua.user_id = {user_id} " +
                                                                $"AND a.first_name = \'{arr1[0]}\' " +
                                                                $"AND a.last_name = \'{arr1[1]}\' " +
                                                                $"AND c.city = \'{arr1[2]}\'", Connect.con);

                            Connect.con.Open();

                            List<string> list = new List<string>();
                            var dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                dr.Read();

                                list.Add(u.CapitalizeFirstLetters(dr.GetString(0))); //first_name
                                list.Add(u.CapitalizeFirstLetters(dr.GetString(1))); //last_name
                                list.Add(dr.GetString(2)); //gender
                                list.Add(u.CapitalizeFirstLetters(dr.GetString(3))); //occupation
                                list.Add(u.CapitalizeFirstLetters(dr.GetString(4))); //city
                                if (!dr.IsDBNull(5)) list.Add(u.CapitalizeFirstLetters(dr.GetString(5))); //address
                                else list.Add("");
                                list.Add(u.CapitalizeFirstLetters(dr.GetString(6))); //relationship
                            }

                            Connect.con.Close();
                            u.M($"{list[0]}, {list[1]}, {list[2]}, {list[3]}, {list[4]}, {list[5]}, {list[6]}");
                            addAcquaintanceForm edit = new addAcquaintanceForm(null, user_id, list[0], list[1], list[2], list[3], list[4], list[5], list[6]);
                            edit.Show();                            
                        }else
                        {
                            //TODO: ADD CODE AFTER addLocationForm has been created.
                        }
                        break;
                }
                
            }else
            {
                

                //var arr1 = this.Controls.Find("row" + btn.TabIndex, true);
                //Panel row = (Panel)arr1[0];


                switch (btn.Text)
                {
                    case "Edit":
                        oldText = txt.Text;
                        txt.ReadOnly = false;
                        btn.Text = "Commit";
                        break;

                    case "Commit":
                        if (oldText != txt.Text)
                        {
                            if (column != "city")
                            {
                                u.MySqlCommandImproved($"DELETE FROM user_{column}s WHERE {column}_id = {txt.TabIndex} AND user_id = {user_id};");
                            }
                            else
                            {
                                u.MySqlCommandImproved($"DELETE FROM user_cities WHERE city_id = {txt.TabIndex} AND user_id = {user_id};");
                            }
                            u.MySqlCommandImproved($"CALL sp_insertUser{u.CapitalizeFirstLetters(column)}(\'{txt.Text}\', {user_id})");

                            changesMade = true;
                            removeTable();
                            displayTable(name);
                        }

                        if (this.Controls.Count > 14) this.Width += 17;

                        txt.ReadOnly = true;
                        btn.Text = "Edit";
                        break;

                    case "Delete":

                        if (column != "city")
                        {
                            u.MySqlCommandImproved($"DELETE FROM user_{column}s WHERE {column}_id = {txt.TabIndex} AND user_id = {user_id};");
                        }
                        else
                        {
                            u.MySqlCommandImproved($"DELETE FROM user_cities WHERE city_id = {txt.TabIndex} AND user_id = {user_id};");
                        }

                        changesMade = true;
                        removeTable();
                        displayTable(name);
                        if (this.Controls.Count > 14) this.Width += 17;
                        break;

                    case "Add New":
                        u.MySqlCommandImproved($"CALL sp_insertUser{u.CapitalizeFirstLetters(column)}(\'{txt.Text}\', {user_id})");

                        changesMade = true;
                        removeTable();
                        displayTable(name);
                        if (this.Controls.Count > 14) this.Width += 17;
                        break;

                    case "Exit":
                        this.Close();
                        break;
                }
            }
        }
        private void editForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changesMade)
            {
                parent.refreshDropdown(name);
                grandparent.refreshAcquaintancesDataGridView();
            }
        }
    }
}
