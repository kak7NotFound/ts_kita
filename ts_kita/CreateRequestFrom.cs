using System;
using System.Windows.Forms;

namespace ts_kita
{
    public partial class CreateRequestFrom : Form
    {
        public CreateRequestFrom()
        {
            InitializeComponent();
        }

        private void CreateRequestFrom_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"insert into requests values ('{comboBox1.Text}', '{textBox1.Text}', '{comboBox2.Text}', '{Program.GetNow()}', '1', '{Program.GetNow()}', '{richTextBox1.Text}', '{textBox2.Text}')");
            this.Close();
        }
    }
}