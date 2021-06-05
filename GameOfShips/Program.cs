using System;

namespace GameOfShips
{
    class Program
    {
        static protected string[,] my_bord = new string[11, 11];
        static protected string[,] opponent_bord = new string[11, 11];

        static void Main(string[] args)
        {
            Console.WriteLine("=========================================WELCOME TO GAME OF SHIPS=======================");
            Console.WriteLine();
            Console.WriteLine();

            opponent_bord = InitializingTheBord(opponent_bord);
            opponent_bord = opponent_master_ships(opponent_bord);

            Console.WriteLine("do you want to see opponent bord y/n ?");
            string choice = Console.ReadLine().ToLower();

            if (choice == "y" || choice == "yes")
            {
                displaying_opponent_bord();
            }

            my_bord = InitializingTheBord(my_bord);
            my_bord = User_master_ships(my_bord);
            

            

            displaying_user_bord();
            
        }
        static void displaying_user_bord()
        {
            Console.WriteLine("------------------------------------MY BORD---------------------------------------");
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.Write(String.Format("{0}\t", my_bord[i, j]));

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }



        static void displaying_opponent_bord()
        {
            Console.WriteLine("-----------------------------------OPPONENT BORD---------------------------------------------");
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.Write(String.Format("{0}\t", InitializingTheBord(opponent_bord)[i, j]));

                }
                Console.WriteLine();
            }           
            Console.WriteLine();
            Console.WriteLine();
        }

        static string[,] InitializingTheBord(string[,] bord)
        {
           
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    bord[i, j] = ".";
                }
                bord[0, i] = i.ToString();
                bord[i, 0] = i.ToString();
            }
            bord[0, 0] = "_";

            return bord;
        }
        static string[,] User_master_ships(string[,] bord)
        {
            int validity = 1;
            int first_row;
            int first_colm;
            int last_row;
            int last_colm;
            Console.WriteLine("selcet the cordinates for the 4-masterd ship they should be 4 cells long each !!!");
            while (validity == 1)
            {

                Console.WriteLine("please enter first proper x and y cordinate for the 4-masterd ship recpectively ?");
                first_row = Convert.ToInt32(Console.ReadLine());
                first_colm = Convert.ToInt32(Console.ReadLine());
                if (bord[first_row, first_colm] != "8" && first_row >= 1 && first_row <= 10)
                {
                    Console.WriteLine("please enter the last proper x and y cordinate for the 4-masterd ship recpectively ?");
                    last_row = Convert.ToInt32(Console.ReadLine());
                    last_colm = Convert.ToInt32(Console.ReadLine());
                    if (bord[last_row, last_colm] == "8" || last_row < 1 || last_colm > 10)
                    {
                        Console.WriteLine("please enter the proper cells \n Try again");
                        continue;
                    }

                    if (!((last_row - first_row == 0 && last_colm - first_colm == 3) || (last_row - first_row == 3 && last_colm - first_colm == 0)))
                    {
                        Console.WriteLine("please enter the proper cells \n Try again");
                        continue;
                    }

                    for (int i = first_row; i <= last_row; i++)
                    {
                        for (int j = first_colm; j <= last_colm; j++)
                        {
                            if (bord[i, j] == "8")
                            {
                                Console.WriteLine("please enter the proper cells \n Try again");
                                continue;
                            }
                            bord[i, j] = "8";
                        }
                    }

                    for (int i = first_row; i <= last_row; i++)
                    {
                        for (int j = first_colm; j <= last_colm; j++)
                        {
                            bord[i, j] = "8";
                        }
                    }
                }
                else
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }
            }
            Console.WriteLine("selcet the cordinates for the 3-masterd ship they should be 3 cells long each !!!");
            validity = 1;
            while (validity <= 2)
            {
                Console.WriteLine("please enter first proper x and y cordinate for the 3-masterd ship recpectively ?");
                    
                first_row = Convert.ToInt32(Console.ReadLine());
                first_colm = Convert.ToInt32(Console.ReadLine());
                if(bord[first_row,first_colm]=="8" || first_row < 1 ||  first_row >10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }
                Console.WriteLine("please enter the last proper x and y cordinate for the 3-masterd ship recpectively ?");
                last_row = Convert.ToInt32(Console.ReadLine());
                last_colm = Convert.ToInt32(Console.ReadLine());

                if (bord[last_row, last_colm] == "8" || last_row < 1 || last_colm >10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                if (!((last_row - first_row == 0 && last_colm - first_colm == 2) || (last_row - first_row == 2 && last_colm - first_colm == 0)))
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        if(bord[i,j]=="8")
                        {
                            Console.WriteLine("please enter the proper cells \n Try again");
                            continue;
                        }
                        bord[i, j] = "8";
                    }
                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        bord[i, j] = "8";
                    }
                }


                validity++;
                
            }

            Console.WriteLine("selcet the cordinates for the 2-masterd ship they should be 2 cells long each !!!");
            validity = 1;
            while(validity <=3)
            { 
                Console.WriteLine("please enter first proper x and y cordinate for the 2-masterd ship recpectively ?");

                first_row = Convert.ToInt32(Console.ReadLine());
                first_colm = Convert.ToInt32(Console.ReadLine());

                if (bord[first_row, first_colm] == "8" || first_row < 1 || first_row > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                Console.WriteLine("please enter the last proper x and y cordinate for the 2-masterd ship recpectively ?");
                last_row = Convert.ToInt32(Console.ReadLine());
                last_colm = Convert.ToInt32(Console.ReadLine());
                if (bord[last_row, last_colm] == "8" || last_row < 1 || last_colm > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                if (!((last_row - first_row == 0 && last_colm - first_colm == 1) || (last_row - first_row == 1 && last_colm - first_colm == 0)))
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;

                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            Console.WriteLine("please enter the proper cells \n Try again");
                            continue;
                        }
                        bord[i, j] = "8";
                    }
                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        bord[i, j] = "8";
                    }
                }
            }

            Console.WriteLine("selcet the cordinates for the 1-masterd ship they should be 1 cells long each !!!");
            validity = 1;
            while(validity<=4)
            {
                Console.WriteLine("please enter first proper x and y cordinate for the 1-masterd ship recpectively ?");

                first_row = Convert.ToInt32(Console.ReadLine());
                first_colm = Convert.ToInt32(Console.ReadLine());
                if (bord[first_row, first_colm] == "8" || first_row < 1 || first_colm > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                bord[first_row, first_colm] = "8";

            }

            return bord;
        }

        static string[,]  opponent_master_ships(string[,] bord)
        {
            
            int validity = 1;

            Random random = new Random();
            int first_row ;
            int first_colm ;
            int last_row ;
            int last_colm ;
            
            while(validity==1)
            {
                first_row = random.Next(1, 11);
                first_colm = random.Next(1, 11);
                last_row = random.Next(1, 11);
                last_colm = random.Next(1, 11);
                if (!((last_row - first_row == 0 && last_colm - first_colm == 3) || (last_row - first_row == 3 && last_colm - first_colm == 0)))
                {
                    continue;
                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        if (bord[i, j] == "8" )
                        {
             
                            continue;
                        }
                    }
                }

                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        bord[i, j] = "8";
                    }
                }

                validity++;
            }

            validity = 1;
            while (validity <= 2)
            {

                first_row = random.Next(1, 11);
                first_colm = random.Next(1, 11);
                last_row = random.Next(1, 11);
                last_colm = random.Next(1, 11);

                if (!((last_row - first_row == 0 && last_colm - first_colm == 2) || (last_row - first_row == 2 && last_colm - first_colm == 0)))
                {
                    
                    continue;
                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            continue;
                        }
                        bord[i, j] = "8";
                    }
                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        bord[i, j] = "8";
                    }
                }


                validity++;

            }

            
            validity = 1;
            while (validity <= 3)
            {
                first_row = random.Next(1, 11);
                first_colm = random.Next(1, 11);
                last_row = random.Next(1, 11);
                last_colm = random.Next(1, 11);

                if (!((last_row - first_row == 0 && last_colm - first_colm == 1) || (last_row - first_row == 1 && last_colm - first_colm == 0)))
                {
                   
                    continue;
                }

                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            
                            continue;
                        }
                        bord[i, j] = "8";
                    }
                }
                for (int i = first_row; i <= last_row; i++)
                {
                    for (int j = first_colm; j <= last_colm; j++)
                    {
                        bord[i, j] = "8";
                    }
                }

                validity++;
            }

            
            validity = 1;
            while (validity <= 4)
            {
                first_row = random.Next(1, 11);
                first_colm = random.Next(1, 11);

                if(bord[first_row,first_colm]=="8")
                {
        
                    continue;
                }

                bord[first_row, first_colm] = "8";
                validity++;

            }

            return bord;
        }

    }
}
