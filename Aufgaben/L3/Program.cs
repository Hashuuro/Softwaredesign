using System;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Hexalzahl: "+ ConvertDecimalToHexal(15));
           Console.WriteLine("Dezimalzahl: "+ ConvertHexalToDezimal(1023));
           Console.WriteLine("Neue Zahl: "+ ConvertToBaseFromDecimal(6,15));
        }


        static int ConvertDecimalToHexal(int dec){
            
           int division_hex = dec/6;
           int remainder_hex = dec%6;
           int Solution_hex = division_hex*10+remainder_hex; 
           return Solution_hex;
        }

         static int ConvertHexalToDezimal(int hexal){
            
           int division_dec = hexal/10;
           int remainder_dec = hexal%10;
           int Solution_dec = division_dec*6+remainder_dec; 
           return Solution_dec;
        
        }

       static int ConvertToBaseFromDecimal(int toBase, int dec){
            
            int division_toBase = dec/toBase;
           int remainder_toBase = dec%toBase;
           int Solution_toBase = division_toBase*10+remainder_toBase; 
           return Solution_toBase;
            
        
        }

    }
}
