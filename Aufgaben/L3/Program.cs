using System;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Int32.Parse(args[0]);
            int fromBase = Int32.Parse(args[1]);
            int toBase = Int32.Parse(args[2]);
            
            Console.WriteLine($"Zahl: {number} von 10er Basis zu 6er Basis konvertieren = " + ConvertDecimalToHexal(number) );
            Console.WriteLine($"Zahl: {number} von 6er Basis zu 10er Basis konvertieren = " + ConvertHexalToDezimal(number) );
            Console.WriteLine($"Zahl: {number} von 10er zu {toBase}er Basis konvertieren = " + ConvertToBaseFromDecimal(toBase, number) );
            Console.WriteLine($"Zahl: {number} von {fromBase}er  zu 10er Basis konvertieren = " + ConvertToDecimalFromBase(fromBase, number) );
            Console.WriteLine($"Zahl: {number} von {fromBase}er zu {toBase}er Basis konvertieren = " + ConvertNumberToBaseFromBase(number, toBase, fromBase) );

        }


        static int ConvertDecimalToHexal(int dec){
            
            int remainder;
            string result = string.Empty;

            if (0 <= dec && dec <= 1023){
                while (dec > 0)
                {
                    remainder = dec % 6;
                    dec /= 6;
                    result = remainder.ToString() + result;
                 
                }
            }else{
                result = "-1";
            }
             return Int32.Parse(result);
        }

         static int ConvertHexalToDezimal(int hexal){
            
            String hex = hexal.ToString();
            char[] characters_hex = hex.ToCharArray();
            Array.Reverse(characters_hex);
            String[] arr = new String[4];
            int[] solution = new int [4]; 
            int sum = 0;
                for ( int i = 0; i<characters_hex.Length;i++){

                    arr[i] = characters_hex[i].ToString();
                    solution[i] =  Int32.Parse(arr[i]);
                    solution[i] = solution[i]*(int)Math.Pow(6, i);
                    sum += solution[i];
                }
            
            return sum;
        }

       static int ConvertToBaseFromDecimal(int toBase, int dec){
            
            int remainder;
            string result = string.Empty;

            if (0 <= dec && dec <= 1023){
                while (dec > 0)
                {
                    remainder = dec % toBase;
                    dec /= toBase;
                    result = remainder.ToString() + result;
                 
                }
            }else{
                result = "-1";
            }
             return Int32.Parse(result);
        
        }

        static int ConvertToDecimalFromBase(int fromBase, int number){
            
            String hex = number.ToString();
            char[] characters_hex = hex.ToCharArray();
            Array.Reverse(characters_hex);
            String[] arr = new String[4];
            int[] solution = new int [4]; 
            int sum = 0;
                for ( int i = 0; i<characters_hex.Length;i++){

                    arr[i] = characters_hex[i].ToString();
                    solution[i] =  Int32.Parse(arr[i]);
                    solution[i] = solution[i]*(int)Math.Pow(fromBase, i);
                    sum += solution[i];
                }
            
            return sum;
        
        }

       static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase){
                
            if( fromBase>=2 && fromBase<=10 && toBase>=2 && toBase<=10) {
              int convertedtoDecimal =  ConvertToDecimalFromBase(fromBase, number);
            
              int  convertedtoend =   ConvertToBaseFromDecimal(toBase, convertedtoDecimal);

               return convertedtoend;
            }
           return -1;
       }

    }
}
