using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Win32;

namespace TabuSearch
{
    class Program
    {
        public static double[] arrX1;
        public static double[] arrX2;
        public static int x1_mas_len;
        public static int x2_mas_len;
        //Метод, который вычисляет значения целевой функции
        static double value_func(string num, double x1, double x2)
        {
            double y;
            //Уравнение для вычисления значения функции
            if (num == "1")
                y = 1.8 * Math.Pow(x1, 2) + 0.04 * Math.Pow(x1, 4) - 0.55 * Math.Pow(x1, 3) + 2 * Math.Pow(x2, 2) + 5;

            else if (num == "2")
                //y = x1 + x2;
                y = Math.Pow(1 - x1, 2) + 100 * Math.Pow(Math.Pow(x2 - x1, 2), 2);

            else
                //y = Math.Pow(-x1, 2) - Math.Pow(x2, 2);
                y = Math.Pow(x1 + 2 * x2 - 7, 2) + Math.Pow(2 * x1 + x2 - 5, 2);

            return Math.Round(y, 6);
        }

        //Способ печати точек и его значений
        static void print_point(Point[,] my_point, int x2_mas, int x1_mas)
        {
            for (int i = 0; i < x2_mas; i++)
            {
                Console.WriteLine("{0}", i+1);
                for (int j = 0; j < x1_mas; j++)
                {
                    Console.WriteLine("({0};{1}): ({2};{3}) -> {4}", i, j, my_point[i, j].x1, my_point[i, j].x2, my_point[i, j].value);
                }
                Console.WriteLine();
            }
        }

        //Главная часть
        static void Main(string[] args)
        {
            Console.WriteLine("Поиск с запретами:\n");
            Console.WriteLine("Выберите уравнение, которое хотите решить:\n");
            Console.WriteLine("1) 1.8*x1^2 + 0.04*x1^4 - 0.55*x1^3 + 2*x2^2 + 5\n2) (1 - x1)^2 + 100*(x2 - x1^2)^2\n3) (x1 + 2*x2 - 7)^2 + (2*x1 + x2 - 5)^2\n\n");
            Console.Write("Ваш выбор: ");
            string function_num = Console.ReadLine();

            //Цикл идёт, пока не введут 1, 2 или 3
            while (function_num != "1" && function_num != "2" && function_num != "3")
            {
                Console.WriteLine("Вы ввели что-то другое...");
                function_num = Console.ReadLine();
            }

             //Если выбрано одно из уравнений, основной вызов методов
            if (function_num == "1" || function_num == "2" || function_num == "3")
            {
                /*
                  /|\
                   |
                   x2  x1-->*/

                /*Point[,] my_point = new Point[15, 14]; //Многомерный массив точек: 15 строк и 14 столбцов
                double[] arrX1 = { -3.0, -2.0, -1.0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //14 столбцов
                double[] arrX2 = { -3.50, -3, -2.50, -2, -1.50, -1, -0.50, 0, 0.5, 1.0, 1.5, 2, 2.5, 3, 3.50 }; //15 строк*/
                
                Console.Write("\nВведите размер х1 массива(число столбцов): "); //14 было
                x1_mas_len = Convert.ToInt32(Console.ReadLine());
                while (x1_mas_len <= 0)
                {
                    Console.WriteLine("Введите число столбцов, большее 0: ");
                    x1_mas_len = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("\nВведите размер х2 массива(число строк): "); //15 было
                x2_mas_len = Convert.ToInt32(Console.ReadLine());
                while (x2_mas_len <= 0)
                {
                    Console.WriteLine("Введите число строк, большее 0: ");
                    x2_mas_len = Convert.ToInt32(Console.ReadLine());
                }

                Point[,] my_point = new Point[x2_mas_len, x1_mas_len]; //Многомерный массив точек

                Console.Write("\nВведите массив столбцов:\n");
                arrX1 = new double[x1_mas_len];
                for (int i1 = 0; i1 < x1_mas_len; i1++)
                {
                    arrX1[i1] = Convert.ToDouble(Console.ReadLine());
                }

                Console.Write("\nВведите массив строк:\n");
                arrX2 = new double[x2_mas_len];
                for (int i2 = 0; i2 < x2_mas_len; i2++)
                {
                    arrX2[i2] = Convert.ToDouble(Console.ReadLine());
                }

                for (int i = 0; i < x2_mas_len; i++) //строка
                {
                    for (int j = 0; j < x1_mas_len; j++) //столбец
                    {
                        my_point[i, j] = new Point(arrX1[j], arrX2[i], value_func(function_num, arrX1[j], arrX2[i])); //столбец, строка и значение                  
                    }
                }

                //Печать всех точек и их значений
                Console.Write("\n");
                print_point(my_point, x2_mas_len, x1_mas_len);

                //Создание списка запретов
                TabuList<Point> myTabu = new TabuList<Point>();

                //Размер списка запретов
                Console.Write("\nВведите размер списка запретов: ");
                //myTabu.TLL = 20;
                myTabu.TLL = Convert.ToInt32(Console.ReadLine());
                while (myTabu.TLL <= 0)
                {
                    Console.WriteLine("Введите размер списка, больший 0: ");
                    myTabu.TLL = Convert.ToInt32(Console.ReadLine());
                }

                //Создание координатной системы
                CoordinateSystem cs = new CoordinateSystem(0, 0); //столбец и строка    

                //Добавление введённого начального значения в список табу
                Console.Write("\nВведите 1 координату начальной точки: ");
                double x1_first = Convert.ToDouble(Console.ReadLine());
                Console.Write("\nВведите 2 координату начальной точки: ");
                double x2_first = Convert.ToDouble(Console.ReadLine());
                double value_first = value_func(function_num, x1_first, x2_first);

                //Point tmp = new Point(-2, 2.5, 29.74);
                Point tmp = new Point(x1_first, x2_first, value_first);
                myTabu.addTabu(tmp);

                //Число итераций(как ограничение, задаваемое пользоватлем для останова)
                //cs.Iterations = 30;
                Console.Write("\nВведите кол-во итераций: ");
                cs.Iterations = Convert.ToInt32(Console.ReadLine());
                while (cs.Iterations <= 0)
                {
                    Console.WriteLine("Введите число итераций, большее 0: ");
                    cs.Iterations = Convert.ToInt32(Console.ReadLine());
                }

                //Начальный минимум(точка, введённая пользователем), позже в процессе поиска он изменяется
                cs.min = tmp;
                //cs.arr_X1 = arrX1;
                //cs.arr_X2 = arrX2;                                        

                //Поиск минимума
                cs.Search(my_point, myTabu);

                //Результаты табу-поиска
                Console.WriteLine("\nМинимум и значение функции от него: ({0};{1}); {2}", cs.min.x1, cs.min.x2, cs.min.value);             
                Console.WriteLine("Число итераций: {0}", cs.Iterations);
                Console.ReadLine();
            }
        }
    }
}
