/*1)Создаём БД без таблиц*/

create database lorry_db7;/*сама БД*/
use lorry_db7;/*использование БД*/
show databases;/*отображение всех БД*/
show create database lorry_db7;/*отображение созданной БД*/

/*2)Таблицы данных*/

/*Рабочий*/
CREATE TABLE worker (
    id_worker INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(45) NOT NULL,
    phone_number VARCHAR(12) NOT NULL
);

/*Город*/
CREATE TABLE city (
    id_city INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name_city VARCHAR(45) NOT NULL
);

/*Водитель*/
CREATE TABLE driver (
    id_driver INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    full_name_driver VARCHAR(45) NOT NULL
);

/*Тип груза*/    
CREATE TABLE type_cargo (
    id_type_cargo INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name_type_cargo VARCHAR(45) NOT NULL,
    factor_cargo DOUBLE NOT NULL
);
 
/*Категория*/ 
CREATE TABLE category (
    id_category INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name_category VARCHAR(3) NOT NULL
);

/*Тип заказчика*/
CREATE TABLE type_customer (
    id_type_customer INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name_type VARCHAR(20) NOT NULL
);
   
/*многие ко многим для водителя и категории*/   
CREATE TABLE driver_to_category (
    fk_id_driver INT NOT NULL,
    fk_id_category INT NOT NULL,
    PRIMARY KEY (fk_id_driver , fk_id_category) ,
    FOREIGN KEY (fk_id_driver)
	REFERENCES driver (id_driver) on delete cascade,
    FOREIGN KEY (fk_id_category)
	REFERENCES category (id_category) on delete cascade
);
 
/*Заказчик*/ 
CREATE TABLE customer (
    id_customer INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(45) NOT NULL,
    phone_number_c VARCHAR(12) NOT NULL,
    fk_id_type_customer INT NOT NULL,
    FOREIGN KEY (fk_id_type_customer)
	REFERENCES type_customer (id_type_customer) on delete cascade
);

/*комментарий заказчика*/
CREATE TABLE comment_c (
    id_comment INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    text_c TEXT NOT NULL,
    grade TINYINT NOT NULL,
    fk_id_customer INT NOT NULL,
    FOREIGN KEY (fk_id_customer)
	REFERENCES customer (id_customer) on delete cascade 
);
 
 /*Грузовик*/
 CREATE TABLE truck (
    id_truck INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name_truck VARCHAR(30) NOT NULL,
    number_sign VARCHAR(10) NOT NULL,
    factor VARCHAR(8) NOT NULL,
    volume VARCHAR(8) NOT NULL,
    fk_id_category INT NOT NULL,
    FOREIGN KEY (fk_id_category)
	REFERENCES category (id_category) on delete cascade
);
   
/*Многие ко многим для грузовика и типа груза*/   
CREATE TABLE truck_to_type_cargo (
    fk_id_truck INT NOT NULL,
    fk_id_type_cargo INT NOT NULL,
    PRIMARY KEY (fk_id_truck , fk_id_type_cargo),
    FOREIGN KEY (fk_id_truck)
	REFERENCES truck (id_truck) on delete cascade,
    FOREIGN KEY (fk_id_type_cargo)
	REFERENCES type_cargo (id_type_cargo) on delete cascade
);

/*Груз*/
CREATE TABLE cargo (
    id_cargo INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    volume_cargo DOUBLE NOT NULL,
    weight INT NOT NULL,
    place_loading VARCHAR(45) NOT NULL,
    place_unloading VARCHAR(45) NOT NULL,
    fk_id_type_cargo INT NOT NULL,
    FOREIGN KEY (fk_id_type_cargo)
	REFERENCES type_cargo (id_type_cargo) on delete cascade
);    

/*Рейс*/
CREATE TABLE flight (
    id_flight INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    status_f VARCHAR(45) NOT NULL,
    director_full_name VARCHAR(45) NOT NULL,
    date_time_start DATETIME NOT NULL,
    date_time_end DATETIME NOT NULL,
    number_f INT NOT NULL,
    base_price INT NOT NULL,
    fk_id_truck INT NOT NULL,
    FOREIGN KEY (fk_id_truck)
	REFERENCES truck (id_truck) on delete cascade,
    fk_id_worker INT NOT NULL,
    FOREIGN KEY (fk_id_worker)
	REFERENCES worker (id_worker) on delete cascade,
    fk_id_city1 INT NOT NULL,
    FOREIGN KEY (fk_id_city1)
	REFERENCES city (id_city) on delete cascade,
    fk_id_city2 INT NOT NULL,
    FOREIGN KEY (fk_id_city2)
	REFERENCES city (id_city) on delete cascade,
    fk_id_driver1 INT NOT NULL,
    FOREIGN KEY (fk_id_driver1)
	REFERENCES driver (id_driver) on delete cascade,
    fk_id_driver2 INT DEFAULT NULL,
    FOREIGN KEY (fk_id_driver2)
	REFERENCES driver (id_driver) on delete cascade, 
    fk_id_customer INT NOT NULL,
    FOREIGN KEY (fk_id_customer)
	REFERENCES customer (id_customer) on delete cascade 
);

/*3)Добавление столбцов как внешних ключей*/

alter table comment_c
	add column fk_id_flight int not null,
	add foreign key (fk_id_flight) references flight (id_flight) on delete cascade;
 
alter table cargo
	add column fk_id_flight int not null,
    add foreign key (fk_id_flight) references flight (id_flight) on delete cascade;
    
/*4)Заполнение таблиц*/

insert into city (name_city)
values
('Москва'),
('Волгорад'),/*update na pravilnoe*/
('Краснодар'),
('Ростов'),
('Брянск'),
('Волжский'),
('Кострома'),
('Нижний Новгород'),
('Санкт-Петербург'),
('Саратов'),
('Муха цикотуха'),/**udalit gorod*/
('Мухогород');/*ubrat ego*/
 
insert into worker (full_name, phone_number)
values
('Андреев Геннадий Степанович', 89613338345),
('Морозова Екатерина Ивановна', 89883454433),
('Степанов Данил Валерьевич', 89373332211),/*update imeny*/
('Иванова Нина Андреевна', 89889998899),
('Андреев Александр Степанович', 89112330347),
('Кузьмина Оксана Валерьевна', 89883454433);
 
insert into type_cargo (factor_cargo, name_type_cargo)
values
(1.4, 'Стройматериалы (твёрдые)'),
(1.75, 'Наливной (топливо)'),
(1.34, 'Негабаритный груз (запчасти)'),
(1.27, 'Наливной (продукты)'),
(1.42, 'Насыпной'),
(1.88, 'Штучный');/*update ego v factore*/
 
insert into driver (full_name_driver)
values
('Ванроев Иван Романович'),
('Леватов Николай Дмитриевич'),
('Костин Никита Степанович'),
('Петров Пётр Петрович');
 
insert into category (name_category)
values
('С1E'),
('D1E'),
('DE'),
('C'),
('E');/*udalit etu categoriu*/
 
insert into type_customer (name_type)
values
('ИП'),
('Физ.лицо'),/*zdelat update*/
('Компания'),
('Несуществующий тип');/*udalit tip*/
 
insert into driver_to_category (fk_id_driver, fk_id_category)
values
(1, 1),
(1, 4),
(2, 2),
(2, 3),
(3, 3),
(4, 4);    

insert into customer (title, phone_number_c, fk_id_type_customer)
values
('ИП Богданова', 554433, 1),
('Романов Андрей Петрович', 89042223311, 2),
('ОРВС', 225511, 3),
('Ушаков Иван Григорьевич', 89888689977, 2),
('ИП Скорогруз', 561422, 1),
('Никелин Константин Анатольевич', 89882326301, 2),
('Перевозчик', 250516, 3),
('ПРЕДАТЕЛЬ', 666666, 2);/*udalit ego cherez delete*/

insert into truck (name_truck, number_sign, factor, volume, fk_id_category)
values
('Daf 105', 'О555ОО34', 1.4, 98.75, 1),
('Volvo 47', 'А751ОА134', 1.34, 107.25, 3),
('Daf 105', 'В100ЕК34', 1.24, 88.5, 1),
('Gazelle 3302', 'А962ОО34', 1.1, 46.7, 4),
('Da', 'А104ЕА134', 1.54, 48.6, 1),/*delete*/
('TRUCK', 'В100ЕК34', 1.84, 88.5, 1);/*delete*/

insert into truck_to_type_cargo (fk_id_truck, fk_id_type_cargo)
values
(1, 1),
(1, 2),
(1, 3),
(1, 6),
(2, 3),
(2, 4),
(3, 3),
(3, 4),
(3, 5),
(4, 1),
(4, 3),   
(4, 4);

insert into flight (status_f, director_full_name, date_time_start, date_time_end, number_f, base_price, fk_id_truck, fk_id_worker, fk_id_city1, fk_id_city2, fk_id_driver1, fk_id_driver2, fk_id_customer)
values
('Выполнен', 'Кормин Никита Сергеевич', '2022-01-23 10:01:47', '2022-01-28 15:02:42', 1, 37500, 1, 1, 1, 2, 1, 2, 1),
('Выполнен', 'Кормин Никита Сергеевич', '2022-02-03 15:23:34', '2022-02-11 15:02:42', 2, 39200, 2, 2, 2, 3, 1, null, 2),
('Выполнен', 'Кормин Никита Сергеевич', '2022-02-21 11:51:21', '2022-02-27 19:01:52', 3, 65000, 3, 3, 1, 3, 3, 4, 3),
('Выполнен', 'Кормин Никита Сергеевич', '2022-03-09 12:51:37', '2022-03-16 18:42:16', 4, 46000, 4, 4, 3, 4, 2, null, 4),
('Отменён', 'Кормин Никита Сергеевич', '2022-03-30 09:03:37', '2022-04-05 17:00:42', 5, 40500, 1, 5, 5, 2, 1, 2, 5),
('Выполнен', 'Кормин Никита Сергеевич', '2022-03-31 13:13:32', '2022-04-05 14:52:22', 6, 33000, 2, 6, 5, 3, 1, null, 6),
('Отменён', 'Кормин Никита Сергеевич', '2022-04-02 08:14:02', '2022-04-02 10:11:35', 7, 46000, 3, 3, 2, 2, 3, 4, 7),
('Выполнен', 'Кормин Никита Сергеевич', '2022-04-03 11:21:32', '2022-04-13 14:53:10', 8, 36000, 4, 4, 3, 4, 2, null, 3),
('В процессе', 'Кормин Никита Сергеевич', '2022-04-06 14:51:47', '2022-04-15 14:52:22', 9, 42540, 1, 5, 1, 2, 1, 2, 3),
('В процессе', 'Кормин Никита Сергеевич', '2022-04-27 10:10:10', '2022-05-02 10:10:10', 10, 33600, 2, 6, 2, 3, 1, null, 7);/*zdelat update truck*/
 
insert into flight (status_f, director_full_name, date_time_start, date_time_end, number_f, base_price, fk_id_truck, fk_id_worker, fk_id_city1, fk_id_city2, fk_id_driver1, fk_id_driver2, fk_id_customer)
values
('В процессе', 'Кормин Никита Сергеевич', '2022-05-05 10:05:57', '2022-05-10 15:02:42', 11, 36541, 1, 1, 1, 2, 1, 2, 1),
('В процессе', 'Кормин Никита Сергеевич', '2022-05-12 15:13:34', '2022-05-17 15:02:42', 12, 39200, 2, 2, 2, 3, 1, null, 2),
('В процессе', 'Кормин Никита Сергеевич', '2022-05-21 11:51:21', '2022-05-27 19:01:52', 13, 65000, 3, 3, 1, 3, 3, 4, 3),
('В процессе', 'Кормин Никита Сергеевич', '2022-05-09 12:51:37', '2022-05-16 18:42:16', 14, 46000, 4, 4, 3, 4, 2, null, 4),
('Отменён', 'Кормин Никита Сергеевич', '2022-05-19 09:03:37', '2022-05-30 10:10:12', 15, 46572, 4, 5, 5, 2, 1, 2, 5),
('В процессе', 'Кормин Никита Сергеевич', '2022-05-31 13:13:32', '2022-06-06 14:52:22', 16, 31161, 3, 6, 5, 3, 1, null, 6);

insert into cargo (volume_cargo, weight, place_loading, place_unloading, fk_id_type_cargo, fk_id_flight)
values
(95.44, 5000, 'Завод НРП', 'Склад им. Васильева', 1, 1),
(105.27, 7530, 'База Газпром', 'КТК', 2, 2),
(84.64, 6543, 'Склад ОЛВР', 'Завод АЛПН', 3, 3),
(45.04, 3748, 'Региональный METRO', 'Магазин METRO', 4, 4),
(90.14, 4673, 'Склад МАВ35', 'Склад им. Васильева', 1, 5),
(102.2, 7201, 'База ВПК', 'КТК', 2, 6),
(80.24, 6145, 'База ООО Росток', 'База АПВ', 3, 7),
(43.01, 3208, 'Региональный METRO', 'Магазин METRO', 4, 8),
(70.14, 4300, 'Завод им. Аравова', 'Завод ПИНК', 1, 9),
(105.27, 7530, 'База Газпром', 'АЗС Газпром', 2, 10);/*update na zapravka*/

insert into cargo (volume_cargo, weight, place_loading, place_unloading, fk_id_type_cargo, fk_id_flight)
values
(93.44, 5000, 'Завод НРП', 'Склад им. Васева', 1, 11),
(103.2, 7530, 'База ГазЭнерго', 'КТГН', 1, 12),
(82.64, 6543, 'Склад ООО Пета', 'Завод АЛПН', 1, 13),
(42.14, 3748, 'Региональный METRO', 'Магазин METRO', 4, 14),
(89.14, 4673, 'Склад МАВ35', 'Склад им. Васильева', 6, 15),
(101.11, 7201, 'База ВПК', 'База КРВ', 5, 16);

insert into comment_c (text_c, grade, fk_id_customer, fk_id_flight)
values
('Всё вовремя, советую данную компанию по перевозкам!!!', 5, 1, 1),
('Хорошо, но задержка на 2 часа.', 4, 2, 2),
('Неудачный рейс! Задержка на 2 дня!', 3, 3, 3),
('Всё отлично, советую!', 5, 4, 4),
('Отлично!', 5, 5, 4),
('Всё отлично, советую!', 5, 6, 4),
('Неплохо, но я знаю, что они могут лучше', 4, 7, 4);

alter table flight
add check (date_time_start < date_time_end);

-- insert into truck (name_truck, number_sign, factor, volume, fk_id_category) values ("DDRSTG", "SET43W", "FG", "RTG", 3);

-- delete from category where id_category = 3;