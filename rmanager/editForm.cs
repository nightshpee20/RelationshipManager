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
        public editForm(string name, int user_id)
        {
            InitializeComponent();
            this.Text = Utilities.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            setDataGridValues(name);
        }
        
        private void setDataGridValues(string name)
        {
            
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT uc.id, c.city, uc.user_id " +
                                                       $"FROM user_cities uc " +
                                                       $"JOIN cities c ON uc.city_id = c.id " +
                                                       $"WHERE user_id = {user_id} " +
                                                       $"ORDER BY c.city ASC;", Connect.con);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
       
            da.Fill(ds, name);
            dt = ds.Tables[name];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                editFormDataGridRecordBindingSource.Add(new editFormDataGridRecord()
                {
                    Id = (int)dt.Rows[i]["id"],
                    Value = (string)dt.Rows[i]["city"]
                });   
            }
        }
        //editDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()
        private void editDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlCommand cmd;
            int city_id = (int) editDataGridView.Rows[e.RowIndex].Cells[1].Value;
            if (e.ColumnIndex == 3)
            {
                Utilities.MySqlCommandImproved($"DELETE FROM user_acquaintance_relationships " +
                                               $"WHERE user_id = {user_id}" +
                                               $"AND acquaintance_id IN (SELECT id FROM acquaintances WHERE city_id = {city_id});");
                Utilities.MySqlCommandImproved($"DELETE FROM acquaintaces WHERE city_id = {city_id}");

                Utilities.MySqlCommandImproved($"DELETE FROM user_cities " +
                                               $"WHERE city_id = {city_id}" +
                                               $"AND user_id = {user_id};");
                
               
            }
        }
    }
}
