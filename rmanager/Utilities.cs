using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace rmanager
{
    public static class Utilities
    {
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
    }
}
