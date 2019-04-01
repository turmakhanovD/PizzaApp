using static System.Console;

namespace RegistrationSystem
{
    public class CheckPhone
    {
        private const int PHONE_SYM_NUMBER = 10;
        public void Check(ref string _phoneNumber)
        {
            _phoneNumber = ReadLine();
            WriteLine();
            while (_phoneNumber.Length <= PHONE_SYM_NUMBER)
            {
                Write("Sorry, write your phone correctly \n");
                Write("Phone number: ");
                _phoneNumber = ReadLine();

            }
        }
    }
}