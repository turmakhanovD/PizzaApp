using System;
using static System.Console;

namespace RegistrationSystem
{
    public class CheckPassword
    {
        private const int _NORMAL_PASSWORD_NUM = 6;
        public static string HidePassword(ref string password)
        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);

                if (Char.IsNumber(key.KeyChar) || Char.IsLetter(key.KeyChar))//||Char.IsControl(key.KeyChar))
                {
                    Console.Write("*");
                }
                code += key.KeyChar;
            } while (key.Key != ConsoleKey.Enter);
            password = code;
            return code;

        }

        public bool IsntUpper(string str)
        {
            if (str.Equals(str.ToLower()))
                return true;
            return false;
        }

        public void Check(ref string _password, ref string _repeatPassword)
        {
            HidePassword(ref _password);
            WriteLine();

            while (string.IsNullOrEmpty(_password) || _password.Length < _NORMAL_PASSWORD_NUM || IsntUpper(_password))
            {

                Write("Sorry, your password is not safety! at less |1 number | 1 high letter\n ");
                Write("Password: ");
                //_password = ReadLine();
                HidePassword(ref _password);
                WriteLine();
            }

            Write("Repeat your password: ");
            HidePassword(ref _repeatPassword);
            WriteLine();

            while (_repeatPassword != _password)
            {
                Write("Sorry, your password is not equal, please, try again!\n");
                Write("Repeat your password: ");

                HidePassword(ref _repeatPassword);
                WriteLine();
            }

        }


    }
}