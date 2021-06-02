using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectHere_Lv4
{
    public partial class reg : Form
    {
        private MySqlConnection Databaseconnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=sto_for_pro;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }

        public reg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == textBox3.Text)
            {
                MySqlConnection conn = Databaseconnection();
                string sql = $"INSERT INTO user(ID,pass) VALUES(\"{textBox1.Text}\",\"{textBox2.Text}\")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("register success!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f2 = new Form1();
                this.Hide();
                f2.Show();
            }
            else
            {
                MessageBox.Show("password is not match", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("       กรุณาใส่เฉพาะตัวเลขนะครับ", "!!!Alert!!!");
                e.Handled = true;
            }
        }
    }
}
