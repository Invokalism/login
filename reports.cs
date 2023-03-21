using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndSignup
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrower borrower = new Borrower();
            borrower.Show();
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
            Borrow borrow = new Borrow();
            borrow.Show();
            this.Hide();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reports reports = new reports();
            reports.Show();
            this.Hide(); }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

