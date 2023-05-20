create table if not exists life_position_types(
	id		serial	primary key,
	name	text not null
);

create table if not exists life_positions(
	id		serial				primary key,
	type_id	integer not null 	references life_position_types(id),
	name	text not null
);

create table if not exists languages(
	id		serial					primary key,
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

create table if not exists group_member_roles(
	id		serial			primary key,
	name	text not null
);

create table if not exists user_friend_roles(
	id		serial					primary key,
	name	text not null
);

create table if not exists conversation_member_roles(
	id		serial			primary key,
	name	text not null
);



--Представление, содержащее информацию о жизненных позициях
create or replace view view_life_positions as
	select lp.id, lp.name position_name, lp.type_id, lps.name type_name
	from life_positions lp
		left join life_position_types lps on lp.type_id = lps.id;
		
--Представление, содержащее информацию о местах проживания
create or replace view view_places as
	select c.id city_id, c.name city_name, r.id region_id, r.name region_name, cr.id country_id, cr.name country_name
	from cities c
		left join regions r on c.region_id = r.id
		left join countries cr on r.country_id = cr.id;