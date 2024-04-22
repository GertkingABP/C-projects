using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lorry_db_L77
{
    public class Flight
    {
        public int Id_flight { get; set; }
        public string Status_f { get; set; }
        public string Director_full_name { get; set; }
        public DateTime Date_time_start { get; set; }
        public DateTime Date_time_end { get; set; }
        public int Number_f { get; set; }
        public int Base_price { get; set; }
        public int Fk_id_truck { get; set; }
        public int Fk_id_worker { get; set; }
        public int Fk_id_city1 { get; set; }
        public int Fk_id_city2 { get; set; }
        public int Fk_id_driver1 { get; set; }
        public int Fk_id_driver2 { get; set; }
        public int Fk_id_customer { get; set; }

        public Flight(int id_f, string status, string director, DateTime d1, DateTime d2, int num, int price, int fk_tr, int fk_w, int fk_c1, int fk_c2, int fk_dr1, int fk_dr2, int fk_cus)
        {
            Id_flight = id_f;
            Status_f = status;
            Director_full_name = director;
            Date_time_start = d1;
            Date_time_end = d2;
            Number_f = num;
            Base_price = price;
            Fk_id_truck = fk_tr;
            Fk_id_worker = fk_w;
            Fk_id_city1 = fk_c1;
            Fk_id_city2 = fk_c2;
            Fk_id_driver1 = fk_dr1;
            Fk_id_driver2 = fk_dr2;
            Fk_id_customer = fk_cus;
        }
    }
}
