using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TodoList;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'todoListDataSet.list' table. You can move, or remove it, as needed.
            this.listTableAdapter.Fill(this.todoListDataSet.list);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "insert into list(id,msg) VALUES('" + srnotxt.Text + "','" + textContent.Text + "')";
            SqlCommand cmd = new SqlCommand(query,con); 
            cmd.ExecuteNonQuery();
            MessageBox.Show("Task Added in your List");
            this.srnotxt.Text = "";
            this.textContent.Text = "";
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select *from list";
            SqlDataAdapter adb = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            adb.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from list where id = '" + deltxt.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("Deleted information !!!!!");
            }
            else
            {
                MessageBox.Show("Failed to Delete Data!!!!!!!!!!");
            }

            con.Close();
        }

      

        
        }

        

    }

