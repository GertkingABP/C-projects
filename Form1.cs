using System;
using System.Windows.Forms;

namespace lorry_db_L7
{
    public partial class Form1 : Form
    {
        int a = 0;
        int count = 0;
        int lastIDTrucks = 0;
        int lastIDCategories = 0;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }        

        private void button_select_trucks_Click(object sender, EventArgs e) //кнопка вывода грузовиков
        {
            dataGridView1.ColumnHeadersVisible = true;
            button_count_trucks_of_category.Enabled = true;
            button_add_truck.Enabled = true;
            button_add_category.Enabled = false;
            button_change_truck.Enabled = false;
            button_change_category.Enabled = false;
            button_delete_truck_or_category.Enabled = false;
            button_count_trucks_of_category.Enabled = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MySqlClass.GetTrucks();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            label_info.Text = "Выведены грузовики";
            a = 1;
            count = dataGridView1.Rows.Count; // кол-во строк
        }

        private void button_select_categories_Click(object sender, EventArgs e) //кнопка вывода категорий
        {
            dataGridView1.ColumnHeadersVisible = true;
            button_count_trucks_of_category.Enabled = true;
            button_add_truck.Enabled = false;
            button_add_category.Enabled = true;
            button_change_truck.Enabled = false;
            button_change_category.Enabled = false;
            button_delete_truck_or_category.Enabled = false;
            button_count_trucks_of_category.Enabled = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MySqlClass.GetCategories();
            dataGridView1.Columns[0].Visible = false;
            label_info.Text = "Выведены категории";
            a = 2;
            count = dataGridView1.Rows.Count; // кол-во строк
        }

        private void button_select_trucks_and_categories_Click(object sender, EventArgs e) //кнопка вывода грузовиков и категорий через join без id
        {
            dataGridView1.ColumnHeadersVisible = true;
            button_count_trucks_of_category.Enabled = false;
            button_add_truck.Enabled = true;
            button_add_category.Enabled = false;
            button_change_truck.Enabled = false;
            button_change_category.Enabled = false;
            button_delete_truck_or_category.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MySqlClass.GetTrucksAndCategories();
            label_info.Text = "Выведены грузовики и категории";
            a = 3;
            count = dataGridView1.Rows.Count; // кол-во строк
        }

        private void button_add_truck_Click(object sender, EventArgs e) //кнопка добавления грузовика
        {
            dataGridView1.ColumnHeadersVisible = true;

            try
            {
                if (textBox_name_truck.Text.Length != 0)
                {
                    if (textBox_number_sign.Text.Length != 0)
                    {
                        if (textBox_factor.Text.Length != 0)
                        {
                            if (textBox_volume.Text.Length != 0)
                            {
                                if (textBox_fk_id_category.Text.Length != 0)
                                {
                                    string name = textBox_name_truck.Text;
                                    string number = textBox_number_sign.Text;
                                    string fac = textBox_factor.Text;
                                    string vol = textBox_volume.Text;                                                                             
                                    int id = MySqlClass.GetIdCategory(textBox_fk_id_category.Text);                  
                                    int rez = MySqlClass.AddTruck(name, number, fac, vol, id);

                                    if (rez == 2)
                                    {
                                        button_select_trucks_Click(sender, e); // повторное нажатие вывода грузовиков
                                        button_select_trucks_and_categories_Click(sender, e);
                                        label_info.Text = "Грузовик добавлен";
                                    }

                                    if (rez == 1)
                                    {
                                        label_info.Text = "Категории с указанным названием нет";
                                    }
                                }
                            }
                        }
                    }
                }

                if (textBox_fk_id_category.Text.Length == 0)
                {
                    label_info.Text = "Введите категорию грузовика";
                }

                if ((!textBox_volume.Text.StartsWith("1")) & (!textBox_volume.Text.StartsWith("2")) & (!textBox_volume.Text.StartsWith("3")) 
                    & (!textBox_volume.Text.StartsWith("4")) & (!textBox_volume.Text.StartsWith("5")) & (!textBox_volume.Text.StartsWith("6")) 
                    & (!textBox_volume.Text.StartsWith("7")) & (!textBox_volume.Text.StartsWith("8")) & (!textBox_volume.Text.StartsWith("9")))
                {
                    label_info.Text = "Объём грузовика должен быть десятичным числом";
                }

                if (textBox_volume.Text.Length == 0)
                {
                    label_info.Text = "Введите объём грузовика";
                }

                if ((!textBox_factor.Text.StartsWith("1")) & (!textBox_factor.Text.StartsWith("2")) & (!textBox_factor.Text.StartsWith("3"))
                    & (!textBox_factor.Text.StartsWith("4")) & (!textBox_factor.Text.StartsWith("5")) & (!textBox_factor.Text.StartsWith("6"))
                    & (!textBox_factor.Text.StartsWith("7")) & (!textBox_factor.Text.StartsWith("8")) & (!textBox_factor.Text.StartsWith("9")))
                {
                    label_info.Text = "Коэффициент грузовика должен быть десятичным числом";
                }

                if (textBox_factor.Text.Length == 0)
                {
                    label_info.Text = "Введите коэффициент грузовика";
                }

                if (textBox_number_sign.Text.Length == 0)
                {
                    label_info.Text = "Введите госномер грузовика";
                }

                if (textBox_name_truck.Text.Length == 0)
                {
                    label_info.Text = "Введите название грузовика";
                }
            }

            catch
            {
                label_info.Text = "Не удалось добавить грузовик";
            }
        }
         
        private void button_add_category_Click(object sender, EventArgs e) //кнопка добавления категории
        {
            dataGridView1.ColumnHeadersVisible = true;

            try
            {
                if (textBox_fk_id_category.Text.Length != 0)
                {    
                    string name = textBox_fk_id_category.Text;
               
                    int rez = MySqlClass.AddCategory(name);

                    if (rez == 2)
                    {
                        button_select_categories_Click(sender, e); // повторное нажатие вывода категорий
                        label_info.Text = "Категория добавлена";
                    }

                    if (rez == 1)
                    {
                        label_info.Text = "Название слишком длинное или такое имя категории уже есть";
                    }               
                }

                if (textBox_fk_id_category.Text.Length == 0)
                {
                    label_info.Text = "Введите название категории";
                }
            }
            catch
            {
                label_info.Text = "Не удалось добавить категорию";         
            }
        }

        private void button_delete_truck_or_category_Click_1(object sender, EventArgs e) //кнопка удаления строки грузовика (или категории)
        {
            dataGridView1.ColumnHeadersVisible = true;

            if (dataGridView1.Rows.Count > 0)
             {
                 if (a == 1) // до этого была нажата кнопка грузовика
                 {

                     lastIDTrucks = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

                     MySqlClass.DeleteTruck(lastIDTrucks);
                     button_select_trucks_Click(sender, e); //для моментального обновления таблицы делаю повторное нажатие
                     button_select_trucks_and_categories_Click(sender, e);
                     label_info.Text = "Грузовик по выбранной строке удалён";
                 }

                 if (a == 2) // до этого была нажата кнопка вывода категорий
                 {
                     lastIDCategories = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

                     int t = 0;
                     t = MySqlClass.DeleteCategory(lastIDCategories);

                     if (t == 2)
                     {

                         button_select_categories_Click(sender, e); //для моментального обновления таблицы повторное нажатие
                         label_info.Text = "Категория удалена";
                     }

                     if (t == 1)
                     {

                         /*button_select_categories_Click(sender, e); //для моментального обновления таблицы повторное нажатие
                         label_info.Text = "Не удалось удалить, так как выбранная категория есть у одного из грузовиков";*/
                     }
                 }
             }  
        }

        private void button_change_truck_Click(object sender, EventArgs e) //кнопка изменения грузовика
        {
            dataGridView1.ColumnHeadersVisible = true;

            try
            {
                if (textBox_name_truck.Text.Length != 0)
                {
                    if (textBox_number_sign.Text.Length != 0)
                    {
                        if (textBox_factor.Text.Length != 0)
                        {
                            if (textBox_volume.Text.Length != 0)
                            {
                                if (textBox_fk_id_category.Text.Length != 0)
                                {
                                    int i = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                                    string name = textBox_name_truck.Text;
                                    string number = textBox_number_sign.Text;
                                    string fac = textBox_factor.Text;
                                    string vol = textBox_volume.Text;
                                    int id = MySqlClass.GetIdCategory(textBox_fk_id_category.Text);
                                    int rez = MySqlClass.UpdateTruck(i, name, number, fac, vol, id);

                                    if (rez == 2)
                                    {
                                        button_select_trucks_Click(sender, e); // повторное нажатие вывода грузовиков
                                        label_info.Text = "Грузовик изменен";
                                    }

                                    if (rez == 1)
                                    {
                                        label_info.Text = "Категории с указанным названием нет";
                                    }
                                }
                            }
                        }
                    }
                }

                if (textBox_fk_id_category.Text.Length == 0)
                {
                    label_info.Text = "Введите категорию грузовика";
                }

                if (textBox_volume.Text.Length == 0)
                {
                    label_info.Text = "Введите объём грузовика";
                }

                if (textBox_factor.Text.Length == 0)
                {
                    label_info.Text = "Введите коэффициент грузовика";
                }

                if (textBox_number_sign.Text.Length == 0)
                {
                    label_info.Text = "Введите госномер грузовика";
                }

                if (textBox_name_truck.Text.Length == 0)
                {
                    label_info.Text = "Введите название грузовика";
                }
            }

            catch
            {
                label_info.Text = "Не удалось изменить грузовик";
            }
        }

        private void button_change_category_Click(object sender, EventArgs e) //кнопка изменения категории
        {
            dataGridView1.ColumnHeadersVisible = true;
            int i = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value); // выбранная строка для изменения

            if (textBox_fk_id_category.Text.Length == 0)
            {
                label_info.Text = "Напишите новое название";
            }

            if (textBox_fk_id_category.Text.Length != 0)
            {
                string new_name = textBox_fk_id_category.Text;

                int rez = MySqlClass.UpdateCategory(i, new_name);

                if (rez == 2) //получилось
                {
                    button_select_categories_Click(sender, e); // повторное нажатие вывода категорий
                    label_info.Text = "Категория изменена ";
                }

                if (rez == 1) //не получилось
                {
                    label_info.Text = "Выбранное имя занято";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            button_delete_truck_or_category.Enabled = false;
            dataGridView1.ColumnHeadersVisible = true;

            if (a == 1)
            { 
                button_change_truck.Enabled = true;
                button_delete_truck_or_category.Enabled = true;
            }

            else if (a == 2)
            {
                button_delete_truck_or_category.Enabled = true;
                button_change_category.Enabled = true;
                button_count_trucks_of_category.Enabled = true;
            }    
        }

        private void button_count_trucks_of_category_Click(object sender, EventArgs e) //число грузовиков выделенной категории
        {
            dataGridView1.ColumnHeadersVisible = true;
            int i = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value); //id категории, который скрыт        
            label_info.Text = "В данной категории " + MySqlClass.CountTrucksOfCategory(i) + " грузовик(-а)(-ов)";                        
        }

        private void button_select_trucks_1_name_Click(object sender, EventArgs e) //вывод грузовиков с одинаковыми названиями
        {
            button_delete_truck_or_category.Enabled = false;
            button_count_trucks_of_category.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MySqlClass.Trucks1Name(textBox_name_truck.Text);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersVisible = false;

            label_info.Text = "Выведены грузовики, имеющие общее название";
            count = dataGridView1.Rows.Count; // кол-во строк
        }

        private void button_select_trucks_lower_volume_Click(object sender, EventArgs e) //грузовики, у которых объём меньше указанного в поле
        {
            //button_count_trucks_of_category.Enabled = false;
            button_delete_truck_or_category.Enabled = false;
            dataGridView1.DataSource = null;

            if (textBox_volume.Text.Length == 0)
            {
                label_info.Text = "Введите объём для выборки";
            }

            else if ((!textBox_volume.Text.StartsWith("1")) & (!textBox_volume.Text.StartsWith("2")) & (!textBox_volume.Text.StartsWith("3"))
                    & (!textBox_volume.Text.StartsWith("4")) & (!textBox_volume.Text.StartsWith("5")) & (!textBox_volume.Text.StartsWith("6"))
                    & (!textBox_volume.Text.StartsWith("7")) & (!textBox_volume.Text.StartsWith("8")) & (!textBox_volume.Text.StartsWith("9")))
            {
                label_info.Text = "Для выборки нужно ввести дробное число";
            }

            else
            {
                label_info.Text = "Выведены грузовики, у которых объём меньше указанного";
                dataGridView1.DataSource = MySqlClass.TrucksLowerVolume(textBox_volume.Text);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.ColumnHeadersVisible = false;
                count = dataGridView1.Rows.Count; // кол-во строк
            }
        }
    }
}
