create table if not exists life_position_types(
	id		serial			primary key,
	name	text not null
);

create table if not exists life_positions(
	id		serial				primary key,
	type_id	integer not null 	references life_position_types(id),
	name	text not null
);

create table if not exists family_statuses(
	id		serial					primary key,
	name	text not null
);

create table if not exists countries(
	id		integer					primary key,
	name	text not null
);

create table if not exists regions(
	id			integer				primary key,
	country_id	integer not null	references countries(id),
	name		text not null 
);

create table if not exists cities(
	id			integer				primary key,
	region_id 	integer not null	references regions(id),
	name		text not null
);

create table if not exists user_profile_main_info(
	user_id				integer			primary key	references user_profile_main_info(user_id),
	family_status_id	integer			references family_statuses(id),
	city_id				integer			references cities(id),
	surname				text not null,
	name				text not null,
	patronymic			text,
	avatar				text,
	status				text,
	birthdate			date
);

create table if not exists user_life_positions(
	id					serial				primary key,
	user_id				integer not null	references user_profile_main_info(user_id),
	life_position_id	integer not null	references life_positions(id),
	date				timestamp default current_timestamp not null
);

create table if not exists languages(
	id		serial			primary key,
	name	text not null
);

create table if not exists user_profile_languages(
	id 				serial 				primary key,
	user_id			integer not null	references user_profile_main_info(user_id),
	language_id		integer not null	references languages(id),
	date 			timestamp default current_timestamp not null
);

create table if not exists user_profile_carrers(
	id				serial				primary key,
	user_id			integer not null	references user_profile_main_info(user_id),
	city_id			integer not null	references cities(id),
	company			text not null,
	job				text,
	date_from		date,
	date_to			date
);

create table if not exists user_profile_military_services(
	id				serial				primary key,
	user_id 		integer not null	references user_profile_main_info(user_id),
	country_id 		integer not null	references countries(id),
	military_unit 	text not null,
	date_from 		date,
	date_to 		date
);

create table if not exists study_degrees(
	id		serial			primary key,
	name	text not null
);

create table if not exists study_forms(
	id		serial			primary key,
	name	text not null
);

create table if not exists study_directions(
	id		serial			primary key,
	name	text not null	
);

create table if not exists study_faculties(
	id		serial			primary key,
	name	text not null	
);

create table if not exists faculty_directions(
	faculty_id		integer	not null	references study_faculties(id),
	direction_id	integer	not null	references study_directions(id)
);

create table if not exists universities(
	id			serial				primary key,
	city_id		integer not null	references cities(id),
	name		text not null
);

create table if not exists university_faculties(
	university_id	integer not null	references universities(id),
	faculty_id		integer	not null	references study_faculties(id)
);

create table if not exists user_profile_universities(
	id				serial		primary key,
	user_id			integer		references user_profile_main_info(user_id),
	univercity_id	integer		references universities(id),
	degree_id		integer		references study_degrees(id),
	direction_id	integer		references study_directions(id),
	study_form_id	integer		references study_forms(id),
	date_from		date,
	date_to			date
);



--Представление, содержащее основную информацию о пользователе
create or replace view view_profile_base_info as
	select upmi.user_id id, upmi.surname, upmi.name, upmi.patronymic, upmi.avatar, upmi.status, upmi.birthdate, fs.name family_status, c.name city
	from user_profile_main_info upmi
		left join family_statuses fs on upmi.family_status_id = fs.id
		left join cities c on c.id = upmi.city_id;
		
--Представление, содержащее выбранные языки пользователя
create or replace view view_profile_languages as
	select upmi.user_id, upl.language_id, l.name language_name, upl.date 
	from user_profile_main_info upmi
		right join user_profile_languages upl on upl.user_id = upmi.user_id
		left join languages l on l.id = upl.language_id;

--Представление, содержащее информацию и выбранных жизненных позициях пользователя
create or replace view view_profile_life_positions as
	select upmi.user_id, lp.type_id, lpt.name type_name, lp.id position_id, lp.name position_name, ulp.date
	from user_profile_main_info upmi
		right join user_life_positions ulp on upmi.user_id = ulp.user_id
		left join life_positions lp on ulp.life_position_id = lp.id
		left join life_position_types lpt on lpt.id = lp.type_id;
		
--Представление, содержащее информацию о карьере пользователя
create or replace view view_profile_carrers as
	select upc.id, upmi.user_id, c.id city_id, c.name city_name, upc.company, upc.job, upc.date_from, upc.date_to
	from user_profile_main_info upmi
		right join user_profile_carrers upc on upc.user_id = upmi.user_id
		left join cities c on upc.city_id = c.id;

--Представление, содержащее информацию о военной службе пользователя
create or replace view view_profile_military_services as
	select upms.id, upmi.user_id, c.id country_id, c.name country_name, upms.military_unit, upms.date_from, upms.date_to
	from user_profile_main_info upmi
		right join user_profile_military_services upms on upms.user_id = upmi.user_id
		left join countries c on c.id = upms.country_id;