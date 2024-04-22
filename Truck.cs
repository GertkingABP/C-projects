
namespace lorry_db_L77
{
    public class Truck //грузовик
    {
        public int Id_truck { get; set; }
        public string Name_truck { get; set; }
        public string Number_sign { get; set; }
        public string Factor { get; set; }
        public string Volume { get; set; }
        public int Fk_id_category { get; set; }

        public Truck(int id, string name, string sign, string factor, string vol, int fk_cat)
        {
            Id_truck = id;
            Name_truck = name;
            Number_sign = sign;
            Factor = factor;
            Volume = vol;
            Fk_id_category = fk_cat;          
        }
    }
}
