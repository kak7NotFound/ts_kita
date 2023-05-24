using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ts_kita
{
    public partial class Form1 : Form
    {
        public Form1(string permission)
        {
            InitializeComponent();
            if (permission != "admin")
            {
                button1.Hide();
            }
            SyncDataGrid();
        }

        public void SyncDataGrid()
        {
            dataGridView1.Rows.Clear();
            using (var reader = Program.database.GetReader("select * from requests"))
            {
                while (reader.Read())
                {
                    if (LoginForm.Permission == "admin")
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                    else
                    {
                        if (reader.GetString(0) == LoginForm.Permission)
                        {
                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CreateRequestFrom().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.database.ExecuteNonQuery($"delete from requests where login = '{dataGridView1.CurrentRow.Cells[0].Value.ToString()}' and title = '{dataGridView1.CurrentRow.Cells[1].Value.ToString()}'");
            SyncDataGrid();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            SyncDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var reader = Program.database.GetReader($"select * from requests where login = '{dataGridView1.CurrentRow.Cells[0].Value.ToString()}' and title = '{dataGridView1.CurrentRow.Cells[1].Value.ToString()}'"))
            {
                while (reader.Read())
                {
                    new CaseForm(reader.GetString(0), reader.GetString(1)).Show();
                    return;
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }
    }
}