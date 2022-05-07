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
    public partial class addMeetingForm : Form
    {
        private userProfileForm parent;
        private int user_id;
        private DataTable dta, dtl, dtr;
        private string attribute;
        public addMeetingForm(userProfileForm parent, int user_id)
        {
            InitializeComponent();
            this.parent = parent;
            this.user_id = user_id;

            setDropDownValues(user_id, "acquaintances", acquaintancesDropDown, ref dta);
            setDropDownValues(user_id, "locations", locationsDropDown, ref dtl);
            setDropDownValues(user_id, "reasons", reasonsDropDown, ref dtr);

        }

        private void setDropDownValues(int user_id, string name, ComboBox cb, ref DataTable dt)
        {
            cb.DataSource = null;

            switch (name)
            {
                case "acquaintances":
                    attribute = "acquaintance";
                    break;
                case "locations":
                    attribute = "location";
                    break;
                case "reasons":
                    attribute = "reason";
                    break;
            }

            MySqlDataAdapter da = new MySqlDataAdapter();
            if (name == "acquaintances")
            {
                da = new MySqlDataAdapter($"SELECT" +
                                               $"(SELECT CONCAT(first_name, \" \", last_name, \", \", (SELECT city FROM cities c WHERE c.id = a.city_id)) " +
                                               $"FROM acquaintances a WHERE a.id = ua.acquaintance_id) AS acquaintance " +
                                          $"FROM user_acquaintance_relationships ua " +
                                          $"WHERE user_id = 1", Connect.con);
            }
            else
            {
                da = new MySqlDataAdapter($"SELECT n.{attribute}, n.id, un.user_id " +
                                          $"FROM user_{name} un " +
                                          $"JOIN {name} n ON un.{attribute}_id = n.id " +
                                          $"WHERE user_id = {user_id} " +
                                          $"ORDER BY n.{attribute} ASC;", Connect.con);
            }
            
            
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
        }
    }
}

