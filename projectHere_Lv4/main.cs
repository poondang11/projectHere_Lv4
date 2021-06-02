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
    public partial class main : Form
    {
        private MySqlConnection Databaseconnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=sto_for_pro;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }
        private void showequipment(string args)
        {
            MySqlConnection conn = Databaseconnection();

            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM wanted";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            showequipment("SELECT * FROM wanted");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Databaseconnection();
            string sql = $"INSERT INTO wanted(name,sername,class,color,size) VALUES(\"{textBox2.Text}\",\"{textBox3.Text}\",\"{textBox4.Text}\",\"{textBox5.Text}\",\"{Program.size}\")";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("add success!!", "message");
                showequipment("SELECT * FROM wanted");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                radio_s.Checked = true;
                radio_m.Checked = false;
                radio_l.Checked = false;
                radio_xl.Checked = false;

            }
        }

        private void radio_s_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_s.Checked == true)
            {
                Program.size = "S";
            }
        }

        private void radio_m_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_m.Checked == true)
            {
                Program.size = "M";
            }
        }

        private void radio_l_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_l.Checked == true)
            {
                Program.size = "L";
            }
        }

        private void radio_xl_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_xl.Checked == true)
            {
                Program.size = "XL";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRows = dataGridView1.CurrentCell.RowIndex;
            int edited = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["ID"].Value);

            MySqlConnection conn = Databaseconnection();
            string sql = $"UPDATE wanted SET name =\"{textBox2.Text}\",sername =\"{textBox3.Text}\",class =\"{textBox4.Text}\",color =\"{textBox5.Text}\",size=\"{Program.size}\" WHERE ID =\"{edited}\"";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("edit success!!", "message");
                showequipment("SELECT * FROM wanted");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                radio_s.Checked = true;
                radio_m.Checked = false;
                radio_l.Checked = false;
                radio_xl.Checked = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            var ShowImaget = dataGridView1.Rows[selectedRow].Cells["name"].Value;
            textBox2.Text = ShowImaget.ToString();
            int selectedRowman = dataGridView1.CurrentCell.RowIndex;
            var ShowImageta = dataGridView1.Rows[selectedRowman].Cells["sername"].Value;
            textBox3.Text = ShowImageta.ToString();
            int selectedRowa = dataGridView1.CurrentCell.RowIndex;
            var ShowImagets = dataGridView1.Rows[selectedRowa].Cells["class"].Value;
            textBox4.Text = ShowImagets.ToString();
            int selectedRowf = dataGridView1.CurrentCell.RowIndex;
            var ShowImagert = dataGridView1.Rows[selectedRowf].Cells["color"].Value;
            textBox5.Text = ShowImagert.ToString();
            int selectedRows = dataGridView1.CurrentCell.RowIndex;
            string ShowImagetw = dataGridView1.Rows[selectedRows].Cells["size"].Value.ToString();
            if (ShowImagetw == "S")
            {
                radio_s.Checked = true;
                radio_m.Checked = false;
                radio_l.Checked = false;
                radio_xl.Checked = false;
            }
            else if (ShowImagetw == "M")
            {
                radio_s.Checked = false;
                radio_m.Checked = true;
                radio_l.Checked = false;
                radio_xl.Checked = false;
            }
            else if (ShowImagetw == "L")
            {
                radio_s.Checked = false;
                radio_m.Checked = false;
                radio_l.Checked = true;
                radio_xl.Checked = false;
            }
            else if (ShowImagetw == "XL")
            {
                radio_s.Checked = false;
                radio_m.Checked = false;
                radio_l.Checked = false;
                radio_xl.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name;
            name = textBox1.Text;
            MySqlConnection conn = Databaseconnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = ($"SELECT * FROM wanted WHERE name = \"{name}\"");

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedRows = dataGridView1.CurrentCell.RowIndex;
            int deleted = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["ID"].Value);

            MySqlConnection conn = Databaseconnection();
            string sql = $"DELETE FROM wanted WHERE ID =\"{deleted}\"";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("delete success!!", "message");
                showequipment("SELECT * FROM wanted");
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ราคาของเเต่ละไซต์ \nไซต์ s ราคา 120 บาท \n ไซต์ m ราคา 150 บาท \n ไซต์ L ราคา 170 บาท \n ไซต์ XL ราคา 180 บาท", "information");
        }
    }
}
