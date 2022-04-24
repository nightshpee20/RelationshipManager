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
            addRow();
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
            //txt.Top = 47;
            //txt.Left = 8;
            //txt.Text = textBoxValue;
            txt.Font = new Font(txt.Font.FontFamily, 12);
            txt.Width = 122;

            return txt;
        }
        private Button addButton()
        {
            Button btn = new Button();
            //btn.Top = 47;
            //btn.Left = 134;
            btn.Height = 31;
            btn.Width = 80;
            return btn;
        }
        //TextBox txt, Button edt, Button del
        private void addRow()
        {
            Panel pnl = new Panel();
            this.Controls.Add(pnl);

            pnl.Top = 47;
            pnl.Left = 8;
            pnl.Height = 31;
            pnl.Width = 290;
            pnl.BackColor = Color.DarkGray;
            
        }
    }
}
