using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {

            Numbers numbers = InitializeNumbers();

            bool readConsole = true;
            while (readConsole)
            {
                Console.WriteLine("(N)ächste / (V)orhergehende / (A)bbruch");
                string selection = Console.ReadLine();

                if (selection.ToUpper() == "N")
                {
                    if (numbers.Next == null)
                    {
                        Console.WriteLine("Kein nächstes vorhanden");
                        Console.WriteLine();
                    }
                        
                    else
                    {
                        numbers = numbers.Next;
                        WriteNumbers(numbers);
                        Console.WriteLine();
                    }
                }

                else if (selection.ToUpper() == "V")
                {
                    if (numbers.Previous == null)
                    {
                        Console.WriteLine("Kein vorhergehendes vorhanden");
                        Console.WriteLine();
                    }

                    else
                    {
                        numbers = numbers.Previous;
                        WriteNumbers(numbers);
                        Console.WriteLine();
                    }
                }

                else if (selection.ToUpper() == "A")
                { 
                    readConsole = false;
                }
            }
        }

        private static Numbers InitializeNumbers()
        {
            //Erste Numbers anlegen
            Numbers number = new Numbers(null, 1);

            //9 weitere Numbers dazugeben
            for (int i1 = 2; i1 <= 10; i1++)
                //Weitere Numbers dazugeben
                number = new Numbers(number, i1);

            //Zur ersten Numbers gehen
            while (number.Previous != null)
                number = number.Previous;

            return number;
        }

        private static void WriteNumbers(Numbers numbers)
        {
            Console.WriteLine(numbers.Number);
        }  
    }

    public class Numbers
    {
        public Numbers(Numbers previous, int number)
        {
            //Vorhergehende Numbers
            Previous = previous;

            //Zahlenwert dieser Instanz
            Number = number;

            //Wenn eine vorhergehende Numbers definiert ist: Die vorhergehende Numbers hat diese Numbers als nächste Numbers 
            if (previous != null)
            {
                previous.Next = this;
            }
        }

        public Numbers Previous;
        public Numbers Next;
        public int Number;
    }
}
