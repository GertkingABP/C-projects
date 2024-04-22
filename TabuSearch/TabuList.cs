using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabuSearch
{
    public class TabuList<T> 
    {
        private Queue<Point> myQueue = new Queue<Point>();
        private int tabu_list_length;

        public int TLL //длина списка запретов
        {
            get { return tabu_list_length; }
            set { tabu_list_length = value; }
        }

        public void addTabu(Point c) //добавить запрет
        {
            if (myQueue.Count() >= this.TLL)
            {
                this.removeTabu();
            }
            myQueue.Enqueue(c);
        }

        public void removeTabu() //убрать запрет
        {
            myQueue.Dequeue();
        }

        public bool containsTabu(Point c) //содержится ли запрет
        {
            var x = from t in myQueue where t.x1 == c.x1 && t.x2 == c.x2 && t.value == c.value select t;
            return x.Count() > 0;  //возвращает TRUE, если в myQueue существует точка, в противном случае возвращает FALSE!
        }        
    }
}
