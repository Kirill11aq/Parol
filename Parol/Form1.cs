using System.Text;

namespace Parol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int length))
            {
                bool useUppercase = checkBox1.Checked;
                bool useNumbers = checkBox2.Checked;
                bool useSpecialChars = checkBox3.Checked;
                string password = GeneratePassword(length, useUppercase, useNumbers, useSpecialChars);
                textBox2.Text = password;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid length.");
            }
        }
        private string GeneratePassword(int length, bool useUppercase, bool useNumbers, bool useSpecialChars)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_+";
            StringBuilder password = new StringBuilder(length);
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                string charSet = lowercase;
                if (useUppercase)
                {
                    charSet += uppercase;
                }
                if (useNumbers)
                {
                    charSet += numbers;
                }
                if (useSpecialChars)
                {
                    charSet += specialChars;
                }
                password.Append(charSet[random.Next(charSet.Length)]);
            }
            return password.ToString();
        }
    }
}