using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace rmanager
{  
    public static class u
    {
        //u <- Stands for Utilities. This class contains useful methods or just shortcuts I have created.
        

        //Takes in a string and capitalizes the first character of every word. E.G "hello world" -> "Hello World"
        public static string CapitalizeFirstLetters(string str)
        {
            string[] strSplit = str.Split(' ');

            string newStr = string.Empty;

            for (int i = 0; i < strSplit.Length; i++)
            {
                if(i + 1 == strSplit.Length)
                {
                    newStr += (char.ToUpper(strSplit[i][0]) + strSplit[i].Substring(1));
                }
                else
                {
                    newStr += (char.ToUpper(strSplit[i][0]) + strSplit[i].Substring(1) + " ");
                }
            }
            return newStr;
        }

        public static void MySqlCommandImproved(string command)
        {
            MySqlCommand cmd = new MySqlCommand(command, Connect.con);

            try
            {
                Connect.con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connect.con.Close();
            }
        }
        public static void M(string message)
        {
            MessageBox.Show(message);
        }
        public static void ColorRows(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i += 2)
            {
                dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
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
    }
}
