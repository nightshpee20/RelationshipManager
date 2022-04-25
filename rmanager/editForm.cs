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
        private string column_name;
        public editForm(string name, int user_id)
        {
            InitializeComponent();
            this.Text = Utilities.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            this.name = name;
            switch(name)
            {
                case "cities":
                    column_name = "city";
                    break;
                case "occupations":
                    column_name = "occupation";
                    break;
                case "relationships":
                    column_name = "relationship";
                    break;
            }
            displayTable(name);
            addRow(1, "hellooooo");
            addRow(2, "thereeee");
            addRow(3, "wwwwww");
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

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    MessageBox.Show(dt.Rows[i][0].ToString());
            //    //addRow(i + 1, dt.Rows[i][0].ToString());
            //}
        }

        private TextBox addTextBox(int id, string txtValue)
        {
            TextBox txt = new TextBox();
            //txt.Top = 47;
            //txt.Left = 8;
            //txt.Text = textBoxValue;
            txt.Name = "txt" + id;
            txt.Text = txtValue;
            txt.Font = new Font(txt.Font.FontFamily, 12);
            txt.Width = txtValue.Length * 12;
            txt.Top = 3;
            txt.ReadOnly = true;

            //Experiment
            //txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            //txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txt.Location = new System.Drawing.Point(11, 278);
            //txt.Name = "txt" + id;
            //txt.Size = new System.Drawing.Size(161, 38);
            //txt.TabIndex = 18;

            return txt;
        }
        private Button addButton(int id)
        {
            Button btn = new Button();
            btn.Name = "btn" + id;
            //btn.Top = 47;
            btn.Left = 126;
            btn.Height = 32;
            btn.Width = 80;
            return btn;
        }
        //TextBox txt, Button edt, Button del
        private void addRow(int id, string txtValue)
        {
            Panel pnl = new Panel();
            this.Controls.Add(pnl);

            pnl.Name = "row" + id;
            pnl.Top = 40*id;
            pnl.Left = 8;
            pnl.Height = 32;
            pnl.Width = 290;
            pnl.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            pnl.BackColor = Color.DarkGray;

            Button btn = addButton(id);
            pnl.Controls.Add(btn);
            btn = addButton(id);
            btn.Left += 82;
            pnl.Controls.Add(btn);
            
            pnl.Click += new System.EventHandler(this.pnl_Click);

            TextBox txt = addTextBox(id, txtValue);
            pnl.Controls.Add(txt);
        }

        private void pnl_Click(object Sender, EventArgs e)
        {
            Panel pnl = Sender as Panel;
            MessageBox.Show(pnl.Name);
        }
       
    }
}
