using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kontynuować grę? T/N");
            
            var yes = Console.ReadLine();
            Console.Clear();
            var myLSgame = new LSGame();
            var myArray = new Tablica();
            if (yes.ToLower()=="t")
            {
                myArray = myLSgame.Load();

            }
            else
            {
            Console.WriteLine("Podaj rozmiar tablicy");

            var size = int.Parse(Console.ReadLine());
            myArray = new Tablica(size);

            Console.Clear();
            myArray.FillTab();

            }
            

            myArray.printArray();

            while (true)
            {
                var myString = Console.ReadLine();

                if (myString != "")
                {
                    break;
                }
                myArray.ProcessArray();
                Console.Clear();

                myArray.printArray();
                
            }

            myLSgame.Save(myArray);
            
        }
    }
}
