 
namespace lorry_db_L77
{
    public class TruckAndCategory //грузовик и его категория
    {
        public string Name_truck { get; set; }
        public string Number_sign { get; set; }
        public string Factor { get; set; }
        public string Volume { get; set; }
        public string Name_category { get; set; }

        public TruckAndCategory(string name, string sign, string factor, string vol, string cat)
        {
            Name_truck = name;
            Number_sign = sign;
            Factor = factor;
            Volume = vol;
            Name_category = cat;
        }
    }
}
