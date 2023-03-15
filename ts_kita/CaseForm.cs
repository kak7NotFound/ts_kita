using System;
using System.Windows.Forms;

namespace ts_kita
{
    public partial class CaseForm : Form
    {
        public CaseForm(String login, String title)
        {
            InitializeComponent();
            this.Text = "Клиент: "+ login + " | Тема: " + title;
            using (var reader = Program.database.GetReader($"select * from requests where login = '{login}' and title = '{title}'"))
            {
                while (reader.Read())
                {
                    textBox1.Text = reader.GetString(2);
                    textBox2.Text = reader.GetString(1);
                    textBox3.Text = reader.GetString(3);
                    textBox4.Text = reader.GetString(7);

                }
            }
        }
    }
}