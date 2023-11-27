
using System.Data.SqlClient;
using System.Windows;


namespace Tomato_2nd.View
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Registration()
        {
            InitializeComponent();

        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        /// Using Sql for database
        /// 
        
        private void Register_button_Click(object sender, RoutedEventArgs e)
        {
            if (txtconfirmpassword.Password != string.Empty || txtpassword.Password != string.Empty || txtusername.Text != string.Empty)
            {
                if (txtpassword.Password == txtconfirmpassword.Password)
                {
                     cmd = new SqlCommand("select * from LoginTable where username='" + txtusername.Text + "'", cn);
                     dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Playername Already exist please try another ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable values(@username,@password)", cn);
                        cmd.Parameters.AddWithValue("username", txtusername.Text);
                        cmd.Parameters.AddWithValue("password", txtpassword.Password);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Registration_Load(object sender, RoutedEventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\blu3t\OneDrive\Asztali gép\Tomato Game\Tomato 2nd\Tomato 2nd\Data\Database1.mdf"";Integrated Security=True");
            cn.Open();
        }
    }
}
