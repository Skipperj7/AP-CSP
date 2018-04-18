using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
//cite these imports


namespace AP_CSP_Create
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //
            try
            {
                StreamReader reader = new StreamReader("AccountDetails.txt");
                while (reader.Peek() >= 0)
                {
                    usernamePasswordEmail.Add(reader.ReadLine());
                }
                reader.Close();

                StreamReader readerU = new StreamReader("AccountDetailsUsername.txt");
                while (readerU.Peek() >= 0)
                {
                    usernameList.Add(readerU.ReadLine());
                }
                readerU.Close();

            }
            catch (Exception)
            {
                //this just skips if no file is found
                Console.WriteLine("Save file missing");
            }
            Login_Button.IsEnabled = true;
            Login_Button.Visibility = System.Windows.Visibility.Visible;
            CreateAccount_Button.IsEnabled = true;
            CreateAccount_Button.Visibility = System.Windows.Visibility.Visible;
            Quit_Button.IsEnabled = true;
            Quit_Button.Visibility = System.Windows.Visibility.Visible;
            title.IsEnabled = true;
            title.Visibility = System.Windows.Visibility.Visible;
        }
        //when create account button is clicked
        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            Username_TextBox.IsEnabled = true;
            Username_TextBox.Visibility = System.Windows.Visibility.Visible;
            Password_TextBox.IsEnabled = true;
            Password_TextBox.Visibility = System.Windows.Visibility.Visible;
            Email_TextBox.IsEnabled = true;
            Email_TextBox.Visibility = System.Windows.Visibility.Visible;
            back_Button.IsEnabled = true;
            back_Button.Visibility = System.Windows.Visibility.Visible;
            CreateAccountInCreateAccount_Button.IsEnabled = true;
            CreateAccountInCreateAccount_Button.Visibility = System.Windows.Visibility.Visible;

            Login_Button.IsEnabled = false;
            Login_Button.Visibility = System.Windows.Visibility.Hidden;
            CreateAccount_Button.IsEnabled = false;
            CreateAccount_Button.Visibility = System.Windows.Visibility.Hidden;
            Quit_Button.IsEnabled = false;
            Quit_Button.Visibility = System.Windows.Visibility.Hidden;
        }

        private void createAccountInCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            createAccount(Username_TextBox.Text, Password_TextBox.Text, Email_TextBox.Text);

            if (createdAccount)
            {
                Username_TextBox.IsEnabled = false;
                Username_TextBox.Visibility = System.Windows.Visibility.Hidden;
                Password_TextBox.IsEnabled = false;
                Password_TextBox.Visibility = System.Windows.Visibility.Hidden;
                Email_TextBox.IsEnabled = false;
                Email_TextBox.Visibility = System.Windows.Visibility.Hidden;
                back_Button.IsEnabled = false;
                back_Button.Visibility = System.Windows.Visibility.Hidden;
                LoginInLogin_Button.IsEnabled = false;
                LoginInLogin_Button.Visibility = System.Windows.Visibility.Hidden;
                CreateAccountInCreateAccount_Button.IsEnabled = false;
                CreateAccountInCreateAccount_Button.Visibility = System.Windows.Visibility.Hidden;
                openAccount();
            }
        }

        //accounts list
        public static List<string> usernamePasswordEmail = new List<string>();
        public static List<string> usernameList = new List<string>();

        //create account
        static bool createdAccount;
        public static void createAccount(string username, string password, string email)
        {
            //validdate username 
            
            foreach (string username2 in usernameList)
            {

                if (username2 == username)
                {
                   
                    MessageBox.Show("This username already exists.");

                      
                }
                else
                {

                    createdAccount = true;
                    string account = username + "-" + password + "-" + email;
                    usernamePasswordEmail.Add(account);
                    usernameList.Add(username);
                    saveList();
                    saveUsernameList();
                    break;


                }
            }

            if (usernamePasswordEmail.Count <= 0)
            {
                Console.WriteLine("File has been deleted");
                createdAccount = true;
                string account = username + "-" + password + "-" + email;
                usernamePasswordEmail.Add(account);
                usernameList.Add(username);
                saveList();
                saveUsernameList();
            }
        }
            
        

        public static bool loginSuccess;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Username_TextBox.IsEnabled = true;
            Username_TextBox.Visibility = System.Windows.Visibility.Visible;
            Password_TextBox.IsEnabled = true;
            Password_TextBox.Visibility = System.Windows.Visibility.Visible;
            LoginInLogin_Button.IsEnabled = true;
            LoginInLogin_Button.Visibility = System.Windows.Visibility.Visible;
            back_Button.IsEnabled = true;
            back_Button.Visibility = System.Windows.Visibility.Visible;
            CreateAccountInCreateAccount_Button.IsEnabled = false;
            CreateAccountInCreateAccount_Button.Visibility = System.Windows.Visibility.Hidden;

            Login_Button.IsEnabled = false;
            Login_Button.Visibility = System.Windows.Visibility.Hidden;
            CreateAccount_Button.IsEnabled = false;
            CreateAccount_Button.Visibility = System.Windows.Visibility.Hidden;
            Quit_Button.IsEnabled = false;
            Quit_Button.Visibility = System.Windows.Visibility.Hidden;
        }

        private void LoginInLogin_Click(object sender, RoutedEventArgs e)
        {

            checkAccount(Username_TextBox.Text, Password_TextBox.Text);

            if (loginSuccess)
            {
                Username_TextBox.IsEnabled = false;
                Username_TextBox.Visibility = System.Windows.Visibility.Hidden;
                Password_TextBox.IsEnabled = false;
                Password_TextBox.Visibility = System.Windows.Visibility.Hidden;
                Email_TextBox.IsEnabled = false;
                Email_TextBox.Visibility = System.Windows.Visibility.Hidden;
                back_Button.IsEnabled = false;
                back_Button.Visibility = System.Windows.Visibility.Hidden;
                LoginInLogin_Button.IsEnabled = false;
                LoginInLogin_Button.Visibility = System.Windows.Visibility.Hidden;
                CreateAccountInCreateAccount_Button.IsEnabled = false;
                CreateAccountInCreateAccount_Button.Visibility = System.Windows.Visibility.Hidden;
                openAccount();
            }
        }
        //checks if account is real
        private static void checkAccount(string username, string password)
        {
            int? index;
            foreach (string username2 in usernameList)
            {
                if (username2 == username)
                {
                    
                    int? i = 0;
                    try
                    {
                        while (username2 != usernameList[(int)i])
                        {
                            i++;
                        }
                        index = i;
                        if (index != null)
                        {

                            try
                            {
                                string UsernamePasswordEmail = usernamePasswordEmail[(int)index];
                                int UsrLength = username.Length + 1;
                                int PasLength = password.Length;
                                string Password = UsernamePasswordEmail.Substring(UsrLength, PasLength);

                                if (Password == password)
                                {
                                    loginSuccess = true;
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("The password is inncorrect.");
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("This account doesn't exist!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("This account doesn't exist!");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                    }
                    
                }
            }
            
            if (usernamePasswordEmail.Count <= 0)
            {
                Console.WriteLine("File doesn't exist");
                MessageBox.Show("There is no save file.");
            }
        }

        private static void openAccount()
        {

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Username_TextBox.IsEnabled = false;
            Username_TextBox.Visibility = System.Windows.Visibility.Hidden;
            Password_TextBox.IsEnabled = false;
            Password_TextBox.Visibility = System.Windows.Visibility.Hidden;
            Email_TextBox.IsEnabled = false;
            Email_TextBox.Visibility = System.Windows.Visibility.Hidden;
            back_Button.IsEnabled = false;
            back_Button.Visibility = System.Windows.Visibility.Hidden;
            LoginInLogin_Button.IsEnabled = false;
            LoginInLogin_Button.Visibility = System.Windows.Visibility.Hidden;
            CreateAccountInCreateAccount_Button.IsEnabled = false;
            CreateAccountInCreateAccount_Button.Visibility = System.Windows.Visibility.Hidden;

            Login_Button.IsEnabled = true;
            Login_Button.Visibility = System.Windows.Visibility.Visible;
            CreateAccount_Button.IsEnabled = true;
            CreateAccount_Button.Visibility = System.Windows.Visibility.Visible;
            Quit_Button.IsEnabled = true;
            Quit_Button.Visibility = System.Windows.Visibility.Visible;
        }

        private static void saveList()
        {
            
            TextWriter saver = new StreamWriter("AccountDetails.txt");

            foreach (String deatils in usernamePasswordEmail)
                saver.WriteLine(deatils);

            saver.Close();
            Console.WriteLine("saved");

        }
        private static void saveUsernameList()
        {

            TextWriter saver = new StreamWriter("AccountDetailsUsername.txt");

            foreach (String deatils in usernameList)
                saver.WriteLine(deatils);

            saver.Close();
            Console.WriteLine("saved");

        }
   
        private void purgeSave(object sender, RoutedEventArgs e)
        {

            TextWriter saver = new StreamWriter("AccountDetails.txt");
            saver.WriteLine("");
            saver.Close();
            File.Delete("AccountDetails.txt");
            TextWriter saverU = new StreamWriter("AccountDetailsUsername.txt");
            saverU.WriteLine("");
            saverU.Close();
            File.Delete("AccountDetailsUsername.txt");
            Console.WriteLine("purged");
        }
    }
}
