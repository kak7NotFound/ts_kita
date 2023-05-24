using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ts_kita
{
    public partial class CaseForm : Form
    {
        private String login;
        private String title;
        
        public CaseForm(String login, String title)
        {
            this.login = login;
            this.title = title;
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
                    richTextBox1.Text = reader.GetString(6);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginForm.Permission != "admin")
            {
                Program.database.ExecuteNonQuery($"update requests set messages = '{richTextBox1.Text + "\n\n" + "Клиент:\n" + textBox5.Text}' where login = '{login}' and title = '{title}'");
                richTextBox1.Text = richTextBox1.Text + "\n\n" + "Клиент:\n" + textBox5.Text;
                textBox5.Clear(); 
            }
            else
            {
                Program.database.ExecuteNonQuery($"update requests set messages = '{richTextBox1.Text + "\n\n" + "Админ:\n" + textBox5.Text}' where login = '{login}' and title = '{title}'");
                richTextBox1.Text = richTextBox1.Text + "\n\n" + "Админ:\n" + textBox5.Text;
                textBox5.Clear(); 
            }
            
        }
    }
}