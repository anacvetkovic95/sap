using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservations
{
    class Program
    {
        static int maxSize;
        static int maxDay = 365;

        static int[,] reservations;
        static List<Reservation> listOfreservations = new List<Reservation>();

        public void startMethod()
        {
            string value = "";
            int choice = 1;

            Console.WriteLine("Welcome! :)\nPlease enter the size of your Hotel.");
            value = Console.ReadLine();
            foreach (char c in value)
            {
                if (!Char.IsDigit(c))
                {
                    Console.WriteLine("\nTHE VALUE YOU ENTERED IS NOT DIGIT!\n");
                    return;
                }
            }
            maxSize = Convert.ToInt32(value);
            reservations = new int[maxSize, maxDay];

            while (choice != 0)
            {
                Console.WriteLine("\nWould you like to make a reservation?\na) Enter number 1 to make reservation.\nb) Enter number 0 to exit.\n");

                Console.WriteLine("Value:");
                value = Console.ReadLine();
                foreach (char c in value)
                {
                    if (!Char.IsDigit(c)) {
                        Console.WriteLine("\nTHE VALUE YOU ENTERED IS NOT DIGIT!\n");
                        return;
                    }
                }
                choice = Convert.ToInt32(value);

                if (choice != 1 && choice != 0)
                {
                    Console.WriteLine("\nTHE VALUE YOU ENTERED DOES NOT EXIST AS OPTION.\nCHOOSE OPTION 1 OR 0\n");
                    continue;
                }

                if (choice == 1)
                {
                    Reservation r = new Reservation(maxSize, -1, -1, "");

                    Console.WriteLine("\n****You can now make your reservation!****\nEnter your start and end day.\n");

                    Console.WriteLine("Start day:");
                    value = Console.ReadLine();
                    foreach (char c in value)
                    {
                        if (!Char.IsDigit(c))
                        {
                            Console.WriteLine("\nTHE VALUE YOU ENTERED IS NOT DIGIT!\n");
                            return;
                        }
                    }
                    r.StartDay = Convert.ToInt32(value);

                    Console.WriteLine("End day:");
                    value = Console.ReadLine();
                    foreach (char c in value)
                    {
                        if (!Char.IsDigit(c))
                        {
                            Console.WriteLine("\nTHE VALUE YOU ENTERED IS NOT DIGIT!\n");
                            return;
                        }
                    }
                    r.EndDay = Convert.ToInt32(value);
                    
                    setResult(r);
                    listOfreservations.Add(r);

                    Console.WriteLine("\n\t\tStartDate\tEndDate\tResult: Accept / Decline");
                    Console.WriteLine("_________________________________________________________________________\n");

                    int counter = 1;
                    foreach (Reservation res in listOfreservations)
                    {
                        Console.WriteLine("Booking " + counter + "\t" + res.StartDay + "\t\t" + res.EndDay + "\t\t" + res.Result);
                        Console.WriteLine("_________________________________________________________________________\n");
                        counter++;
                    }

                    //PRINT RESERVATIONS ARRAY

                    //for (int i = 0; i < maxSize; i++)
                    //{
                    //    for (int j = 0; j < maxDay; j++)
                    //    {
                    //        Console.Write(reservations[i,j]+"\t");
                    //    }
                    //    Console.WriteLine("\n");
                    //}
                }
            }
        }

        public void setResult(Reservation r)
        {
            int counter;
            if (r.StartDay < 0 || r.StartDay > maxDay || r.EndDay > maxDay || r.EndDay < 0 || r.EndDay < r.StartDay)
            {
                r.Result = "Decline";
                return;
            }

            for (int room = 0; room < r.Size; room++)
            {
                counter = r.StartDay;
                for (int day = r.StartDay; day <= r.EndDay; day++)
                {
                    if (reservations[room, day] != 0)
                    {
                        if (room < r.Size-1 && r.StartDay > 0) {
                            if (reservations[room + 1, day] == 0 && reservations[room, day + 1] == 0 && reservations[room, day - 1] == 0)
                            {
                                reservations[room, day] = 0;
                                reservations[room + 1, day] = 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (counter == r.EndDay)
                    {
                        while (counter >= r.StartDay)
                        {
                            reservations[room, counter] = 1;
                            counter--;
                        }
                        r.Result = "Accept";
                        return;
                    }
                    if (counter < r.EndDay)
                    {
                        counter++;
                    }
                }
            }
            r.Result = "Decline";
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.startMethod();
        }
    }
}
