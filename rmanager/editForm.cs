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
            addRow("bruh");
        }
        
        private void setDataGridValues(string name)
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


        }

        private TextBox addTextBox()
        {
            TextBox txt = new TextBox();
            return txt;
        }
        private Button addButton()
        {
            Button btn = new Button();
            return btn;
        }
        private void addRow(string textBoxValue)
        {
            TextBox txt = new TextBox();
            this.Controls.Add(txt);
            txt.Top = 35;
            txt.Left = 25;
            txt.Text = textBoxValue;
            txt.Font = new Font(txt.Font.FontFamily, 16);
            txt.Width = 122;

            Button btn = new Button();
            this.Controls.Add(btn);
            btn.Top = 35;
            btn.Left = 157;
            btn.Height = 31;
        }
    }
}
