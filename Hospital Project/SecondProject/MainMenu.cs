using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    class MainMenu
    {
      public static void menu()
      {
            Hotel();
      }
        public static void Hotel()
        {
            
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"*********+WELCOME TO++++{Person.HotelName}*******");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
             
            

            while (true)
            {
                Console.WriteLine("Press 1  register manager 1\n"
                    + "Press 2 to Create room \n"
                    + "Press 3 for Customer booking \n" + 
                    "Press 4 to Check out room availability \n"
                    + "Press 5 to view all registerded customer \n"
                    + "Press 6 to stop navigating");
                int respond = int.Parse(Console.ReadLine());

                if (respond == 1)
                {
                    Console.Write("ENTER  First Name: ");
                    var firstname = Console.ReadLine();
                    Console.Write("Enter Second Name : ");
                    var lastname = Console.ReadLine();
                    Console.Write("Enter middle name: ");
                    var middlename = Console.ReadLine();
                    Console.Write("Enter phone Number: ");
                    var phonenumber = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Address: ");
                    var address = Console.ReadLine();
                    if (age < 18)
                    {
                        Console.WriteLine("You can't be registered as a minow");
                    }
                    else
                    {
                        Manager manager = new Manager(firstname, lastname, middlename, phonenumber, age, address);
                        Manager.managers.Add(manager);
                        manager.PrintManagerID();
                        continue;
                    }


                    Console.WriteLine();
                }
                else if (respond == 2)
                {
                    Console.WriteLine("GENERATING ROOM ONLY BY MANAGER:+++++");
                    Console.WriteLine("ENTER MANAGER ID");
                    var id = Console.ReadLine();

                    foreach (var manager in Manager.managers)
                    {
                        if (id == manager.ManagerID)
                        {
                            Console.WriteLine("creation of rooms");
                            Console.Write("ENTER ROOM STANDARD: ");
                            var roomstandard = Console.ReadLine();
                            Console.Write("ENTER PRICE: ");
                            int price = int.Parse(Console.ReadLine());
                            Rooms roomses = new Rooms(price, roomstandard);
                            Rooms.room.Add(roomses);
                            Rooms.AvailableRooms();
                        }
                        else if (id != manager.ManagerID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("SORRY YOU ARE NOT ALLOW TO CREATE ANY ROOM");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine();
                }
                else if (respond == 3)
                {
                    Console.Write("Kindly enter customer details for booking:");

                    var id = Console.ReadLine();

                    foreach (var manager in Manager.managers)
                    {
                        if (id == manager.ManagerID)
                        {
                            Rooms.AvailableRooms();
                            Console.Write("Choose room Number: ");
                            var roomnumber = Console.ReadLine();

                            foreach (var item in Rooms.room)
                            {
                                while (item.IsAvailable)
                                {
                                    if (roomnumber == item.RoomNumber)
                                    {
                                        Console.Write("ENTER YOUR FIRST NAME: ");
                                        var firstname = Console.ReadLine();
                                        Console.Write("ENTER YOUR LAST NAME: ");
                                        var lastname = Console.ReadLine();
                                        Console.Write("ENTER YOUR MIDDLE NAME: ");
                                        var middlename = Console.ReadLine();
                                        Console.Write("ENTER YOUR PHONE NUMBER: ");
                                        var phonenumber = Console.ReadLine();
                                        Console.Write("ENTER YOUR AGE: ");
                                        int age = int.Parse(Console.ReadLine());
                                        Console.Write("ENTER YOUR ADDRESS: ");
                                        var address = Console.ReadLine();
                                        Customer customer = new Customer(firstname, lastname, middlename, phonenumber, age, address);
                                        Customer.customers.Add(customer);
                                        customer.PrintCustomerID();
                                        Rooms.UpDateRoomAvailability(roomnumber, false);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No available room");
                                        break;
                                    }

                                }

                            }



                        }
                        else if (id != manager.ManagerID)
                        {
                            Console.WriteLine("Youe are not eligible to register or incorrect id: ");
                        }
                    }

                }
                else if (respond == 4)
                {
                    Console.Write("check for the room availability :");

                    var id = Console.ReadLine();

                    foreach (var manager in Manager.managers)
                    {
                        if (id == manager.ManagerID)
                        {
                            Console.WriteLine("Enter room number ");
                            var roomnumber = Console.ReadLine();
                            Rooms.UpDateRoomAvailability(roomnumber, true);
                            Console.WriteLine($"Thanks for using {Person.HotelName}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Manager has to check for room checkout");
                        }
                    }
                }
                else if (respond == 5)
                {
                    Customer.PrintCustomerDetails();

                }
                else if (respond == 6)
                {
                    Console.WriteLine("thanks for using the app");
                    break;
                }
            }
            
        }
    

    }

}
