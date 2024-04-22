using System.Collections.Generic;
using lorry_db_L77; 
using MySql.Data.MySqlClient;

namespace lorry_db_L7
{
    class MySqlClass
    {
        /*----------------------------------------------------------1.Получение данных из существующей БД----------------------------------------------------------*/

        public static Truck[] GetTrucks() //получение грузовиков
        {
            var trucks = new List<Truck>();
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "select * from truck";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                trucks.Add(new Truck(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
            }

            return trucks.ToArray();
            connection.Close();
            command.Dispose();
            reader.Close();
        }

        public static Category[] GetCategories() //получение категорий
        {
            var categories = new List<Category>();
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "select * from category";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Category(reader.GetInt32(0), reader.GetString(1)));
            }

            return categories.ToArray();
            connection.Close();
            command.Dispose();
            reader.Close();
        }

        public static TruckAndCategory[] GetTrucksAndCategories() //получение грузовиков и категорий
        {
            var trucks_and_categories = new List<TruckAndCategory>();
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "select truck.name_truck, truck.number_sign, truck.factor, truck.volume, category.name_category from truck " +
                "join category on truck.fk_id_category = category.id_category";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                trucks_and_categories.Add(new TruckAndCategory(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
            }

            return trucks_and_categories.ToArray();
            connection.Close();
            command.Dispose();
            reader.Close();
        }

        /*--------------------------------------------------------------------2.Добавление данных--------------------------------------------------------------------*/

        public static int GetIdCategory(string name) //получить id категории по её имени
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var commamd = connection.CreateCommand();

            try
            {
                var command = new MySqlCommand("select id_category from category where name_category = @name;", connection);
                command.Parameters.AddWithValue("@name", name);
                var reader = command.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }

                connection.Close();
                commamd.Dispose();
                reader.Close();

                return count;
            }

            catch
            {
                return 0;
            }
        }

        public static int AddTruck(string name, string number, string fac, string vol, int id_categ) //добавление грузовика
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            try
            {
                var commamd = connection.CreateCommand();
              
                //параметризация запроса:
                var command = new MySqlCommand("insert into truck (name_truck, number_sign, factor, volume, fk_id_category) values ( @name, @number, @fac, @vol, @id_categ); ", connection);
                MySqlParameter param2 = new MySqlParameter("@name", name);
                command.Parameters.Add(param2);
                MySqlParameter param3 = new MySqlParameter("@number", number);
                command.Parameters.Add(param3);
                MySqlParameter param4 = new MySqlParameter("@fac", fac);
                command.Parameters.Add(param4);
                MySqlParameter param5 = new MySqlParameter("@vol", vol);
                command.Parameters.Add(param5);
                MySqlParameter param6 = new MySqlParameter("@id_categ", id_categ);
                command.Parameters.Add(param6);
                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }

            catch
            {
                return 1; // 1 если не удалось добавить грузовик
            }

            return 2; //2 если удалось
        }

        public static int AddCategory(string name) //добавление категории
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            try
            {
                var commamd = connection.CreateCommand();

                //параметризация запроса:
                var command = new MySqlCommand("insert into category (name_category) values (@name); ", connection);
                MySqlParameter param2 = new MySqlParameter("@name", name);
                command.Parameters.Add(param2);
                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }

            catch
            {
                return 1; // 1 если не удалось добавить категорию
            }

            return 2; //2 если удалось
        }

        /*-----------------------------------------------------------3.Удаление данных-----------------------------------------------------------*/


        public static int DeleteTruck(int id) //удаление грузовика
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var commamd = connection.CreateCommand();
            
            try
            {
                var command = new MySqlCommand("delete from truck where id_truck = @id;", connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                connection.Close();
                commamd.Dispose();
                reader.Close();
                return 2;
            }

            catch
            {
                return 1;
            }           
        }


        public static int DeleteCategory(int id) //удаление категории
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var commamd = connection.CreateCommand();

            try
            {
                var command = new MySqlCommand("delete from category where id_category = @id;", connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                connection.Close();
                commamd.Dispose();
                reader.Close();
                return 2;
            }

            catch
            {
                return 1;
            }
        }

        /*---------------------------------------------------4.Изменить строки данных---------------------------------------------------*/
        public static int UpdateTruck(int id, string name, string number, string fac, string vol, int id_categ) //изменить грузовик
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            try
            {
                var commamd = connection.CreateCommand();

                //параметризация запроса:
                var command = new MySqlCommand("update truck set name_truck = @name, number_sign = @number , factor = @fac, volume = @vol, fk_id_category = @id_categ where id_truck = @id;", connection);

                MySqlParameter param1 = new MySqlParameter("@name", name);
                command.Parameters.Add(param1);
                MySqlParameter param2 = new MySqlParameter("@number", number);
                command.Parameters.Add(param2);
                MySqlParameter param3 = new MySqlParameter("@fac", fac);
                command.Parameters.Add(param3);
                MySqlParameter param4 = new MySqlParameter("@vol", vol);
                command.Parameters.Add(param4);
                MySqlParameter param5 = new MySqlParameter("@id_categ", id_categ);
                command.Parameters.Add(param5);
                MySqlParameter param6 = new MySqlParameter("@id", id);
                command.Parameters.Add(param6);

                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }

            catch
            {
                return 1; // 1 если не удалось обновить
            }

            return 2; //2 если удалось
        }


        public static int UpdateCategory(int id, string name) //изменить категорию
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            try
            {
                var commamd = connection.CreateCommand();
     
                //параметризация запроса:
                var command = new MySqlCommand("update category set name_category = @name where id_category = @id; ", connection);
                MySqlParameter param1 = new MySqlParameter("@id", id);
                command.Parameters.Add(param1);
                MySqlParameter param2 = new MySqlParameter("@name", name);
                command.Parameters.Add(param2);

                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }

            catch
            {
                return 1; // 1 если не удалось обновить категорию
            }
            return 2; //2 если удалось
        }

        /*------------------------------------------------------------5.Аналитические запросы------------------------------------------------------------*/

        public static int CountTrucksOfCategory(int id) //кол-во грузовиков выбранной категории из таблицы категорий
        {
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var commamd = connection.CreateCommand();
            var command = new MySqlCommand("select count(id_truck) from truck where fk_id_category = @id;", connection);
            command.Parameters.AddWithValue("id", id);
            var reader = command.ExecuteReader();
            int count = 0;

            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            connection.Close();
            commamd.Dispose();
            reader.Close();

            return count;
        }

        public static TruckAndCategory[] Trucks1Name(string name) //вывести грузовики с названиями, имеющими общее вхождение поля имени грузовика
        {
            var trucks_categories = new List<TruckAndCategory>();
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var commamd = connection.CreateCommand();
            var command = new MySqlCommand("select * from truck where name_truck like @name;", connection);
            command.Parameters.AddWithValue("name", name);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                trucks_categories.Add(new TruckAndCategory(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
            }

            return trucks_categories.ToArray();
            connection.Close();
            commamd.Dispose();
            reader.Close();
        }

        public static TruckAndCategory[] TrucksLowerVolume(string name) //вывести грузовики меньшего объёма
        {
            var trucks_categories = new List<TruckAndCategory>();
            var connectionString = "Server=localhost;Database=lorry_db7;Uid=root;Pwd=Lenya838MSX;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var commamd = connection.CreateCommand();
            var command = new MySqlCommand("select * from truck where volume < @name;", connection);
            command.Parameters.AddWithValue("name", name);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                trucks_categories.Add(new TruckAndCategory(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
            }

            return trucks_categories.ToArray();
            connection.Close();
            commamd.Dispose();
            reader.Close();
        }
    }
}
