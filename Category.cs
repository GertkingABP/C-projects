
namespace lorry_db_L77
{
    public class Category //категория транспорта
    {
        public int Id_category { get; set; }
        public string Name_category { get; set; }


        public Category(int id, string name)
        {
            Id_category = id;
            Name_category = name;
        }
    }
}
