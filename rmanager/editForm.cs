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
        addAcquaintanceForm parent;
        private int max_width;
        
        public editForm(string name, int user_id, addAcquaintanceForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.Text = u.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            this.name = name;
            switch(name)
            {
                case "cities":
                    this.label1.Text = "Your CITIES:";
                    this.column = "city";
                    break;
                case "occupations":
                    this.label1.Text = "Your OCCUPATIONS:";
                    this.column = "occupation";
                    break;
                case "relationships":
                    this.label1.Text = "Your RELATIONSHIPS:";
                    this.column = "relationship";
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

            }
            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
       
            da.Fill(ds, name);
            dt = ds.Tables[name];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (max_width <= dt.Rows[i][0].ToString().Length) max_width = dt.Rows[i][0].ToString().Length;
            }
            
            this.Width = 40 + max_width * 9 + 160;
            
            
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
                    btn.Name = "editButton_" + count;
                    btn.TabIndex = count;
                    break;

                case "delete":
                    btn.Text = "Delete";
                    btn.Name = "deleteButton_" + count;
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
            pnl.Top = 40*count;
            pnl.Left = 8;
            pnl.Height = 40;
            pnl.Width = max_width * 9 + 168;
            TextBox txt = addTextBox(id, txtValue, count);
            pnl.Controls.Add(txt);

            Button btn = new Button(); 
            if(txtValue != "")
            {
                btn = addButton(count, "edit");
                btn.Left += txt.Width + 4;
                pnl.Controls.Add(btn);

                btn = addButton(count, "delete");
                btn.Left += txt.Width + 8 + btn.Width;
                pnl.Controls.Add(btn);
            }
            else
            {
                btn = addButton(count, "add");
                btn.Left += txt.Width + 4;
                pnl.Controls.Add(btn);

                btn = addButton(count, "exit");
                btn.Left += txt.Width + 8 + btn.Width;
                pnl.Controls.Add(btn);
            }
        }
        private void btn_Click(object Sender, EventArgs e)
        {
            Button btn = Sender as Button;

            var arr = this.Controls.Find("txt" + btn.TabIndex, true);
            TextBox txt = (TextBox)arr[0];

            var arr1 = this.Controls.Find("row" + btn.TabIndex, true);
            Panel row = (Panel)arr1[0];


            switch (btn.Text)
            {
                case "Edit":
                    oldText = txt.Text;
                    txt.ReadOnly = false;
                    btn.Text = "Commit"; 
                    break;

                case "Commit":
                    if(oldText != txt.Text)
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
                    
                    if(column != "city")
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
        private void removeTable()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Panel) this.Controls[i].Dispose();
            }
        }

        private void editForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changesMade)
            {
                parent.refreshDropdown(name);
            }
        }
    }
}
