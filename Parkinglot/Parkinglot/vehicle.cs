using System;

namespace Parkinglot
{
    class vehicle
    {
        public string v_id;
        public string v_type;
       

        public void getvehicledetails()
        {
            Console.WriteLine("enter the vehicle id:");
            v_id = Console.ReadLine();

            Console.WriteLine("enter the vehicle type:");
            v_type = Console.ReadLine();
            Console.WriteLine();

        }
        
    }
    }

