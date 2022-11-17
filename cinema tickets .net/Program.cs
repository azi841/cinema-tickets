using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_tickets.net
{
    internal class Program
    {

        static int rows = 3;
        static int cols = 5;


        static void Main(string[] args)
        {
            int n, cn, cases;
            bool[,] seats = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j ++)
                {
                    seats[i , j] = false;
                }
            }
            SeatsR(seats, 0);

            char seatRow;

            do { 
                Console.WriteLine("\n\n_______________________________________________________________________________________________\n");
                Console.WriteLine("\n1.Random reserve \n2.Reserve\n3.Cancel reservation \n4.Show seats \n5.Close");
                cases = Convert.ToInt32(Console.ReadLine());

                switch (cases) {
                    case 1:
                        Console.WriteLine("Enter number of seats:");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n > cols)
                        {
                            Console.WriteLine("You exceeded the maximum number of reservations per person, please try again another time.");
                            continue;
                        }
                        SeatsR(seats, n);
                        break;
                    case 2:
                        showSeats(seats);
                        Console.WriteLine("\nChoose row you want: \nA B C");
                        seatRow = Console.ReadLine()[0];
                        if (seatRow == 'a') seatRow = 'A';
                        if (seatRow == 'b') seatRow = 'B';
                        if (seatRow=='c') seatRow = 'C';   
                        Console.WriteLine("Chose seat you want: \n{0}1 {0}2 {0}3 {0}4 {0}5", seatRow);
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n");
                        Reserve(seats, n, seatRow);
                        break;
                    case 3:
                        SeatsR(seats, 0);
                        Console.WriteLine("\nEnter row to cancel reservation(A, B or C): ");
                        seatRow = Console.ReadLine()[0];
                        if (seatRow == 'a') seatRow = 'A';
                        if (seatRow == 'b') seatRow = 'B';
                        if (seatRow=='c') seatRow = 'C';   
                        Console.WriteLine("Chose seat you want: \n{0}1 {0}2 {0}3 {0}4 {0}5", seatRow);
                        cn = Convert.ToInt32(Console.ReadLine());
                        CancelReservation(seats, cn, seatRow);
                        break;
                    case 4:
                        Console.WriteLine("\n");
                        showSeats(seats);
                        break;
                    default:
                        Console.WriteLine("Application closed.");
                        break;
                }
            }while (cases < 5);


        }


        static void Reserve(bool[,] seats, int n, char seatRow)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            switch (seatRow)
            {
                case 'A':
                    if (seats[0,n-1]==true) Console.WriteLine("\nSeat already reserved!\n");
                    else seats[0, n-1] = true;
                    break;
                case 'B':
                    if (seats[1,n-1]==true) Console.WriteLine("\nSeat already reserved!\n");
                    else seats[1,n-1] = true;
                    break;
                case 'C':
                    if (seats[2,n-1]==true) Console.WriteLine("\nSeat already reserved!\n");
                    else seats[2,n-1] = true;
                    break;
                default:
                    break;
            }
            Console.ResetColor();
            showSeats(seats);
        }
       
        static void SeatsR(bool[,] seats, int n)
        {
            int randArr1, randArr2;
            Random rnd = new Random();
            int count, freecount, overallcount;
            overallcount = 0;


            if (n > 0)  {
                do {
                    freecount = 0;
                    count = 0;
                    randArr1 = rnd.Next(rows);
                    randArr2 = rnd.Next(cols);
                    if (randArr2 + n > cols)  continue;
                    
                    for (int i = 0; i < n; i++) {
                        if (seats[randArr1, randArr2 + i ] == true){
                            count++;
                            overallcount++;
                        }
                        if (seats[randArr1, randArr2] == false)
                            freecount++;
                    }
                    if (overallcount+n > 15) break;
                    if (count>0) continue;
                    break;
                } while (0==0);

                if (overallcount ==14) {
                    Console.WriteLine("\nAll seats are reserved!");
                    return;
                }
                if (freecount < n)
                {
                    Console.WriteLine("\nNot enough free space! Enter another number of seats: ");
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    seats[randArr1, randArr2 + i] = true;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                    {
                        if (seats[i, j] == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("A{0} ", j + 1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("A{0} ", j + 1);
                        }
                    }
                    else if (i == 1)
                    {
                        if (seats[i, j]==true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("B{0} ", j + 1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("B{0} ", j + 1);
                        }
                    }
                    else
                    {
                        if (seats[i, j] == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("C{0} ", j + 1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("C{0} ", j + 1);
                        }
                    }
                }
                Console.Write("\n");
            }
        }

        static void showSeats(bool[,] seats)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                    {
                        if (seats[i, j] == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("A{0} ", j + 1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("A{0} ", j + 1);
                        }
                    }
                    else if (i == 1)
                    {
                        if (seats[i, j]==true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("B{0} ", j + 1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("B{0} ", j + 1);
                        }
                    }
                    else
                    {
                        if (seats[i, j] == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("C{0} ", j + 1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("C{0} ", j + 1);
                        }
                    }
                }
                Console.Write("\n");
            }
        }

        static void CancelReservation(bool[,] seats, int cn, char seatRow)
        {
            if (cn < 6 || cn > 0)
            {
                switch (seatRow)
                {
                    case 'A':
                        seats[0,cn-1] = false;
                        break;
                    case 'B':
                        seats[1,cn-1] = false;
                        break;
                    case 'C':
                        seats[2, cn-1] = false;
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
