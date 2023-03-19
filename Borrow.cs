using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginAndSignup
{
    public partial class Borrow : Form
    {
        private OleDbConnection con;
        public Borrow()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\LoginAndSignup\\LibSys.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            int no;
            int value = 1;
            no = int.Parse(txtno.Text);

            int oldquantity = Convert.ToInt32(txtquantity.Text);
            int newquantity = oldquantity - value;
            OleDbCommand com = new OleDbCommand("Update book SET Quantity= '" + newquantity + "', title= '" + txttitle.Text + "', author='" + txtauthor.Text + "'  where accession_number = '" + no + "'", con);
            com.ExecuteNonQuery();

            con.Close();
            loadDataGrid();

            MessageBox.Show("Successfully UPDATED!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();
            loadDataGrid();

            con.Open();
            OleDbCommand com1 = new OleDbCommand("INSERT INTO records values (@id_num, @first_name, @last_name, @accesion_numer, @title, @author)", con);
            com1.Parameters.AddWithValue("id_num", txtidnum.Text);
            com1.Parameters.AddWithValue("first_name", txtfname.Text);
            com1.Parameters.AddWithValue("last_name", txtlname.Text);
            com1.Parameters.AddWithValue("accession_numer", no);
            com1.Parameters.AddWithValue("title", txttitle.Text);
            com1.Parameters.AddWithValue("author", txtauthor.Text);
            com.ExecuteNonQuery();

            con.Close();
            loadDataGrid();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtno.Text = grid1.Rows[e.RowIndex].Cells["accession_number"].Value.ToString();
            txttitle.Text = grid1.Rows[e.RowIndex].Cells["title"].Value.ToString();
            txtauthor.Text = grid1.Rows[e.RowIndex].Cells["author"].Value.ToString();
            txtquantity.Text = grid1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
        }
        private void EmptyTextBox()
        {
            txtno.Text = "";
            txtauthor.Text = "";
            txttitle.Text = "";
            txtquantity.Text = "";

        }

        private void Borrow_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        private void loadDataGrid()
        {
            con.Open();

            OleDbCommand com = new OleDbCommand("Select * from book order by accession_number asc", con);
            com.ExecuteNonQuery();

            OleDbDataAdapter adap = new OleDbDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            grid1.DataSource = tab;

            con.Close();
            EmptyTextBox();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrower br = new Borrower();
            br.Show();
            this.Hide();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrow bw = new Borrow();
            bw.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            int no;
            int value = 1;
            no = int.Parse(txtno.Text);


            int oldquantity = Convert.ToInt32(txtquantity.Text);
            int newquantity = oldquantity + value;
            OleDbCommand com = new OleDbCommand("Update book SET Quantity= '" + newquantity + "', title= '" + txttitle.Text + "', author='" + txtauthor.Text + "'  where accession_number = '" + no + "'", con);
            com.ExecuteNonQuery();

            con.Close();
            loadDataGrid();

            MessageBox.Show("Successfully UPDATED!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDataGrid();

            con.Open();
            OleDbCommand com1 = new OleDbCommand("INSERT INTO records (id_num, first_name, last_name, accession_number, title, author) VALUES (@id_num, @first_name, @last_name, @accession_number, @title, @author)", con);
            com1.Parameters.AddWithValue("@id_num", txtidnum.Text);
            com1.Parameters.AddWithValue("@first_name", txtfname.Text);
            com1.Parameters.AddWithValue("@last_name", txtlname.Text);
            com1.Parameters.AddWithValue("@accession_number", no);
            com1.Parameters.AddWithValue("@title", txttitle.Text);
            com1.Parameters.AddWithValue("@author", txtauthor.Text);
            com1.ExecuteNonQuery();

            con.Close();
            loadDataGrid();

            

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            int idNum = int.Parse(txtidnum.Text);


            OleDbCommand com = new OleDbCommand("Select * from borrower where id_num = '" + idNum + "'" ,con);
            OleDbDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                txtfname.Text = reader.GetValue(1).ToString();
                txtlname.Text = reader.GetValue(2).ToString();
            }
            reader.Close();
            con.Close();
        }
    }
}
