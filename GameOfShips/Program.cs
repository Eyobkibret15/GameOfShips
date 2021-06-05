using System;

namespace GameOfShips
{
    class Program
    {
        static protected string[,] my_bord = new string[11, 11];

        static void Main(string[] args)
        {
            InitializingTheBord();

            User_master_ships();

            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.Write(String.Format("{0}\t", my_bord[i, j]));

                }
                Console.WriteLine();
            }
            
        }

        static void InitializingTheBord()
        {
            Console.WriteLine("                          ==============WELCOME TO GAME OF SHIPS================");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    my_bord[i, j] = ".";
                }
                my_bord[0, i] = i.ToString();
                my_bord[i, 0] = i.ToString();
            }
            my_bord[0, 0] = "_";
        }
        static void User_master_ships()
        {
            Console.WriteLine("selcet the cordinates for the 4-masterd ship they should be 4 cells long each !!!\n" +
                              "please enter first proper x and y cordinate for the 4-masterd ship recpectively ?");
            
            int first_x_cordinate = Convert.ToInt32(Console.ReadLine());
            int first_y_cordinate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please enter the last proper x and y cordinate for the 4-masterd ship recpectively ?");
            int last_x_cordinate = Convert.ToInt32(Console.ReadLine());
            int last_y_cordinate = Convert.ToInt32(Console.ReadLine()) ;
            for (int i = first_x_cordinate; i <= last_x_cordinate; i++)
            {
                for (int j = first_y_cordinate; j <= last_y_cordinate; j++)
                {
                    my_bord[i, j] = "8";
                }
            }

            Console.WriteLine("selcet the cordinates for the 3-masterd ship they should be 3 cells long each !!!");
            for (int l = 1; l<= 2; l++)
            {
                Console.WriteLine("please enter first proper x and y cordinate for the 3-masterd ship recpectively ?");

                first_x_cordinate = Convert.ToInt32(Console.ReadLine());
                first_y_cordinate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("please enter the last proper x and y cordinate for the 3-masterd ship recpectively ?");
                last_x_cordinate = Convert.ToInt32(Console.ReadLine());
                last_y_cordinate = Convert.ToInt32(Console.ReadLine());
                for (int i = first_x_cordinate; i <= last_x_cordinate; i++)
                {
                    for (int j = first_y_cordinate; j <= last_y_cordinate; j++)
                    {
                        my_bord[i, j] = "8";
                    }
                }
            }

            Console.WriteLine("selcet the cordinates for the 2-masterd ship they should be 2 cells long each !!!");
            for (int l = 1; l <= 3; l++)
            {
                Console.WriteLine("please enter first proper x and y cordinate for the 2-masterd ship recpectively ?");

                first_x_cordinate = Convert.ToInt32(Console.ReadLine());
                first_y_cordinate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("please enter the last proper x and y cordinate for the 2-masterd ship recpectively ?");
                last_x_cordinate = Convert.ToInt32(Console.ReadLine());
                last_y_cordinate = Convert.ToInt32(Console.ReadLine());
                for (int i = first_x_cordinate; i <= last_x_cordinate; i++)
                {
                    for (int j = first_y_cordinate; j <= last_y_cordinate; j++)
                    {
                        my_bord[i, j] = "8";
                    }
                }
            }

            Console.WriteLine("selcet the cordinates for the 1-masterd ship they should be 1 cells long each !!!");
            for (int l = 1; l <= 4; l++)
            {
                Console.WriteLine("please enter first proper x and y cordinate for the 1-masterd ship recpectively ?");

                first_x_cordinate = Convert.ToInt32(Console.ReadLine());
                first_y_cordinate = Convert.ToInt32(Console.ReadLine());

                my_bord[first_x_cordinate, first_y_cordinate] = "8";

            }
        }

    }
}
