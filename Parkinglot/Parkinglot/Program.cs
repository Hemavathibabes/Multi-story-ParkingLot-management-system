using Parkinglot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Parkinglot
{


    class Program
    {

        static void Main(string[] args)
        {
            Parkingspace ps = new Parkingspace();
            while (true)
            {
                bool advance = false;

                Console.WriteLine("welcome to the vehicle parking system!!");
                Console.WriteLine("choose any one option");
                Console.WriteLine("1.Entry\n2.Exit & fee\n3.Advance booking\n4.cancel booking");

                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Do you have a advance booking yes/no");
                        String c = Console.ReadLine();
                        if (c == "yes")
                        {
                            ps.verifybooking();
                        }

                        else
                        {
                            ps.choosespot();
                        }
                        break;
                    case 2:

                        ps.exitvehicle();
                        break;
                    case 3:
                        Console.WriteLine("Welcome to advance booking!!");
                        advance = true;
                        ps.Advancebooking(advance);
                        break;
                    case 4:
                        Console.WriteLine("cancel booking");
                        ps.cancelbooking();
                        break;
                }
                Console.WriteLine("Do you want to continue? yes/no");
                string select = Console.ReadLine();
                if (select.ToLower() == "no" || select.ToLower() == "n")
                {
                    break;
                }
            }


        }
    }

}

