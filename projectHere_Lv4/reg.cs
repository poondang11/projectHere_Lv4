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
            MySqlConnection conn = Databaseconnection();
            conn.Open();
            DataTable table = new DataTable();
            if (textBox2.Text == textBox3.Text)
            {
                MySqlCommand check = new MySqlCommand("SELECT * FROM `user` WHERE  "+ textBox1.Text +" = `ID` ",conn);
                MySqlDataAdapter abc = new MySqlDataAdapter(check);
                abc.Fill(table);
                if (table.Rows.Count <= 0)
                {
                    string sql = $"INSERT INTO user(ID,pass) VALUES(\"{textBox1.Text}\",\"{textBox2.Text}\")";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int rows = cmd.ExecuteNonQuery();
                     

                    MessageBox.Show("register success!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 f2 = new Form1();
                    this.Hide();
                    f2.Show();
                }
                else
                {
                  MessageBox.Show("number id have already used!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("password is not match", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.Close();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("       กรุณาใส่เฉพาะตัวเลขนะครับ", "!!!warming!!!");
                e.Handled = true;
            }

            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                MessageBox.Show("       กรุณาใส่เฉพาะตัวเลขนะครับ", "!!!warming!!!");
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.UseSystemPasswordChar = false;
            if (checkBox1.Checked == false)
                textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox3.UseSystemPasswordChar = false;
            if (checkBox2.Checked == false)
                textBox3.UseSystemPasswordChar = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }
    }
}
