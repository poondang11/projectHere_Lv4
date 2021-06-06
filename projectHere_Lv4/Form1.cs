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
    public partial class Form1 : Form
    {
        private MySqlConnection Databaseconnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=sto_for_pro;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Databaseconnection();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM user WHERE ID =\"{textBox1.Text}\" AND pass =\"{textBox2.Text}\"";

            MySqlDataReader row = cmd.ExecuteReader();
            if (row.HasRows)
            {
                MessageBox.Show("login success!!", "message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                main f2 = new main();
                this.Hide();
                f2.Show();
            }
            else { MessageBox.Show("login failed \nusername or password wrong!!", "message",MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            result = MessageBox.Show("you are exit?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reg f2 = new reg();
            this.Hide();
            f2.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("       กรุณาใส่เฉพาะตัวเลขนะครับ", "!!!warming!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }
    }
}
