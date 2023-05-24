using System;
using System.Windows.Forms;

namespace ts_kita
{
    public partial class LoginForm : Form
    {
        public static string Permission;
        public static string Login;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.database = new DataBase();

            using (var reader =
                   Program.database.GetReader(
                       $"select * from users where login = '{textBox1.Text}' and password = '{textBox2.Text}'"))
            {
                while (reader.Read())
                {
                    Login = textBox1.Text;
                    Permission = reader.GetString(2);
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