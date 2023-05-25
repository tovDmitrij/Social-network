create table if not exists app_user_roles(
	id		serial			primary key,
	name	text not null
);

create table if not exists users(
	id					serial				primary key,
	role_id				integer 			references app_user_roles(id),
	email				text not null,
	password			text not null,
	registration_date	timestamp default current_timestamp not null
);

create table if not exists user_tokens(
	user_id 		integer 			primary key references users(id),
	refresh_token 	text not null,
	create_date 	timestamp not null,
	expire_date 	timestamp not null
);



create or replace view view_users as
	select u.id, u.role_id, r.name role_name, u.email, u.password, u.registration_date
	from users u
		left join app_user_roles r on u.role_id = r.id;
	
	
	
create or replace function add_user() returns trigger as
	$$
		begin
			select id from app_user_roles into new.role_id
			where name = 'Пользователь';
			return new;
		end;
	$$ language plpgsql;
create or replace trigger insert_user before insert on users for each row
	execute function add_user();