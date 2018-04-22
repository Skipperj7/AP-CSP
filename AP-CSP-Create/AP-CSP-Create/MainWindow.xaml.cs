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
                if (!File.Exists(usernameOfUser + "Values.txt"))
                {

                    _1Day_Button.IsEnabled = true;
                    _1Day_Button.Visibility = System.Windows.Visibility.Visible;
                    _7Day_Button.IsEnabled = true;
                    _7Day_Button.Visibility = System.Windows.Visibility.Visible;
                    _21Day_Button.IsEnabled = true;
                    _21Day_Button.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        //accounts list
        public static List<string> usernamePasswordEmail = new List<string>();
        public static List<string> usernameList = new List<string>();
        public static List<string> valuesList = new List<string>();
        public static string usernameOfUser;

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
                    usernameOfUser = username;
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
                usernameOfUser = username;
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
                title.IsEnabled = false;
                title.Visibility = System.Windows.Visibility.Hidden;
                

                Goal_Label.IsEnabled = true;
                Goal_Label.Visibility = System.Windows.Visibility.Visible;
                TotalAmount_Label_.IsEnabled = true;
                TotalAmount_Label_.Visibility = System.Windows.Visibility.Visible;
                goal_textBox.IsEnabled = true;
                goal_textBox.Visibility = System.Windows.Visibility.Visible;
                Total_Label.IsEnabled = true;
                Total_Label.Visibility = System.Windows.Visibility.Visible;
                
                if (!File.Exists(usernameOfUser + "Values.txt"))
                {
                    
                    _1Day_Button.IsEnabled = true;
                    _1Day_Button.Visibility = System.Windows.Visibility.Visible;
                    _7Day_Button.IsEnabled = true;
                    _7Day_Button.Visibility = System.Windows.Visibility.Visible;
                    _21Day_Button.IsEnabled = true;
                    _21Day_Button.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {

                    if (File.ReadLines(usernameOfUser + "Values.txt").Last() == "1True")
                    {
                        StreamReader reader = new StreamReader(usernameOfUser + "Values.txt");
                        while (reader.Peek() >= 0)
                        {
                            valuesList.Add(reader.ReadLine());
                        }
                        reader.Close();
                        if (valuesList[0] != null)
                        {
                            goal_textBox.Text = valuesList[0];
                        }
                        if (valuesList[1] != null)
                        {
                            Day1_TextBox.Text = valuesList[1];
                        }
                        if (valuesList[2] != null)
                        {
                            TotalAmount_Label_.Content = valuesList[2];
                        }
                        _1Day = true;
                        Save_button.IsEnabled = true;
                        Save_button.Visibility = System.Windows.Visibility.Visible;
                        reset_button.IsEnabled = true;
                        reset_button.Visibility = System.Windows.Visibility.Visible;

                        _1Day_Button.IsEnabled = false;
                        _1Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _7Day_Button.IsEnabled = false;
                        _7Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _21Day_Button.IsEnabled = false;
                        _21Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _1Day = true;

                        Day1_label.IsEnabled = true;
                        Day1_label.Visibility = System.Windows.Visibility.Visible;
                        Day1_TextBox.IsEnabled = true;
                        Day1_TextBox.Visibility = System.Windows.Visibility.Visible;

                    }
                    else if (File.ReadLines(usernameOfUser + "Values.txt").Last() == "7True")
                    {
                        StreamReader reader = new StreamReader(usernameOfUser + "Values.txt");
                        while (reader.Peek() >= 0)
                        {
                            valuesList.Add(reader.ReadLine());
                        }
                        reader.Close();
                        if (valuesList[0] != null)
                        {
                            goal_textBox.Text = valuesList[0];
                        }
                        if (valuesList[1] != null)
                        {
                            Day1_TextBox.Text = valuesList[1];
                        }
                        if (valuesList[2] != null)
                        {
                            Day2_TextBox.Text = valuesList[2];
                        }
                        if (valuesList[3] != null)
                        {
                            Day3_TextBox.Text = valuesList[3];
                        }
                        if (valuesList[4] != null)
                        {
                            Day4_TextBox.Text = valuesList[4];
                        }
                        if (valuesList[5] != null)
                        {
                            Day5_TextBox.Text = valuesList[5];
                        }
                        if (valuesList[6] != null)
                        {
                            Day6_TextBox.Text = valuesList[6];
                        }
                        if (valuesList[7] != null)
                        {
                            Day7_TextBox.Text = valuesList[7];
                        }
                        if (valuesList[8] != null)
                        {
                            TotalAmount_Label_.Content = valuesList[8];
                        }
                        _7Day = true;
                        Save_button.IsEnabled = true;
                        Save_button.Visibility = System.Windows.Visibility.Visible;
                        reset_button.IsEnabled = true;
                        reset_button.Visibility = System.Windows.Visibility.Visible;

                        _1Day_Button.IsEnabled = false;
                        _1Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _7Day_Button.IsEnabled = false;
                        _7Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _21Day_Button.IsEnabled = false;
                        _21Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _7Day = true;

                        Day1_label.IsEnabled = true;
                        Day1_label.Visibility = System.Windows.Visibility.Visible;
                        Day1_TextBox.IsEnabled = true;
                        Day1_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day2_label.IsEnabled = true;
                        Day2_label.Visibility = System.Windows.Visibility.Visible;
                        Day2_TextBox.IsEnabled = true;
                        Day2_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day3_label.IsEnabled = true;
                        Day3_label.Visibility = System.Windows.Visibility.Visible;
                        Day3_TextBox.IsEnabled = true;
                        Day3_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day4_label.IsEnabled = true;
                        Day4_label.Visibility = System.Windows.Visibility.Visible;
                        Day4_TextBox.IsEnabled = true;
                        Day4_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day5_label.IsEnabled = true;
                        Day5_label.Visibility = System.Windows.Visibility.Visible;
                        Day5_TextBox.IsEnabled = true;
                        Day5_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day6_label.IsEnabled = true;
                        Day6_label.Visibility = System.Windows.Visibility.Visible;
                        Day6_TextBox.IsEnabled = true;
                        Day6_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day7_label.IsEnabled = true;
                        Day7_label.Visibility = System.Windows.Visibility.Visible;
                        Day7_TextBox.IsEnabled = true;
                        Day7_TextBox.Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (File.ReadLines(usernameOfUser + "Values.txt").Last() == "21True")
                    {
                        StreamReader reader = new StreamReader(usernameOfUser + "Values.txt");
                        while (reader.Peek() >= 0)
                        {
                            valuesList.Add(reader.ReadLine());
                        }
                        reader.Close();
                        if (valuesList[0] != null)
                        {
                            goal_textBox.Text = valuesList[0];
                        }
                        if (valuesList[1] != null)
                        {
                            Day1_TextBox.Text = valuesList[1];
                        }
                        if (valuesList[2] != null)
                        {
                            Day2_TextBox.Text = valuesList[2];
                        }
                        if (valuesList[3] != null)
                        {
                            Day3_TextBox.Text = valuesList[3];
                        }
                        if (valuesList[4] != null)
                        {
                            Day4_TextBox.Text = valuesList[4];
                        }
                        if (valuesList[5] != null)
                        {
                            Day5_TextBox.Text = valuesList[5];
                        }
                        if (valuesList[6] != null)
                        {
                            Day6_TextBox.Text = valuesList[6];
                        }
                        if (valuesList[7] != null)
                        {
                            Day7_TextBox.Text = valuesList[7];
                        }
                        if (valuesList[8] != null)
                        {
                            Day8_TextBox.Text = valuesList[8];
                        }
                        if (valuesList[9] != null)
                        {
                            Day9_TextBox.Text = valuesList[9];
                        }
                        if (valuesList[10] != null)
                        {
                            Day10_TextBox.Text = valuesList[10];
                        }
                        if (valuesList[11] != null)
                        {
                            Day11_TextBox.Text = valuesList[11];
                        }
                        if (valuesList[12] != null)
                        {
                            Day12_TextBox.Text = valuesList[12];
                        }
                        if (valuesList[13] != null)
                        {
                            Day13_TextBox.Text = valuesList[13];
                        }
                        if (valuesList[14] != null)
                        {
                            Day14_TextBox.Text = valuesList[14];
                        }
                        if (valuesList[15] != null)
                        {
                            Day15_TextBox.Text = valuesList[15];
                        }
                        if (valuesList[16] != null)
                        {
                            Day16_TextBox.Text = valuesList[16];
                        }
                        if (valuesList[17] != null)
                        {
                            Day17_TextBox.Text = valuesList[17];
                        }
                        if (valuesList[18] != null)
                        {
                            Day18_TextBox.Text = valuesList[18];
                        }
                        if (valuesList[19] != null)
                        {
                            Day19_TextBox.Text = valuesList[19];
                        }
                        if (valuesList[20] != null)
                        {
                            Day20_TextBox.Text = valuesList[20];
                        }
                        if (valuesList[21] != null)
                        {
                            Day21_TextBox.Text = valuesList[21];
                        }
                        if (valuesList[22] != null)
                        {
                            TotalAmount_Label_.Content = valuesList[22];
                        }
                        
                        _21Day = true;
                        Save_button.IsEnabled = true;
                        Save_button.Visibility = System.Windows.Visibility.Visible;
                        reset_button.IsEnabled = true;
                        reset_button.Visibility = System.Windows.Visibility.Visible;

                        _1Day_Button.IsEnabled = false;
                        _1Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _7Day_Button.IsEnabled = false;
                        _7Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _21Day_Button.IsEnabled = false;
                        _21Day_Button.Visibility = System.Windows.Visibility.Hidden;
                        _21Day = true;

                        Day1_label.IsEnabled = true;
                        Day1_label.Visibility = System.Windows.Visibility.Visible;
                        Day1_TextBox.IsEnabled = true;
                        Day1_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day2_label.IsEnabled = true;
                        Day2_label.Visibility = System.Windows.Visibility.Visible;
                        Day2_TextBox.IsEnabled = true;
                        Day2_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day3_label.IsEnabled = true;
                        Day3_label.Visibility = System.Windows.Visibility.Visible;
                        Day3_TextBox.IsEnabled = true;
                        Day3_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day4_label.IsEnabled = true;
                        Day4_label.Visibility = System.Windows.Visibility.Visible;
                        Day4_TextBox.IsEnabled = true;
                        Day4_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day5_label.IsEnabled = true;
                        Day5_label.Visibility = System.Windows.Visibility.Visible;
                        Day5_TextBox.IsEnabled = true;
                        Day5_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day6_label.IsEnabled = true;
                        Day6_label.Visibility = System.Windows.Visibility.Visible;
                        Day6_TextBox.IsEnabled = true;
                        Day6_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day7_label.IsEnabled = true;
                        Day7_label.Visibility = System.Windows.Visibility.Visible;
                        Day7_TextBox.IsEnabled = true;
                        Day7_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day8_label.IsEnabled = true;
                        Day8_label.Visibility = System.Windows.Visibility.Visible;
                        Day8_TextBox.IsEnabled = true;
                        Day8_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day9_label.IsEnabled = true;
                        Day9_label.Visibility = System.Windows.Visibility.Visible;
                        Day9_TextBox.IsEnabled = true;
                        Day9_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day10_label.IsEnabled = true;
                        Day10_label.Visibility = System.Windows.Visibility.Visible;
                        Day10_TextBox.IsEnabled = true;
                        Day10_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day11_label.IsEnabled = true;
                        Day11_label.Visibility = System.Windows.Visibility.Visible;
                        Day11_TextBox.IsEnabled = true;
                        Day11_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day12_label.IsEnabled = true;
                        Day12_label.Visibility = System.Windows.Visibility.Visible;
                        Day12_TextBox.IsEnabled = true;
                        Day12_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day13_label.IsEnabled = true;
                        Day13_label.Visibility = System.Windows.Visibility.Visible;
                        Day13_TextBox.IsEnabled = true;
                        Day13_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day14_label.IsEnabled = true;
                        Day14_label.Visibility = System.Windows.Visibility.Visible;
                        Day14_TextBox.IsEnabled = true;
                        Day14_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day15_label.IsEnabled = true;
                        Day15_label.Visibility = System.Windows.Visibility.Visible;
                        Day15_TextBox.IsEnabled = true;
                        Day15_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day16_label.IsEnabled = true;
                        Day16_label.Visibility = System.Windows.Visibility.Visible;
                        Day16_TextBox.IsEnabled = true;
                        Day16_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day17_label.IsEnabled = true;
                        Day17_label.Visibility = System.Windows.Visibility.Visible;
                        Day17_TextBox.IsEnabled = true;
                        Day17_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day18_label.IsEnabled = true;
                        Day18_label.Visibility = System.Windows.Visibility.Visible;
                        Day18_TextBox.IsEnabled = true;
                        Day18_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day19_label.IsEnabled = true;
                        Day19_label.Visibility = System.Windows.Visibility.Visible;
                        Day19_TextBox.IsEnabled = true;
                        Day19_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day20_label.IsEnabled = true;
                        Day20_label.Visibility = System.Windows.Visibility.Visible;
                        Day20_TextBox.IsEnabled = true;
                        Day20_TextBox.Visibility = System.Windows.Visibility.Visible;

                        Day21_label.IsEnabled = true;
                        Day21_label.Visibility = System.Windows.Visibility.Visible;
                        Day21_TextBox.IsEnabled = true;
                        Day21_TextBox.Visibility = System.Windows.Visibility.Visible;
                    }
                }
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
                                    usernameOfUser = username;
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
        private static bool valChange;
        private void resetVal(object sender, RoutedEventArgs e)
        {
            _1Day_Button.IsEnabled = true;
            _1Day_Button.Visibility = System.Windows.Visibility.Visible;
            _7Day_Button.IsEnabled = true;
            _7Day_Button.Visibility = System.Windows.Visibility.Visible;
            _21Day_Button.IsEnabled = true;
            _21Day_Button.Visibility = System.Windows.Visibility.Visible;
            _21Day = false;
            _7Day = false;
            _1Day = false;

            Day1_label.IsEnabled = false;
            Day1_label.Visibility = System.Windows.Visibility.Hidden;
            Day1_TextBox.IsEnabled = false;
            Day1_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day2_label.IsEnabled = false;
            Day2_label.Visibility = System.Windows.Visibility.Hidden;
            Day2_TextBox.IsEnabled = false;
            Day2_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day3_label.IsEnabled = false;
            Day3_label.Visibility = System.Windows.Visibility.Hidden;
            Day3_TextBox.IsEnabled = false;
            Day3_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day4_label.IsEnabled = false;
            Day4_label.Visibility = System.Windows.Visibility.Hidden;
            Day4_TextBox.IsEnabled = false;
            Day4_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day5_label.IsEnabled = false;
            Day5_label.Visibility = System.Windows.Visibility.Hidden;
            Day5_TextBox.IsEnabled = false;
            Day5_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day6_label.IsEnabled = false;
            Day6_label.Visibility = System.Windows.Visibility.Hidden;
            Day6_TextBox.IsEnabled = false;
            Day6_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day7_label.IsEnabled = false;
            Day7_label.Visibility = System.Windows.Visibility.Hidden;
            Day7_TextBox.IsEnabled = false;
            Day7_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day8_label.IsEnabled = false;
            Day8_label.Visibility = System.Windows.Visibility.Hidden;
            Day8_TextBox.IsEnabled = false;
            Day8_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day9_label.IsEnabled = false;
            Day9_label.Visibility = System.Windows.Visibility.Hidden;
            Day9_TextBox.IsEnabled = false;
            Day9_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day10_label.IsEnabled = false;
            Day10_label.Visibility = System.Windows.Visibility.Hidden;
            Day10_TextBox.IsEnabled = false;
            Day10_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day11_label.IsEnabled = false;
            Day11_label.Visibility = System.Windows.Visibility.Hidden;
            Day11_TextBox.IsEnabled = false;
            Day11_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day12_label.IsEnabled = false;
            Day12_label.Visibility = System.Windows.Visibility.Hidden;
            Day12_TextBox.IsEnabled = false;
            Day12_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day13_label.IsEnabled = false;
            Day13_label.Visibility = System.Windows.Visibility.Hidden;
            Day13_TextBox.IsEnabled = false;
            Day13_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day14_label.IsEnabled = false;
            Day14_label.Visibility = System.Windows.Visibility.Hidden;
            Day14_TextBox.IsEnabled = true;
            Day14_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day15_label.IsEnabled = false;
            Day15_label.Visibility = System.Windows.Visibility.Hidden;
            Day15_TextBox.IsEnabled = false;
            Day15_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day16_label.IsEnabled = false;
            Day16_label.Visibility = System.Windows.Visibility.Hidden;
            Day16_TextBox.IsEnabled = false;
            Day16_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day17_label.IsEnabled = false;
            Day17_label.Visibility = System.Windows.Visibility.Hidden;
            Day17_TextBox.IsEnabled = false;
            Day17_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day18_label.IsEnabled = false;
            Day18_label.Visibility = System.Windows.Visibility.Hidden;
            Day18_TextBox.IsEnabled = false;
            Day18_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day19_label.IsEnabled = false;
            Day19_label.Visibility = System.Windows.Visibility.Hidden;
            Day19_TextBox.IsEnabled = false;
            Day19_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day20_label.IsEnabled = false;
            Day20_label.Visibility = System.Windows.Visibility.Hidden;
            Day20_TextBox.IsEnabled = false;
            Day20_TextBox.Visibility = System.Windows.Visibility.Hidden;

            Day21_label.IsEnabled = false;
            Day21_label.Visibility = System.Windows.Visibility.Hidden;
            Day21_TextBox.IsEnabled = false;
            Day21_TextBox.Visibility = System.Windows.Visibility.Hidden;
        }
        private void save_button_click(object sender, RoutedEventArgs e)
        {
            valChange = true;
            valuesList.Clear();
            if (_1Day)
            {
                try
                {
                    valuesList.Insert(0, goal_textBox.Text);
                    double day1 = Convert.ToDouble(Day1_TextBox.Text);
                    valuesList.Insert(1, Convert.ToString(day1));
                    double total = day1;
                    TotalAmount_Label_.Content = "$" + total;
                    valuesList.Insert(2, Convert.ToString("$" + total));
                    valuesList.Insert(3, "1True");
                }
                catch (Exception)
                {
                    MessageBox.Show("You can't have letters in your value!");
                }
            }
            else if (_7Day)
            {
                try
                {
                    valuesList.Insert(0, goal_textBox.Text);
                    double day1 = Convert.ToDouble(Day1_TextBox.Text);
                    valuesList.Insert(1, Convert.ToString(day1));
                    double day2 = Convert.ToDouble(Day2_TextBox.Text);
                    valuesList.Insert(2, Convert.ToString(day2));
                    double day3 = Convert.ToDouble(Day3_TextBox.Text);
                    valuesList.Insert(3, Convert.ToString(day3));
                    double day4 = Convert.ToDouble(Day4_TextBox.Text);
                    valuesList.Insert(4, Convert.ToString(day4));
                    double day5 = Convert.ToDouble(Day5_TextBox.Text);
                    valuesList.Insert(5, Convert.ToString(day5));
                    double day6 = Convert.ToDouble(Day6_TextBox.Text);
                    valuesList.Insert(6, Convert.ToString(day6));
                    double day7 = Convert.ToDouble(Day7_TextBox.Text);
                    valuesList.Insert(7, Convert.ToString(day7));
                    double total = day1 + day2 + day3 + day4 + day5 + day6 + day7;
                    TotalAmount_Label_.Content = "$" + total;
                    valuesList.Insert(8, Convert.ToString("$" + total));
                    valuesList.Insert(9, "7True");
                }
                catch (Exception)
                {
                    MessageBox.Show("You can't have letters in your value!");
                }
            }
            else if (_21Day)
            {
                try
                {
                    valuesList.Insert(0, goal_textBox.Text);
                    double day1 = Convert.ToDouble(Day1_TextBox.Text);
                    valuesList.Insert(1, Convert.ToString(day1));
                    double day2 = Convert.ToDouble(Day2_TextBox.Text);
                    valuesList.Insert(2, Convert.ToString(day2));
                    double day3 = Convert.ToDouble(Day3_TextBox.Text);
                    valuesList.Insert(3, Convert.ToString(day3));
                    double day4 = Convert.ToDouble(Day4_TextBox.Text);
                    valuesList.Insert(4, Convert.ToString(day4));
                    double day5 = Convert.ToDouble(Day5_TextBox.Text);
                    valuesList.Insert(5, Convert.ToString(day5));
                    double day6 = Convert.ToDouble(Day6_TextBox.Text);
                    valuesList.Insert(6, Convert.ToString(day6));
                    double day7 = Convert.ToDouble(Day7_TextBox.Text);
                    valuesList.Insert(7, Convert.ToString(day7));
                    double day8 = Convert.ToDouble(Day1_TextBox.Text);
                    valuesList.Insert(8, Convert.ToString(day8));
                    double day9 = Convert.ToDouble(Day2_TextBox.Text);
                    valuesList.Insert(9, Convert.ToString(day9));
                    double day10 = Convert.ToDouble(Day3_TextBox.Text);
                    valuesList.Insert(10, Convert.ToString(day10));
                    double day11 = Convert.ToDouble(Day4_TextBox.Text);
                    valuesList.Insert(11, Convert.ToString(day11));
                    double day12 = Convert.ToDouble(Day5_TextBox.Text);
                    valuesList.Insert(12, Convert.ToString(day12));
                    double day13 = Convert.ToDouble(Day6_TextBox.Text);
                    valuesList.Insert(13, Convert.ToString(day13));
                    double day14 = Convert.ToDouble(Day7_TextBox.Text);
                    valuesList.Insert(14, Convert.ToString(day14));
                    double day15 = Convert.ToDouble(Day1_TextBox.Text);
                    valuesList.Insert(15, Convert.ToString(day15));
                    double day16 = Convert.ToDouble(Day2_TextBox.Text);
                    valuesList.Insert(16, Convert.ToString(day16));
                    double day17 = Convert.ToDouble(Day3_TextBox.Text);
                    valuesList.Insert(17, Convert.ToString(day17));
                    double day18 = Convert.ToDouble(Day4_TextBox.Text);
                    valuesList.Insert(18, Convert.ToString(day18));
                    double day19 = Convert.ToDouble(Day5_TextBox.Text);
                    valuesList.Insert(19, Convert.ToString(day19));
                    double day20 = Convert.ToDouble(Day6_TextBox.Text);
                    valuesList.Insert(20, Convert.ToString(day20));
                    double day21 = Convert.ToDouble(Day7_TextBox.Text);
                    valuesList.Insert(21, Convert.ToString(day21));
                    double total = day1 + day2 + day3 + day4 + day5 + day6 + day7 + day8 + day9 + day10 + day11 + day12 + day13 + day14 + day15 + day16 + day17 + day18 + day19 + day20 + day21;
                    
                    TotalAmount_Label_.Content = "$" + total;
                    valuesList.Insert(22, Convert.ToString("$" + total));
                    valuesList.Insert(23, "21True");
                }
                catch (Exception)
                {
                    MessageBox.Show("You can't have letters in your value!");
                }
            }
            saveValuesList();
            
        }
        private static void openAccount1()
        {
            
        }
        private static void openAccount7()
        {

        }
        private static void openAccount21()
        {

        }
        static bool _1Day;
        static bool _7Day;
        static bool _21Day;
        private void _1Day_Click(object sender, RoutedEventArgs e)
        {
            
            
            Save_button.IsEnabled = true;
            Save_button.Visibility = System.Windows.Visibility.Visible;
            reset_button.IsEnabled = true;
            reset_button.Visibility = System.Windows.Visibility.Visible;

            _1Day_Button.IsEnabled = false;
            _1Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _7Day_Button.IsEnabled = false;
            _7Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _21Day_Button.IsEnabled = false;
            _21Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _1Day = true;

            Day1_label.IsEnabled = true;
            Day1_label.Visibility = System.Windows.Visibility.Visible;
            Day1_TextBox.IsEnabled = true;
            Day1_TextBox.Visibility = System.Windows.Visibility.Visible;

            
        }
        private void _7Day_Click(object sender, RoutedEventArgs e)
        {
            Save_button.IsEnabled = true;
            Save_button.Visibility = System.Windows.Visibility.Visible;
            reset_button.IsEnabled = true;
            reset_button.Visibility = System.Windows.Visibility.Visible;

            _1Day_Button.IsEnabled = false;
            _1Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _7Day_Button.IsEnabled = false;
            _7Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _21Day_Button.IsEnabled = false;
            _21Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _7Day = true;

            Day1_label.IsEnabled = true;
            Day1_label.Visibility = System.Windows.Visibility.Visible;
            Day1_TextBox.IsEnabled = true;
            Day1_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day2_label.IsEnabled = true;
            Day2_label.Visibility = System.Windows.Visibility.Visible;
            Day2_TextBox.IsEnabled = true;
            Day2_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day3_label.IsEnabled = true;
            Day3_label.Visibility = System.Windows.Visibility.Visible;
            Day3_TextBox.IsEnabled = true;
            Day3_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day4_label.IsEnabled = true;
            Day4_label.Visibility = System.Windows.Visibility.Visible;
            Day4_TextBox.IsEnabled = true;
            Day4_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day5_label.IsEnabled = true;
            Day5_label.Visibility = System.Windows.Visibility.Visible;
            Day5_TextBox.IsEnabled = true;
            Day5_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day6_label.IsEnabled = true;
            Day6_label.Visibility = System.Windows.Visibility.Visible;
            Day6_TextBox.IsEnabled = true;
            Day6_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day7_label.IsEnabled = true;
            Day7_label.Visibility = System.Windows.Visibility.Visible;
            Day7_TextBox.IsEnabled = true;
            Day7_TextBox.Visibility = System.Windows.Visibility.Visible;
        }
        private void _21Day_Click(object sender, RoutedEventArgs e)
        {
            Save_button.IsEnabled = true;
            Save_button.Visibility = System.Windows.Visibility.Visible;
            reset_button.IsEnabled = true;
            reset_button.Visibility = System.Windows.Visibility.Visible;

            _1Day_Button.IsEnabled = false;
            _1Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _7Day_Button.IsEnabled = false;
            _7Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _21Day_Button.IsEnabled = false;
            _21Day_Button.Visibility = System.Windows.Visibility.Hidden;
            _21Day = true;

            Day1_label.IsEnabled = true;
            Day1_label.Visibility = System.Windows.Visibility.Visible;
            Day1_TextBox.IsEnabled = true;
            Day1_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day2_label.IsEnabled = true;
            Day2_label.Visibility = System.Windows.Visibility.Visible;
            Day2_TextBox.IsEnabled = true;
            Day2_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day3_label.IsEnabled = true;
            Day3_label.Visibility = System.Windows.Visibility.Visible;
            Day3_TextBox.IsEnabled = true;
            Day3_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day4_label.IsEnabled = true;
            Day4_label.Visibility = System.Windows.Visibility.Visible;
            Day4_TextBox.IsEnabled = true;
            Day4_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day5_label.IsEnabled = true;
            Day5_label.Visibility = System.Windows.Visibility.Visible;
            Day5_TextBox.IsEnabled = true;
            Day5_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day6_label.IsEnabled = true;
            Day6_label.Visibility = System.Windows.Visibility.Visible;
            Day6_TextBox.IsEnabled = true;
            Day6_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day7_label.IsEnabled = true;
            Day7_label.Visibility = System.Windows.Visibility.Visible;
            Day7_TextBox.IsEnabled = true;
            Day7_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day8_label.IsEnabled = true;
            Day8_label.Visibility = System.Windows.Visibility.Visible;
            Day8_TextBox.IsEnabled = true;
            Day8_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day9_label.IsEnabled = true;
            Day9_label.Visibility = System.Windows.Visibility.Visible;
            Day9_TextBox.IsEnabled = true;
            Day9_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day10_label.IsEnabled = true;
            Day10_label.Visibility = System.Windows.Visibility.Visible;
            Day10_TextBox.IsEnabled = true;
            Day10_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day11_label.IsEnabled = true;
            Day11_label.Visibility = System.Windows.Visibility.Visible;
            Day11_TextBox.IsEnabled = true;
            Day11_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day12_label.IsEnabled = true;
            Day12_label.Visibility = System.Windows.Visibility.Visible;
            Day12_TextBox.IsEnabled = true;
            Day12_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day13_label.IsEnabled = true;
            Day13_label.Visibility = System.Windows.Visibility.Visible;
            Day13_TextBox.IsEnabled = true;
            Day13_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day14_label.IsEnabled = true;
            Day14_label.Visibility = System.Windows.Visibility.Visible;
            Day14_TextBox.IsEnabled = true;
            Day14_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day15_label.IsEnabled = true;
            Day15_label.Visibility = System.Windows.Visibility.Visible;
            Day15_TextBox.IsEnabled = true;
            Day15_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day16_label.IsEnabled = true;
            Day16_label.Visibility = System.Windows.Visibility.Visible;
            Day16_TextBox.IsEnabled = true;
            Day16_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day17_label.IsEnabled = true;
            Day17_label.Visibility = System.Windows.Visibility.Visible;
            Day17_TextBox.IsEnabled = true;
            Day17_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day18_label.IsEnabled = true;
            Day18_label.Visibility = System.Windows.Visibility.Visible;
            Day18_TextBox.IsEnabled = true;
            Day18_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day19_label.IsEnabled = true;
            Day19_label.Visibility = System.Windows.Visibility.Visible;
            Day19_TextBox.IsEnabled = true;
            Day19_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day20_label.IsEnabled = true;
            Day20_label.Visibility = System.Windows.Visibility.Visible;
            Day20_TextBox.IsEnabled = true;
            Day20_TextBox.Visibility = System.Windows.Visibility.Visible;

            Day21_label.IsEnabled = true;
            Day21_label.Visibility = System.Windows.Visibility.Visible;
            Day21_TextBox.IsEnabled = true;
            Day21_TextBox.Visibility = System.Windows.Visibility.Visible;
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
        private static void saveValuesList()
        {

            TextWriter saver = new StreamWriter(usernameOfUser + "Values.txt");

            foreach (String deatils in valuesList)
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
