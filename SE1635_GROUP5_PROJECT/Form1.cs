using SE1635_GROUP5_PROJECT.Model;

namespace SE1635_GROUP5_PROJECT
{
    public partial class Form1 : Form
    {
        private ProjectPrnContext projectPrnContext;
        public Form1()
        {
            InitializeComponent();
            projectPrnContext = new ProjectPrnContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Account account = projectPrnContext.Accounts.FirstOrDefault(s => s.FirstName.Equals(username) && s.Password.Equals(password));
            if(account == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công!");
                Home home = new Home();
                home.ShowDialog();
            }
        }
    }
}