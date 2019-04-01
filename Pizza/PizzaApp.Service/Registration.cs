using System;
using static System.Console;
using PizzaApp.Service;

namespace RegistrationSystem
{
    public class Registration
    {
        #region fields
        private string _login;
        private string _password;
        private String _fullName;
        private int _age;
        private string _repeatPassword;
        private string _phoneNumber;
        private Random rnd = new Random(10000);
        private int _code;
        private int _enterCode;
        private const int _NORMAL_PASSWORD_NUM = 6;
        #endregion
        User user = new User();
        MessageSender messageSender = new MessageSender();
        CheckPhone checkPhone = new CheckPhone();
        CheckPassword checkPassword = new CheckPassword();



        public void StartRegistration()
        {

            WriteLine("\t\t\t\tREGISTRATION");
   
            Write("Login: ");
            _login = ReadLine();

            while (string.IsNullOrEmpty(_login) || _login.Length < _NORMAL_PASSWORD_NUM)
            {
                Write("Sorry, enter your login correctly!\n");
                Write("Login: ");
                _login = ReadLine();
            }
            user.Login = _login;

            Write("Password: ");
            checkPassword.Check(ref _password, ref _repeatPassword);
            user.Password = _password;

            Write("Phone number: ");
            checkPhone.Check(ref _phoneNumber);
           // user.PhoneNumber = _phoneNumber;

            _code = rnd.Next(9999);

            try
            {
                messageSender.SendMessage(_phoneNumber, _code);
            }
            catch
            {
                Write("Something went wrong! Try again.");
                Write("Phone number: ");
                checkPhone.Check(ref _phoneNumber);
            }
            user.PhoneNumber = _phoneNumber;

            Write("Enter code: ");
            _enterCode = int.Parse(ReadLine());

            if (_enterCode == _code)
            {
                Write("Registration successfully completed!");
            }
            else
                while (!(_enterCode == _code))
                {

                    Write("Something went wrong!" +
                      "Enter code: ");
                    _enterCode = int.Parse(ReadLine());
                }

            UserTableService userTableService = new UserTableService();
            userTableService.InsertUser(user);
            
        }
    }
}