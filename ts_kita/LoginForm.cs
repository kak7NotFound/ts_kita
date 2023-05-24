using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ts_kita
{
    public partial class LoginForm : Form
    {

        public static string Permission;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.database = new DataBase();

            using (var reader = Program.database.GetReader($"select * from users where login = '{textBox1.Text}' and password = '{textBox2.Text}'"))
            {
                while (reader.Read())
                { 
                    Permission = textBox1.Text; 
                    new Form1(textBox1.Text).Show();
return;
                }
            }
            MessageBox.Show("Неверный логин или пароль", "Ошибка");

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}