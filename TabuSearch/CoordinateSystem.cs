using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TabuSearch
{
    class CoordinateSystem
    {
        private int x;
        private int y;
        private int iteration;
        private int current_iteration_number = 1;
        public Point min = new Point(); //переменная для хранения координат и значения минимума 

    public CoordinateSystem() { }

        public CoordinateSystem(int x1, int x2 )
        {
            x = x1; //Столбец
            y = x2; //Строка
        }

        public int SPx1 //Столбец
        {
            get { return x; }
            set { x = value; }
        }
        public int SPx2 //Строка
        {
            get { return y; }
            set { y = value; }
        }
        public int Iterations
        {
            get { return iteration; }
            set { iteration = value; }
        }

        public void Search(Point[,] my_point, TabuList<Point> myTabu)
        {
            //Временный многомерный массив точек
            Point[] tempPoint = new Point[8];
            int k1 = 0;
            for (int i = -1; i <= 1; i++) //Столбец
            {
                for (int j = -1; j <= 1; j++) //Строка
                {                    
                    if (i == 0 & j == 0)       
                    { 
                        continue; 
                    }
                    
                    else
                    {   
                        try 
                        {
                            tempPoint[k1] = new Point(my_point[SPx2 + j, SPx1 + i].x1, my_point[SPx2 + j, SPx1 + i].x2, my_point[SPx2 + j, SPx1 + i].value);
                            k1++;
                        }

                        catch //если на границе системы координат
                        { 
                            tempPoint[k1++] = new Point(0,0,0); 
                       } 
                    }                    
                }
            }

            //Сортировка временного массива
            try
            {   
                Array.Sort(tempPoint);  
            }

            catch (Exception e)
            {   
                Console.WriteLine(e.Message);   
            }

            // Отображение точек окрестности, отсортированных по значениям целевой функции - НЕОБЯЗАТЕЛЬНО
            //printTempPoint(tempPoint);

            //Пройти через временный массив
            foreach (Point t in tempPoint)
            {
                if (t.value == 0) //условие, при котором значение временной точки не равно 0
                { 
                    continue; 
                }

                else 
                {
                    if (myTabu.containsTabu(t))
                    {  //условие, при котором значение временной точки не находится в списке табу 
                    }

                    else 
                    {
                        //Если значение временной точки имеет меньшее значение, чем ранее установленный глобальный минимум,
                        //глобальное минимальное значение обновляется
                        if (t.value < min.value)
                        { 
                            min = new Point(t.x1, t.x2, t.value); 
                        }

                        //Отображайте точки, через которые проходит процесс поиска
                        Console.WriteLine("({0};{1}) -> {2}",t.x1,t.x2,t.value);
                        myTabu.addTabu(t); //в противном случае добавим метку из временного массива в список табу и остановимся
                        this.SPx1 = searchSPX1(t); //настройка координаты х1
                        this.SPx2 = searchSPX2(t); //настройка координаты х2

                        //Счётчик, на какой итерации мы находимся, и остановка на настройке
                        if (current_iteration_number ==  iteration)      
                        { 
                            break; 
                        }

                        else 
                        {
                            current_iteration_number++;                            
                            Search(my_point, myTabu);
                        }
                        
                        break;
                    }                    
                }
            }
        }

        public void printTempPoint(Point[] tempPoint) //необязательный метод
        {
            //Цикл для печати окружающих тактов выбранного значения (x1, x2)
            foreach (Point t in tempPoint)
            { 
                Console.WriteLine("({0};{1}) \t -> {2}", t.x1, t.x2, t.value); 
            }

            Console.WriteLine("------------------");
        }

        int searchSPX1(Point t) //поиск 1й координаты
        {
            //double[] _arrX1 = { -3.0, -2.0, -1.0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //Столбцы(x1): 14
            double[] _arrX1 = new double[Program.x1_mas_len];
            for (int i1 = 0; i1 < _arrX1.Length; i1++)
                _arrX1[i1] = Program.arrX1[i1];

            int r = 0;

            for (int i = 0; i < Program.arrX1.Length; i++)
            {
                if (t.x1 == Program.arrX1[i])             
                    r = i;    
            }

            return r;
        }

        int searchSPX2(Point t)//поиск 2й координаты
        {
            //double[] _arrX2 = { -3.50, -3, -2.50, -2, -1.50, -1, -0.50, 0, 0.5, 1.0, 1.5, 2, 2.5, 3, 3.50 }; //Строки(x2): 15
            double[] _arrX2 = new double[Program.x2_mas_len];
            for (int i2 = 0; i2 < _arrX2.Length; i2++)
                _arrX2[i2] = Program.arrX2[i2];

            int r = 0;

            for (int i = 0; i < _arrX2.Length; i++)
            {
                if (t.x2 == _arrX2[i])
                    r = i;                
            }

            return r;
        }
    }
}
