﻿using MySql.Data.MySqlClient;
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
        private int max_width;
        public editForm(string name, int user_id)
        {
            InitializeComponent();
            this.Text = Utilities.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            this.name = name;
            switch(name)
            {
                case "cities":
                    this.label1.Text = "Your CITIES:";
                    break;
                case "occupations":
                    this.label1.Text = "Your OCCUPATIONS:";
                    break;
                case "relationships":
                    this.label1.Text = "Your RELATIONSHIPS:";
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                addRow(int.Parse(dt.Rows[i]["id"].ToString()), dt.Rows[i][0].ToString(),i + 1);
            }

            addRow(0, "", dt.Rows.Count + 1);
        }

        private TextBox addTextBox(int id, string txtValue, int count)
        {
            TextBox txt = new TextBox();
           
            txt.Name = "txt" + count;
            txt.ReadOnly = true;
            txt.TabIndex = id;

            if(txtValue != "") txt.Text = Utilities.CapitalizeFirstLetters(txtValue);
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
            }

            btn.Click += new System.EventHandler(this.btn_Click);

            return btn;
        }
        //TextBox txt, Button edt, Button del
        private void addRow(int id, string txtValue, int count)
        {
            Panel pnl = new Panel();
            this.Controls.Add(pnl);

            pnl.Name = "row" + count;
            pnl.Top = 40*count;
            pnl.Left = 8;
            pnl.Height = 32;
            pnl.Width = max_width * 9 + 168;
            pnl.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            pnl.BackColor = Color.DarkGray;

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
            }
            
            pnl.Click += new System.EventHandler(this.pnl_Click);

           if(txt.Text.Length == 40)
            {
                this.Width = 40 + txt.Width + 2 * btn.Width;
            }

           if(this.ClientSize.Height < (count * 42) + 57)
            {
                this.ClientSize = new System.Drawing.Size(int.Parse(this.Width.ToString()), (count * 40) + 57);
            }
            
        }

        private void pnl_Click(object Sender, EventArgs e)
        {
            Panel pnl = Sender as Panel;
       
            MessageBox.Show(pnl.Name);
        }

        private void btn_Click(object Sender, EventArgs e)
        {
            Button btn = Sender as Button;

            var arr = this.Controls.Find("txt" + btn.TabIndex, true);
            TextBox txt = (TextBox)arr[0];

            if (btn.Text == "Edit")
            {
                
                
                //MessageBox.Show(txt.Text);
                txt.ReadOnly = false;
                btn.Text = "Commit";
                MessageBox.Show(txt.TabIndex.ToString());
                
            }else if(btn.Text == "Commit")
            {
                txt.ReadOnly = true;
                btn.Text = "Edit";
            }

        }

    }
}
