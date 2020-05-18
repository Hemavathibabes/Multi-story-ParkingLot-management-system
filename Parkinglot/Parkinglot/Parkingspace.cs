using System;
using System.Collections.Generic;
namespace Parkinglot
{

   
        class Parkingspace : vehicle
        {
            List<ParkedVehicle> pv = new List<ParkedVehicle>();
            vehicle v = new vehicle();
            String pa_floorno;
            int p_floorno;
            int p_slotno;
            int[,] vechicleslot = new int[5, 10];
            public void availablespaces(int floorno)
            {
                Console.WriteLine("Available places in the floor no: {0}  ", floorno);
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("For biks:");

                    }
                    if (i == 4)
                    {
                        Console.WriteLine("For cars");

                    }
                    if (i == 8)
                    {
                        Console.WriteLine("for bus");

                    }
                    // Console.WriteLine("{0},{1}",floorno, i);
                    Console.WriteLine(vechicleslot[floorno, i]);
                }

            }
            public void allocateavehicle(String type, String no, int f_no)
            {
                int j, count = 1;
                bool advance = true;
                // f_no = f_no - 1;
                String s2 = "car";
                String s1 = "bike";
                String s3 = "bus";

                if (type.Equals(s1))
                {
                    j = 0;
                    while (j < 4)
                    {
                        if (vechicleslot[f_no, j] == 0)
                        {
                            vechicleslot[f_no, j] = 1;
                            Console.WriteLine("vehicle allocated! at slot no: {0} ", j + 1);
                            ParkedVehicle parked = new ParkedVehicle(type, no, f_no + 1, j + 1, advance);
                            pv.Add(parked);
                            count = 0;
                            break;
                        }
                        j++;

                    }
                    if (count != 0)

                    {
                        Console.WriteLine("there is no vacancy in floor no :{0}", f_no);
                    }
                }
                else if (type.Equals(s2))
                {
                    j = 4;
                    while (j < 8)
                    {
                        if (vechicleslot[f_no, j] == 0)
                        {
                            vechicleslot[f_no, j] = 1;
                            Console.WriteLine("vehicle allocated! at the slot no:{0}", j + 1);
                            ParkedVehicle parked = new ParkedVehicle(type, no, f_no + 1, j + 1, advance);
                            pv.Add(parked);
                            count = 0;
                            break;
                        }
                        j++;

                    }
                    if (count != 0)
                    {


                        Console.WriteLine("there is no vacancy in floor no :{0}", f_no);
                    }
                }
                else
                {
                    j = 8;
                    while (j < 10)
                    {
                        if (vechicleslot[f_no, j] == 0)
                        {
                            vechicleslot[f_no, j] = 1;
                            Console.WriteLine("vehicle allocated! at the  slot no: {0}", j + 1);
                            ParkedVehicle parked = new ParkedVehicle(type, no, f_no + 1, j + 1, advance);

                            pv.Add(parked);
                            count = 0;
                            break;
                        }
                        j++;




                    }
                    if (count != 0)
                    {


                        Console.WriteLine("there is no vacancy in floor no :{0}", f_no);
                    }
                }
            }
            public void choosespot()
            {

                v.getvehicledetails();
                Console.WriteLine("enter the FloorNo:");
                pa_floorno = Console.ReadLine();
                p_floorno = Convert.ToInt32(pa_floorno);
                Console.WriteLine("every floor has a 10 slots!!");
                // Console.WriteLine("firt four slots for bike and next four slots for car and the remaining 2 slots for bus.");
                Console.WriteLine("{0}", v.v_type);
                availablespaces(p_floorno);
                allocateavehicle(v.v_type, v.v_id, p_floorno);
                availablespaces(p_floorno);
                // exitvehicle();
            }
            private int amntnocoupoun(int hrs, string type)
            {

                if (type == "car")
                    return 150 + ((hrs - 1) * 20);
                else if (type == "bike")
                    return 100 + ((hrs - 1) * 15);
                else
                    return 200 + ((hrs - 1) * 25);
            }
            private int reduceamnt(string type, int hrs)
            {
                int amnt = 0;
                if (type == "car")
                {
                    amnt = (150 * 50 / 100) + ((hrs - 1) * (20 * 10 / 100));
                }
                else if (type == "bike")
                {
                    amnt = (100 * 50 / 100) + ((hrs - 1) * (15 * 10 / 100));
                }
                else
                    amnt = (200 * 50 / 100) + ((hrs - 1) * (25 * 10 / 100));

                return amnt;
            }
            public void exitvehicle()
            {
                int sub;
                v.getvehicledetails();
                foreach (ParkedVehicle p in pv)
                {
                    if (p.vehicleId == v.v_id && p.vehicleType == v.v_type)
                    {
                        Console.WriteLine("Do you have coupoun  yes  or no");
                        String coupoun = Console.ReadLine();
                        if (coupoun == "yes")
                            sub = reduceamnt(p.vehicleType, 3);
                        else
                            sub = amntnocoupoun(3, p.vehicleType);

                        vechicleslot[p.floors - 1, p.spots - 1] = 0;
                        Console.WriteLine("You are checked out!!");
                        Console.WriteLine("your fee is {0}", sub);
                        //Console.WriteLine("{0},{1}", p.floors-1, p.spots-1);
                    }
                    else
                    {
                        Console.WriteLine("the vehicle is not parked in the area!");
                    }

                }
                availablespaces(p_floorno);
            }
            public void verifybooking()
            {
                Console.WriteLine("enter the vehicle Id:");
                string no = Console.ReadLine();
                foreach (ParkedVehicle p in pv)
                {
                    if (p.vehicleId == no)
                    {
                        if (p.isadvanced)
                        {
                            Console.WriteLine("your slot is {0} in floor no: {1}", p.floors, p.spots);
                        }
                        else
                            Console.WriteLine("there is no advance booking");
                    }
                }
            }
            public void Advancebooking(bool advance)

            {
                string typ, num;
                Console.WriteLine("Enter vehicle type:");
                typ = Console.ReadLine();
                Console.WriteLine("Enter vehicle number:");
                num = Console.ReadLine();
                int florno = 0;
                allocateavehicle(typ, num, florno);

                //ParkedVehicle parked = new ParkedVehicle(typ, num, florno+1, sl + 1, advance);
                // Console.WriteLine("Your parking spot is floor no: {0}, spot no:{1}", parked.floors, parked.spots);
                //pv.Add(parked);
                Console.WriteLine("Booking confirmed!");
            }
            public void cancelbooking()
            {
                string n;
                int flag = 0;
                Console.WriteLine("enter the vehicle id:");
                n = Console.ReadLine();
                foreach (ParkedVehicle p in pv)
                {
                    if (p.vehicleId == n)
                    {
                        if (p.isadvanced)
                        {
                            flag = 1;
                            vechicleslot[p.floors - 1, p.spots - 1] = 0;
                            Console.WriteLine("booking canceled!!");
                            break;
                        }

                    }

                }
                if (flag == 0)
                {
                    Console.WriteLine("There is no booking with your details!");
                }
            }
        
    }
}