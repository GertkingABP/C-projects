
namespace lorry_db_L7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_info = new System.Windows.Forms.Label();
            this.button_select_trucks = new System.Windows.Forms.Button();
            this.button_select_categories = new System.Windows.Forms.Button();
            this.button_select_trucks_and_categories = new System.Windows.Forms.Button();
            this.button_add_truck = new System.Windows.Forms.Button();
            this.button_add_category = new System.Windows.Forms.Button();
            this.button_delete_truck_or_category = new System.Windows.Forms.Button();
            this.textBox_name_truck = new System.Windows.Forms.TextBox();
            this.textBox_number_sign = new System.Windows.Forms.TextBox();
            this.textBox_factor = new System.Windows.Forms.TextBox();
            this.textBox_volume = new System.Windows.Forms.TextBox();
            this.textBox_fk_id_category = new System.Windows.Forms.TextBox();
            this.label_name_truck = new System.Windows.Forms.Label();
            this.label_number_sign = new System.Windows.Forms.Label();
            this.label_factor = new System.Windows.Forms.Label();
            this.label_volume = new System.Windows.Forms.Label();
            this.label_fk_id_category = new System.Windows.Forms.Label();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.button_count_trucks_of_category = new System.Windows.Forms.Button();
            this.button_change_truck = new System.Windows.Forms.Button();
            this.button_change_category = new System.Windows.Forms.Button();
            this.button_select_trucks_1_name = new System.Windows.Forms.Button();
            this.button_select_trucks_lower_volume = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(287, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(481, 178);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info.Location = new System.Drawing.Point(357, 58);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(270, 16);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "Здесь будет отображаться информация";
            // 
            // button_select_trucks
            // 
            this.button_select_trucks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_select_trucks.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select_trucks.Location = new System.Drawing.Point(13, 286);
            this.button_select_trucks.Name = "button_select_trucks";
            this.button_select_trucks.Size = new System.Drawing.Size(178, 23);
            this.button_select_trucks.TabIndex = 3;
            this.button_select_trucks.Text = "Вывести все грузовики";
            this.button_select_trucks.UseVisualStyleBackColor = false;
            this.button_select_trucks.Click += new System.EventHandler(this.button_select_trucks_Click);
            // 
            // button_select_categories
            // 
            this.button_select_categories.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_select_categories.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select_categories.Location = new System.Drawing.Point(13, 337);
            this.button_select_categories.Name = "button_select_categories";
            this.button_select_categories.Size = new System.Drawing.Size(178, 23);
            this.button_select_categories.TabIndex = 4;
            this.button_select_categories.Text = "Вывести все категории";
            this.button_select_categories.UseVisualStyleBackColor = false;
            this.button_select_categories.Click += new System.EventHandler(this.button_select_categories_Click);
            // 
            // button_select_trucks_and_categories
            // 
            this.button_select_trucks_and_categories.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_select_trucks_and_categories.Location = new System.Drawing.Point(13, 382);
            this.button_select_trucks_and_categories.Name = "button_select_trucks_and_categories";
            this.button_select_trucks_and_categories.Size = new System.Drawing.Size(178, 23);
            this.button_select_trucks_and_categories.TabIndex = 5;
            this.button_select_trucks_and_categories.Text = "Вывести грузовики и категории";
            this.button_select_trucks_and_categories.UseVisualStyleBackColor = true;
            this.button_select_trucks_and_categories.Click += new System.EventHandler(this.button_select_trucks_and_categories_Click);
            // 
            // button_add_truck
            // 
            this.button_add_truck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_add_truck.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_add_truck.Enabled = false;
            this.button_add_truck.Location = new System.Drawing.Point(207, 286);
            this.button_add_truck.Name = "button_add_truck";
            this.button_add_truck.Size = new System.Drawing.Size(178, 23);
            this.button_add_truck.TabIndex = 6;
            this.button_add_truck.Text = "Добавить грузовик";
            this.button_add_truck.UseVisualStyleBackColor = false;
            this.button_add_truck.Click += new System.EventHandler(this.button_add_truck_Click);
            // 
            // button_add_category
            // 
            this.button_add_category.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_add_category.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_add_category.Enabled = false;
            this.button_add_category.Location = new System.Drawing.Point(207, 337);
            this.button_add_category.Name = "button_add_category";
            this.button_add_category.Size = new System.Drawing.Size(178, 23);
            this.button_add_category.TabIndex = 7;
            this.button_add_category.Text = "Добавить категорию";
            this.button_add_category.UseVisualStyleBackColor = false;
            this.button_add_category.Click += new System.EventHandler(this.button_add_category_Click);
            // 
            // button_delete_truck_or_category
            // 
            this.button_delete_truck_or_category.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_delete_truck_or_category.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_delete_truck_or_category.Enabled = false;
            this.button_delete_truck_or_category.Location = new System.Drawing.Point(301, 382);
            this.button_delete_truck_or_category.Name = "button_delete_truck_or_category";
            this.button_delete_truck_or_category.Size = new System.Drawing.Size(178, 23);
            this.button_delete_truck_or_category.TabIndex = 8;
            this.button_delete_truck_or_category.Text = "Удалить строку";
            this.button_delete_truck_or_category.UseVisualStyleBackColor = false;
            this.button_delete_truck_or_category.Click += new System.EventHandler(this.button_delete_truck_or_category_Click_1);
            // 
            // textBox_name_truck
            // 
            this.textBox_name_truck.Location = new System.Drawing.Point(13, 25);
            this.textBox_name_truck.Name = "textBox_name_truck";
            this.textBox_name_truck.Size = new System.Drawing.Size(128, 20);
            this.textBox_name_truck.TabIndex = 10;
            // 
            // textBox_number_sign
            // 
            this.textBox_number_sign.Location = new System.Drawing.Point(12, 77);
            this.textBox_number_sign.Name = "textBox_number_sign";
            this.textBox_number_sign.Size = new System.Drawing.Size(129, 20);
            this.textBox_number_sign.TabIndex = 11;
            // 
            // textBox_factor
            // 
            this.textBox_factor.Location = new System.Drawing.Point(12, 129);
            this.textBox_factor.Name = "textBox_factor";
            this.textBox_factor.Size = new System.Drawing.Size(129, 20);
            this.textBox_factor.TabIndex = 12;
            // 
            // textBox_volume
            // 
            this.textBox_volume.Location = new System.Drawing.Point(12, 185);
            this.textBox_volume.Name = "textBox_volume";
            this.textBox_volume.Size = new System.Drawing.Size(129, 20);
            this.textBox_volume.TabIndex = 13;
            // 
            // textBox_fk_id_category
            // 
            this.textBox_fk_id_category.Location = new System.Drawing.Point(12, 245);
            this.textBox_fk_id_category.Name = "textBox_fk_id_category";
            this.textBox_fk_id_category.Size = new System.Drawing.Size(129, 20);
            this.textBox_fk_id_category.TabIndex = 14;
            // 
            // label_name_truck
            // 
            this.label_name_truck.AutoSize = true;
            this.label_name_truck.Location = new System.Drawing.Point(9, 9);
            this.label_name_truck.Name = "label_name_truck";
            this.label_name_truck.Size = new System.Drawing.Size(112, 13);
            this.label_name_truck.TabIndex = 15;
            this.label_name_truck.Text = "Название грузовика";
            // 
            // label_number_sign
            // 
            this.label_number_sign.AutoSize = true;
            this.label_number_sign.Location = new System.Drawing.Point(9, 61);
            this.label_number_sign.Name = "label_number_sign";
            this.label_number_sign.Size = new System.Drawing.Size(112, 13);
            this.label_number_sign.TabIndex = 16;
            this.label_number_sign.Text = "Госномер грузовика";
            // 
            // label_factor
            // 
            this.label_factor.AutoSize = true;
            this.label_factor.Location = new System.Drawing.Point(9, 113);
            this.label_factor.Name = "label_factor";
            this.label_factor.Size = new System.Drawing.Size(132, 13);
            this.label_factor.TabIndex = 17;
            this.label_factor.Text = "Коэффициент грузовика";
            // 
            // label_volume
            // 
            this.label_volume.AutoSize = true;
            this.label_volume.Location = new System.Drawing.Point(9, 169);
            this.label_volume.Name = "label_volume";
            this.label_volume.Size = new System.Drawing.Size(97, 13);
            this.label_volume.TabIndex = 18;
            this.label_volume.Text = "Объём грузовика";
            // 
            // label_fk_id_category
            // 
            this.label_fk_id_category.AutoSize = true;
            this.label_fk_id_category.Location = new System.Drawing.Point(10, 229);
            this.label_fk_id_category.Name = "label_fk_id_category";
            this.label_fk_id_category.Size = new System.Drawing.Size(115, 13);
            this.label_fk_id_category.TabIndex = 19;
            this.label_fk_id_category.Text = "Категория грузовика";
            // 
            // button_count_trucks_of_category
            // 
            this.button_count_trucks_of_category.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_count_trucks_of_category.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_count_trucks_of_category.Enabled = false;
            this.button_count_trucks_of_category.Location = new System.Drawing.Point(599, 286);
            this.button_count_trucks_of_category.Name = "button_count_trucks_of_category";
            this.button_count_trucks_of_category.Size = new System.Drawing.Size(169, 36);
            this.button_count_trucks_of_category.TabIndex = 22;
            this.button_count_trucks_of_category.Text = "Кол-во грузовиков данной категории";
            this.button_count_trucks_of_category.UseVisualStyleBackColor = false;
            this.button_count_trucks_of_category.Click += new System.EventHandler(this.button_count_trucks_of_category_Click);
            // 
            // button_change_truck
            // 
            this.button_change_truck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_change_truck.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_change_truck.Enabled = false;
            this.button_change_truck.Location = new System.Drawing.Point(402, 286);
            this.button_change_truck.Name = "button_change_truck";
            this.button_change_truck.Size = new System.Drawing.Size(178, 23);
            this.button_change_truck.TabIndex = 23;
            this.button_change_truck.Text = "Изменить грузовик";
            this.button_change_truck.UseVisualStyleBackColor = false;
            this.button_change_truck.Click += new System.EventHandler(this.button_change_truck_Click);
            // 
            // button_change_category
            // 
            this.button_change_category.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_change_category.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_change_category.Enabled = false;
            this.button_change_category.Location = new System.Drawing.Point(402, 337);
            this.button_change_category.Name = "button_change_category";
            this.button_change_category.Size = new System.Drawing.Size(178, 23);
            this.button_change_category.TabIndex = 24;
            this.button_change_category.Text = "Изменить категорию";
            this.button_change_category.UseVisualStyleBackColor = false;
            this.button_change_category.Click += new System.EventHandler(this.button_change_category_Click);
            // 
            // button_select_trucks_1_name
            // 
            this.button_select_trucks_1_name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_select_trucks_1_name.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select_trucks_1_name.Location = new System.Drawing.Point(599, 331);
            this.button_select_trucks_1_name.Name = "button_select_trucks_1_name";
            this.button_select_trucks_1_name.Size = new System.Drawing.Size(169, 35);
            this.button_select_trucks_1_name.TabIndex = 25;
            this.button_select_trucks_1_name.Text = "Вывести все грузовики по одному имени";
            this.button_select_trucks_1_name.UseVisualStyleBackColor = false;
            this.button_select_trucks_1_name.Click += new System.EventHandler(this.button_select_trucks_1_name_Click);
            // 
            // button_select_trucks_lower_volume
            // 
            this.button_select_trucks_lower_volume.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_select_trucks_lower_volume.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select_trucks_lower_volume.Location = new System.Drawing.Point(599, 378);
            this.button_select_trucks_lower_volume.Name = "button_select_trucks_lower_volume";
            this.button_select_trucks_lower_volume.Size = new System.Drawing.Size(169, 35);
            this.button_select_trucks_lower_volume.TabIndex = 26;
            this.button_select_trucks_lower_volume.Text = "Вывести грузовики, объём которых меньше указанного";
            this.button_select_trucks_lower_volume.UseVisualStyleBackColor = false;
            this.button_select_trucks_lower_volume.Click += new System.EventHandler(this.button_select_trucks_lower_volume_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(780, 421);
            this.Controls.Add(this.button_select_trucks_lower_volume);
            this.Controls.Add(this.button_select_trucks_1_name);
            this.Controls.Add(this.button_change_category);
            this.Controls.Add(this.button_change_truck);
            this.Controls.Add(this.button_count_trucks_of_category);
            this.Controls.Add(this.label_fk_id_category);
            this.Controls.Add(this.label_volume);
            this.Controls.Add(this.label_factor);
            this.Controls.Add(this.label_number_sign);
            this.Controls.Add(this.label_name_truck);
            this.Controls.Add(this.textBox_fk_id_category);
            this.Controls.Add(this.textBox_volume);
            this.Controls.Add(this.textBox_factor);
            this.Controls.Add(this.textBox_number_sign);
            this.Controls.Add(this.textBox_name_truck);
            this.Controls.Add(this.button_delete_truck_or_category);
            this.Controls.Add(this.button_add_category);
            this.Controls.Add(this.button_add_truck);
            this.Controls.Add(this.button_select_trucks_and_categories);
            this.Controls.Add(this.button_select_categories);
            this.Controls.Add(this.button_select_trucks);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(910, 650);
            this.MinimumSize = new System.Drawing.Size(796, 452);
            this.Name = "Form1";
            this.Text = "WorkBench";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button_select_trucks;
        private System.Windows.Forms.Button button_select_categories;
        private System.Windows.Forms.Button button_select_trucks_and_categories;
        private System.Windows.Forms.Button button_add_truck;
        private System.Windows.Forms.Button button_add_category;
        private System.Windows.Forms.Button button_delete_truck_or_category;
        private System.Windows.Forms.TextBox textBox_name_truck;
        private System.Windows.Forms.TextBox textBox_number_sign;
        private System.Windows.Forms.TextBox textBox_factor;
        private System.Windows.Forms.TextBox textBox_volume;
        private System.Windows.Forms.TextBox textBox_fk_id_category;
        private System.Windows.Forms.Label label_name_truck;
        private System.Windows.Forms.Label label_number_sign;
        private System.Windows.Forms.Label label_factor;
        private System.Windows.Forms.Label label_volume;
        private System.Windows.Forms.Label label_fk_id_category;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.Button button_count_trucks_of_category;
        private System.Windows.Forms.Button button_change_truck;
        private System.Windows.Forms.Button button_change_category;
        private System.Windows.Forms.Button button_select_trucks_1_name;
        private System.Windows.Forms.Button button_select_trucks_lower_volume;
    }
}

