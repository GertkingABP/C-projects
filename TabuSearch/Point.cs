using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
 
namespace TabuSearch
{
    //Универсальный интерфейс IComparable для сортировки массива
    public class Point :  IComparable<Point>
    {
        private double x;
        private double y;
        private double rez;

        public Point() { }

        //Столбец, строка, значение
        public Point(double x1, double x2, double value)
        {
            x = x1;
            y = x2;
            rez = value;
        }
        //Свойства точек в системе координат
        public double x1 //столбец
        {
            get { return x; }
            set { x = value; }
        }
        public double x2 //строка
        {
            get { return y; }
            set { y = value; }
        }
        public double value
        {
            get { return rez; }
            set { rez = value; }
        }

        public int CompareTo(Point t)
        {            
            return this.value.CompareTo(t.value);
        }
    }
}
