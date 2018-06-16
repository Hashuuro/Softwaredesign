using System;

namespace EmailChecker
{
    public class Program
    {
        public static bool IsEmailAddress(string emailAddress)
        {
            int iAt = emailAddress.IndexOf('@');
            int iDot = emailAddress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);
        } 

        static void TestIsEmailAddress(string emailAddress, bool expected)
        {
            bool result = IsEmailAddress(emailAddress);
            if(result == expected)
            {
                 Console.WriteLine("Success - " + emailAddress + " email address is valid. ->" + expected);
            }
            else
            {
                Console.WriteLine("Test failed - "+emailAddress + " something went wrong. ->" + result + "; expected: " + expected);
            };
        }

        static void Main(string[] args)
        {
           //Produktionscode
        } 
    }
}
