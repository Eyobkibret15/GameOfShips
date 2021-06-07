using System;

namespace GameOfShips
{
    class Program
    {
        /*We declear a two dimentional array to store the bords element*/
        static protected string[,] my_bord = new string[11, 11];
        static protected string[,] opponent_bord = new string[11, 11];
        static protected string[,] demo_opponent_bord = new string[11, 11];

        /*We declear a jagged array (aray of aray ) for storing each opponent ship element
            inorder to use for sink the ship with **/
        static protected int[][] a1_ship4 = new int[5][];
        static protected int[][] b1_ship3 = new int[4][];
        static protected int[][] b2_ship3 = new int[4][];
        static protected int[][] c1_ship2 = new int[3][];
        static protected int[][] c2_ship2 = new int[3][];
        static protected int[][] c3_ship2 = new int[3][];
        static protected int[][] d1_ship1 = new int[1][];
        static protected int[][] d2_ship1 = new int[1][];
        static protected int[][] d3_ship1 = new int[1][];
        static protected int[][] d4_ship1 = new int[1][];

       /* those varibles used to count each ship damage globally*/
        static protected int a1_ship4_damage = 0;
        static protected int b1_ship3_damage = 0;
        static protected int b2_ship3_damage = 0;
        static protected int c1_ship2_damage = 0;
        static protected int c2_ship2_damage = 0;
        static protected int c3_ship2_damage = 0;
        static protected int d1_ship1_damage = 0;
        static protected int d2_ship1_damage = 0;
        static protected int d3_ship1_damage = 0;
        static protected int d4_ship1_damage = 0;

        /*the folowing varible used to identify the winner of the game */
        static protected int total_user_damage = 0;
        static protected int Turn_Count = 0;
        static protected int total_enemy_damage = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("========================================= WELCOME TO GAME OF SHIPS =======================");
            Console.WriteLine();
            Console.WriteLine();
            opponent_bord = InitializingTheBord(opponent_bord);
            opponent_bord = opponent_master_ships(opponent_bord);
            demo_opponent_bord = InitializingTheBord(demo_opponent_bord);

            Console.WriteLine("do you want to see opponent bord or it should be masked y/n ?");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y" || choice == "yes")
            {
                displaying_opponent_bord(opponent_bord);
            }
            my_bord = InitializingTheBord(my_bord);
            my_bord = User_master_ships(my_bord);
            displaying_user_bord();
            StartTheGame();

        }

        static void StartTheGame()
        {

            Console.WriteLine("this is opponent's masked bord");
            displaying_opponent_bord(demo_opponent_bord);
            while (true)
            {
                Console.WriteLine("YOUR TURN\n choose the row and column cordinates for firing  from 1 to 10   respectively ? ");
                int fire_row = Convert.ToInt32(Console.ReadLine());
                int fire_column = Convert.ToInt32(Console.ReadLine());
                if (opponent_bord[fire_row, fire_column] == "8")
                {
                    Console.WriteLine("you damage one cell you have second shot\n , fire again");
                    opponent_bord[fire_row, fire_column] = "X";
                    Turn_Count += 1;
                    total_enemy_damage ++;
                    marke_sunken_ships(fire_row, fire_column);
                    demo_opponent_bord[fire_row, fire_column] = "X";
                    if (total_enemy_damage > 19)
                    {
                        Console.Write("CONGRATULATION YOU WIN THE GAME");
                        Console.WriteLine($"with  {Turn_Count} numbr of shots !!!");
                        displaying_user_bord();
                        displaying_opponent_bord(demo_opponent_bord);
                        Environment.Exit(1);
                    }
                }
                else if (fire_row < 1 || fire_row > 10 || fire_column < 1 || fire_column > 10)
                {
                    Console.WriteLine("please enter the proper cells , out of bound \n Try again");
                    continue;
                }
                else if (opponent_bord[fire_row, fire_column] == "X")
                {
                    Console.WriteLine("please enter the proper cells, already damaged cell \n Try again");
                    continue;
                }

                else if (demo_opponent_bord[fire_row, fire_column] == ".")
                {
                    Console.WriteLine("you miss the target \n , opponent's turn >>>>>>>>>>");
                    Turn_Count += 1;
                    demo_opponent_bord[fire_row, fire_column] = "!";
                    opponents_fire();
                }
                else if (demo_opponent_bord[fire_row, fire_column] == "!")
                {
                    Console.WriteLine("you miss the target,you already shot it \n , try again");
                    continue;
                }
                else if (opponent_bord[fire_row, fire_column] == ".")
                {
                    Console.WriteLine("you miss the target \n , opponent's turn >>>>>>>>>>");
                    Turn_Count += 1;
                    demo_opponent_bord[fire_row, fire_column] = "!";
                    opponents_fire();
                }
                else
                {
                    continue;
                }
            }

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
        static void opponents_fire()
        {
            Random rand = new Random();
            while (true)
            {
                int fire_row = rand.Next(1, 11);
                int fire_column = rand.Next(1, 11);
                if (my_bord[fire_row, fire_column] == "X")
                {
                    continue;
                }
                else if (my_bord[fire_row, fire_column] == "8")
                {
                    total_user_damage ++;
                    if (total_user_damage > 19)
                    {
                        Console.WriteLine("YOU LOSE THE GAME \n PLAY NEW GAME");
                        Environment.Exit(1);
                    }
                    my_bord[fire_row, fire_column] = "X";
                    continue;
                }
                else if (my_bord[fire_row, fire_column] == ".")
                {
                    StartTheGame();
                }

                else
                {
                    Console.WriteLine("0000");
                    continue;
                }
            }
        }



        static void displaying_opponent_bord(string[,] bord)
        {
            Console.WriteLine("-----------------------------------OPPONENT BORD---------------------------------------------");
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.Write(String.Format("{0}\t", bord[i, j]));

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
            bool occupied = false;
            int starting_row;
            int starting_column;
            int last_row;
            int last_column;
            Console.WriteLine("selcet the cordinates for the 4-masterd ship they should be 4 cells long each !!!");
            while (validity == 1)
            {

                Console.WriteLine("please enter the starting proper row and column cordinate from 1 to 10 for the 4-masterd ship recpectively ?");
                starting_row = Convert.ToInt32(Console.ReadLine());
                starting_column = Convert.ToInt32(Console.ReadLine());
                if (starting_row < 1 || starting_row > 10 || starting_column < 1 || starting_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                Console.WriteLine("do you want to fill the ship cells to the (right or down) from the starting cell choose r/d ? ");
                string fill = Console.ReadLine().ToLower();
                if (fill == "r" || fill == "right")
                {
                    last_row = starting_row;
                    last_column = starting_column + 3;
                }
                else if (fill == "d" || fill == "down")
                {
                    last_row = starting_row + 3;
                    last_column = starting_column;
                }
                else
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                if (last_row < 1 || last_row > 10 || last_column < 1 || last_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            Console.WriteLine("please enter the proper cells \n Try again");
                            occupied = true;
                            break;
                        }
                    }
                    if (occupied)
                    {
                        break;
                    }
                }
                if (occupied)
                {
                    occupied = false;
                    continue;
                }

                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        bord[i, j] = "8";
                    }
                }

                validity++;

            }
            Console.WriteLine("selcet the cordinates for the 3-masterd ship they should be 3 cells long each !!!");
            validity = 1;
            while (validity <= 2)
            {
                Console.WriteLine("please enter the starting row and column  cordinate from 1 to 10  for the 3-masterd ship recpectively ?");
                starting_row = Convert.ToInt32(Console.ReadLine());
                starting_column = Convert.ToInt32(Console.ReadLine());
                if (starting_row < 1 || starting_row > 10 || starting_column < 1 || starting_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                Console.WriteLine("do you want to fill the ship cells to the (right or down) from the starting cell choose r/d ? ");
                string fill = Console.ReadLine().ToLower();
                if (fill == "r" || fill == "right")
                {
                    last_row = starting_row;
                    last_column = starting_column + 2;
                }
                else if (fill == "d" || fill == "down")
                {
                    last_row = starting_row + 2;
                    last_column = starting_column;
                }
                else
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                if (last_row < 1 || last_row > 10 || last_column < 1 || last_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            Console.WriteLine("please enter the proper cells \n Try again");
                            occupied = true;
                            break;
                        }
                    }
                    if (occupied)
                    {
                        break;
                    }
                }
                if (occupied)
                {
                    occupied = false;
                    continue;
                }

                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        bord[i, j] = "8";
                    }
                }

                validity++;


            }

            Console.WriteLine("selcet the cordinates for the 2-masterd ship they should be 2 cells long each !!!");
            validity = 1;
            while (validity <= 3)
            {
                Console.WriteLine("please enter the starting row and column cordinate from 1 to 10 for the 2-masterd ship recpectively ?");

                starting_row = Convert.ToInt32(Console.ReadLine());
                starting_column = Convert.ToInt32(Console.ReadLine());
                if (starting_row < 1 || starting_row > 10 || starting_column < 1 || starting_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                Console.WriteLine("do you want to fill the ship cells to the (right or down) from the starting cell choose r/d ? ");
                string fill = Console.ReadLine().ToLower();
                if (fill == "r" || fill == "right")
                {
                    last_row = starting_row;
                    last_column = starting_column + 1;
                }
                else if (fill == "d" || fill == "down")
                {
                    last_row = starting_row + 1;
                    last_column = starting_column;
                }
                else
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                if (last_row < 1 || last_row > 10 || last_column < 1 || last_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }
                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            Console.WriteLine("please enter the proper cells \n Try again");
                            occupied = true;
                            break;
                        }
                    }
                    if (occupied)
                    {
                        break;
                    }
                }
                if (occupied)
                {
                    occupied = false;
                    continue;
                }
                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        bord[i, j] = "8";
                    }
                }

                validity++;

            }

            Console.WriteLine("selcet the cordinates for the 1-masterd ship they should be 1 cells long each !!!");
            validity = 1;
            while (validity <= 4)
            {
                Console.WriteLine("please enter first proper row and column cordinate for the 1-masterd ship recpectively ?");

                starting_row = Convert.ToInt32(Console.ReadLine());
                starting_column = Convert.ToInt32(Console.ReadLine());
                if (starting_row < 1 || starting_row > 10 || starting_column < 1 || starting_column > 10)
                {
                    Console.WriteLine("please enter the proper cells \n Try again");
                    continue;
                }

                bord[starting_row, starting_column] = "8";

                validity++;

            }

            return bord;
        }

        static string[,] opponent_master_ships(string[,] bord)
        {

            int validity = 1;
            bool occupied = false;

            Random random = new Random();
            int starting_row;
            int starting_column;
            int last_row;
            int last_column;

            while (validity == 1)
            {
                starting_row = random.Next(1, 11);
                starting_column = random.Next(1, 11);


                int choose = random.Next(1, 3);

                if (choose == 1)
                {
                    last_row = starting_row;
                    last_column = starting_column + 3;
                    a1_ship4[4] = new int[1] { 1 };
                }
                else
                {
                    last_row = starting_row + 3;
                    last_column = starting_column;
                    a1_ship4[4] = new int[1] { 0 };
                }

                if (last_row < 1 || last_row > 10 || last_column < 1 || last_column > 10)
                {
                    continue;
                }

                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            occupied = true;
                            break;
                        }
                    }
                    if (occupied)
                    {
                        break;
                    }
                }
                if (occupied)
                {
                    occupied = false;
                    continue;
                }
                int count = 0;
                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        bord[i, j] = "8";
                        a1_ship4[count] = new int[2] { i, j };
                        count++;
                    }
                }

                validity++;
            }

            validity = 1;
            while (validity <= 2)
            {

                starting_row = random.Next(1, 11);
                starting_column = random.Next(1, 11);



                int choose = random.Next(1, 3);

                if (choose == 1)
                {
                    last_row = starting_row;
                    last_column = starting_column + 2;
                    switch (validity)
                    {
                        case 1:
                            b1_ship3[3] = new int[1] { 1 };
                            break;
                        case 2:
                            b2_ship3[3] = new int[1] { 1 };
                            break;
                    }
                }
                else
                {
                    last_row = starting_row + 2;
                    last_column = starting_column;
                    switch (validity)
                    {
                        case 1:
                            b1_ship3[3] = new int[1] { 0 };
                            break;
                        case 2:
                            b2_ship3[3] = new int[1] { 0 };
                            break;
                    }
                }

                if (last_row < 1 || last_row > 10 || last_column < 1 || last_column > 10)
                {
                    continue;
                }
                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            occupied = true;
                            break;
                        }
                    }
                    if (occupied)
                    {
                        break;
                    }
                }
                if (occupied)
                {
                    occupied = false;
                    continue;
                }

                int count = 0;
                for (int i = starting_row; i <= last_row; i++)
                {

                    for (int j = starting_column; j <= last_column; j++)
                    {
                        bord[i, j] = "8";
                        switch (validity)
                        {
                            case 1:
                                b1_ship3[count] = new int[2] { i, j };
                                count++;

                                break;
                            case 2:
                                b2_ship3[count] = new int[2] { i, j };
                                count++;
                                break;
                        }

                    }
                }

                validity++;

            }


            validity = 1;
            while (validity <= 3)
            {
                starting_row = random.Next(1, 11);
                starting_column = random.Next(1, 11);

                int choose = random.Next(1, 3);

                if (choose == 1)
                {
                    last_row = starting_row;
                    last_column = starting_column + 1;
                    switch (validity)
                    {
 
                        case 1:
                            c1_ship2[2] = new int[1] { 1 };
                            break;
                        case 2:
                            c2_ship2[2] = new int[1] { 1 };
                            break;
                        case 3:
                            c3_ship2[2] = new int[1] { 1 };
                            break;

                    }
                }
                else
                {
                    
                    last_row = starting_row + 1;
                    last_column = starting_column;
                    switch (validity)
                    {
                        case 1:
                            c1_ship2[2] = new int[1] { 0 };
                            break;
                        case 2:
                            c2_ship2[2] = new int[1] { 0 };
                            break;
                        case 3:
                            c3_ship2[2] = new int[1] { 0 };
                            break;

                    }
                }
                if (last_row < 1 || last_row > 10 || last_column < 1 || last_column > 10)
                {
                    continue;
                }
                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        if (bord[i, j] == "8")
                        {
                            occupied = true;
                            break;
                        }
                    }
                    if (occupied)
                    {
                        break;
                    }
                }
                if (occupied)
                {
                    occupied = false;
                    continue;
                }
                int count = 0;
                for (int i = starting_row; i <= last_row; i++)
                {
                    for (int j = starting_column; j <= last_column; j++)
                    {
                        bord[i, j] = "8";
                        switch (validity)
                        {
                            case 1:
                                c1_ship2[count] = new int[2] { i, j };
                                count++;
                                break;
                            case 2:
                                c2_ship2[count] = new int[2] { i, j };
                                count++;
                                break;
                            case 3:
                                c3_ship2[count] = new int[2] { i, j };
                                count++;
                                break;
                        }
                    }
                }
                validity++;
            }
            validity = 1;
            while (validity <= 4)
            {
                starting_row = random.Next(1, 11);
                starting_column = random.Next(1, 11);
                if (bord[starting_row, starting_column] == "8")
                {
                    continue;
                }
                bord[starting_row, starting_column] = "8";
                switch (validity)
                {
                    case 1:
                        d1_ship1[0] = new int[2] { starting_row, starting_column };
                        break;
                    case 2:
                       d2_ship1[0] = new int[2] { starting_row, starting_column };
                        break;
                    case 3:
                        d3_ship1[0] = new int[2] { starting_row, starting_column };
                        break;
                    case 4:
                        d4_ship1[0] = new int[2] { starting_row, starting_column };
                        break;
                }
                validity++;
            }

            return bord;
        }

        static void marke_sunken_ships(int x, int y)
        {
            int x_mark;
            int y_mark;
            int count = 0;
            bool found = false;
            for (int i = 0; i <= 3; i++)
            {
                if (x == a1_ship4[count][0] && y == a1_ship4[count][1])
                {
                    a1_ship4_damage++;
                    found = true;
                    Console.WriteLine(a1_ship4_damage);
                    if (a1_ship4_damage > 3)
                    {
                        switch (a1_ship4[4][0])
                        {
                            case 0:
                                x_mark = a1_ship4[0][0] - 1;
                                y_mark = a1_ship4[0][1];
                                if (!(x_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                x_mark = a1_ship4[3][0] + 1;
                                y_mark = a1_ship4[3][1];
                                if (!(x_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 3; j++)
                                {
                                    y_mark = a1_ship4[j][1] - 1;
                                    x_mark = a1_ship4[j][0];
                                    if (!(y_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    y_mark = a1_ship4[j][1] + 1;
                                    if (!(y_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                            case 1:
                                x_mark = a1_ship4[0][0];
                                y_mark = a1_ship4[0][1] - 1;
                                if (!(y_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                y_mark = a1_ship4[3][1] + 1;
                                x_mark = a1_ship4[3][0];
                                if (!(y_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 3; j++)
                                {
                                    y_mark = a1_ship4[j][1];
                                    x_mark = a1_ship4[j][0] - 1;
                                    if (!(x_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    x_mark = a1_ship4[j][0] + 1;
                                    if (!(x_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    break;
                }
                count++;
            }
            if (found)
            {
                return;
            }
            count = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (x == b1_ship3[count][0] && y == b1_ship3[count][1])
                {
                    b1_ship3_damage++;
                    found = true;
                    if (b1_ship3_damage > 2)
                    {
                        switch (b1_ship3[3][0])
                        {
                            case 0:
                                x_mark = b1_ship3[0][0] - 1;
                                y_mark = b1_ship3[0][1];
                                if (!(x_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                x_mark = b1_ship3[2][0] + 1;
                                y_mark = b1_ship3[2][1];
                                if (!(x_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 2; j++)
                                {
                                    y_mark = b1_ship3[j][1] - 1;
                                    x_mark = b1_ship3[j][0];
                                    if (!(y_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    y_mark = b1_ship3[j][1] + 1;
                                    if (!(y_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                            case 1:
                                x_mark = b1_ship3[0][0];
                                y_mark = b1_ship3[0][1] - 1;
                                if (!(y_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                y_mark = b1_ship3[2][1] + 1;
                                x_mark = b1_ship3[2][0];
                                if (!(y_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 2; j++)
                                {
                                    y_mark = b1_ship3[j][1];
                                    x_mark = b1_ship3[j][0] - 1;
                                    if (!(x_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    x_mark = b1_ship3[j][0] + 1;
                                    if (!(x_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    break;
                }
                count++;
            }
            if (found)
            {
                return;
            }
            count = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (x == b2_ship3[count][0] && y == b2_ship3[count][1])
                {
                    b2_ship3_damage++;
                    found = true;
                    if (b2_ship3_damage > 2)
                    {
                        switch (b2_ship3[3][0])
                        {
                            case 0:
                                x_mark = b2_ship3[0][0] - 1;
                                y_mark = b2_ship3[0][1];
                                if (!(x_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                x_mark = b2_ship3[2][0] + 1;
                                y_mark = b2_ship3[2][1];
                                if (!(x_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 2; j++)
                                {
                                    y_mark = b2_ship3[j][1] - 1;
                                    x_mark = b2_ship3[j][0];
                                    if (!(y_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    y_mark = b2_ship3[j][1] + 1;
                                    if (!(y_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                            case 1:
                                x_mark = b2_ship3[0][0];
                                y_mark = b2_ship3[0][1] - 1;
                                if (!(y_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                y_mark = b2_ship3[2][1] + 1;
                                x_mark = b2_ship3[2][0];
                                if (!(y_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 2; j++)
                                {
                                    y_mark = b2_ship3[j][1];
                                    x_mark = b2_ship3[j][0] - 1;
                                    if (!(x_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    x_mark = b2_ship3[j][0] + 1;
                                    if (!(x_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    break;
                }
                count++;
            }
            if (found)
            {
                return;
            }
            count = 0;
            for (int i = 0; i <= 1; i++)
            {
                if (x == c1_ship2[count][0] && y == c1_ship2[count][1])
                {
                    c1_ship2_damage++;
                    found = true;
                    if (c1_ship2_damage > 1)
                    {
                        switch (c1_ship2[2][0])
                        {
                            case 0:
                                Console.WriteLine("reeeeeeee");
                                x_mark = c1_ship2[0][0] - 1;
                                y_mark = c1_ship2[0][1];
                                if (!(x_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                x_mark = c1_ship2[1][0] + 1;
                                y_mark = c1_ship2[1][1];
                                if (!(x_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 1; j++)
                                {
                                    y_mark = c1_ship2[j][1] - 1;
                                    x_mark = c1_ship2[j][0];
                                    if (!(y_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    y_mark = c1_ship2[j][1] + 1;
                                    if (!(y_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                            case 1:
                                x_mark = c1_ship2[0][0];
                                y_mark = c1_ship2[0][1] - 1;
                                if (!(y_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                y_mark = c1_ship2[1][1] + 1;
                                x_mark = c1_ship2[1][0];
                                if (!(y_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 1; j++)
                                {
                                    y_mark = c1_ship2[j][1];
                                    x_mark = c1_ship2[j][0] - 1;
                                    if (!(x_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    x_mark = c1_ship2[j][0] + 1;
                                    if (!(x_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    break;
                }
                count++;
            }
            if (found)
            {
                return;
            }
            count = 0;
            for (int i = 0; i <= 1; i++)
            {
                if (x == c2_ship2[count][0] && y == c2_ship2[count][1])
                {
                    c2_ship2_damage++;
                    found = true;
                    if (c2_ship2_damage > 1)
                    {
                        switch (c2_ship2[2][0])
                        {
                            case 0:
                                Console.WriteLine("reeeeeeee");
                                x_mark = c2_ship2[0][0] - 1;
                                y_mark = c2_ship2[0][1];
                                if (!(x_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                x_mark = c2_ship2[1][0] + 1;
                                y_mark = c2_ship2[1][1];
                                if (!(x_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 1; j++)
                                {
                                    y_mark = c2_ship2[j][1] - 1;
                                    x_mark = c2_ship2[j][0];
                                    if (!(y_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    y_mark = c2_ship2[j][1] + 1;
                                    if (!(y_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                            case 1:
                                x_mark = c2_ship2[0][0];
                                y_mark = c2_ship2[0][1] - 1;
                                if (!(y_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                y_mark = c2_ship2[1][1] + 1;
                                x_mark = c2_ship2[1][0];
                                if (!(y_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 1; j++)
                                {
                                    y_mark = c2_ship2[j][1];
                                    x_mark = c2_ship2[j][0] - 1;
                                    if (!(x_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    x_mark = c2_ship2[j][0] + 1;
                                    if (!(x_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    break;
                }
                count++;
            }
            if (found)
            {
                return;
            }
            count = 0;
            for (int i = 0; i <= 1; i++)
            {
                if (x == c3_ship2[count][0] && y == c3_ship2[count][1])
                {
                    c3_ship2_damage++;
                    found = true;
                    if (c3_ship2_damage > 1)
                    {
                        switch (c3_ship2[2][0])
                        {
                            case 0:
                                Console.WriteLine("reeeeeeee");
                                x_mark = c3_ship2[0][0] - 1;
                                y_mark = c3_ship2[0][1];
                                if (!(x_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                x_mark = c3_ship2[1][0] + 1;
                                y_mark = c3_ship2[1][1];
                                if (!(x_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 1; j++)
                                {
                                    y_mark = c3_ship2[j][1] - 1;
                                    x_mark = c3_ship2[j][0];
                                    if (!(y_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    y_mark = c3_ship2[j][1] + 1;
                                    if (!(y_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                            case 1:
                                x_mark = c3_ship2[0][0];
                                y_mark = c3_ship2[0][1] - 1;
                                if (!(y_mark < 1))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                y_mark = c3_ship2[1][1] + 1;
                                x_mark = c3_ship2[1][0];
                                if (!(y_mark > 10))
                                {
                                    if (opponent_bord[x_mark, y_mark] != "X")
                                    {
                                        demo_opponent_bord[x_mark, y_mark] = "*";
                                    }
                                }
                                for (int j = 0; j <= 1; j++)
                                {
                                    y_mark = c3_ship2[j][1];
                                    x_mark = c3_ship2[j][0] - 1;
                                    if (!(x_mark < 1))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                    x_mark = c3_ship2[j][0] + 1;
                                    if (!(x_mark > 10))
                                    {
                                        if (opponent_bord[x_mark, y_mark] != "X")
                                        {
                                            demo_opponent_bord[x_mark, y_mark] = "*";
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
                }
                count++;
            }
            if (found)
            {
                return;
            }

            if (x == d1_ship1[0][0] && y == d1_ship1[0][1])
            {
                d1_ship1_damage++;
                found = true;
                if (d1_ship1_damage > 0)
                {
                    x_mark = d1_ship1[0][0] - 1;
                    y_mark = d1_ship1[0][1];
                    if (!(x_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d1_ship1[0][0] + 1;
                    y_mark = d1_ship1[0][1];
                    if (!(x_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d1_ship1[0][0];
                    y_mark = d1_ship1[0][1] - 1;
                    if (!(y_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d1_ship1[0][0];
                    y_mark = d1_ship1[0][1] + 1; ;
                    if (!(y_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                }
            }
            if (found)
            {
                return;
            }

            if (x == d2_ship1[0][0] && y == d2_ship1[0][1])
            {
                d2_ship1_damage++;
                found = true;
                if (d2_ship1_damage > 0)
                {
                    x_mark = d2_ship1[0][0] - 1;
                    y_mark = d2_ship1[0][1];
                    if (!(x_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d2_ship1[0][0] + 1;
                    y_mark = d2_ship1[0][1];
                    if (!(x_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d2_ship1[0][0];
                    y_mark = d2_ship1[0][1] - 1;
                    if (!(y_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d2_ship1[0][0];
                    y_mark = d2_ship1[0][1] + 1; ;
                    if (!(y_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                }
            }
            if (found)
            {
                return;
            }
            if (x == d3_ship1[0][0] && y == d3_ship1[0][1])
            {
                d3_ship1_damage++;
                found = true;
                if (d3_ship1_damage > 0)
                {
                    x_mark = d3_ship1[0][0] - 1;
                    y_mark = d3_ship1[0][1];
                    if (!(x_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d3_ship1[0][0] + 1;
                    y_mark = d3_ship1[0][1];
                    if (!(x_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d3_ship1[0][0];
                    y_mark = d3_ship1[0][1] - 1;
                    if (!(y_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d3_ship1[0][0];
                    y_mark = d3_ship1[0][1] + 1; ;
                    if (!(y_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                }
            }
            if (found)
            {
                return;
            }

            if (x == d4_ship1[0][0] && y == d4_ship1[0][1])
            {
                d4_ship1_damage++;
                found = true;
                if (d4_ship1_damage > 0)
                {
                    x_mark = d4_ship1[0][0] - 1;
                    y_mark = d4_ship1[0][1];
                    if (!(x_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d4_ship1[0][0] + 1;
                    y_mark = d4_ship1[0][1];
                    if (!(x_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d4_ship1[0][0];
                    y_mark = d4_ship1[0][1] - 1;
                    if (!(y_mark < 1))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                    x_mark = d4_ship1[0][0];
                    y_mark = d4_ship1[0][1] + 1; ;
                    if (!(y_mark > 10))
                    {
                        if (opponent_bord[x_mark, y_mark] != "X")
                        {
                            demo_opponent_bord[x_mark, y_mark] = "*";
                        }
                    }
                }
            }
            if (found)
            {
                return;
            }
        }

    }
}
