create extension if not exists "uuid-ossp";

create table if not exists app_rules(
	id uuid default uuid_generate_v4() primary key,
	title text not null,
	description text not null,
	penalty text not null
); create index on app_rules(id);

create table if not exists app_user_roles(
	id uuid default uuid_generate_v4() primary key,
	name text not null,
	tag	text not null
); create index on app_user_roles(id); create index on app_user_roles(tag);

create table if not exists family_statuses(
	id uuid default uuid_generate_v4() primary key,
	name text not null,
	tag	text not null
); create index on family_statuses(id); create index on family_statuses(tag);

create table if not exists countries(
	id uuid default uuid_generate_v4() primary key,
	name text not null,
	tag	text not null
); create index on countries(id); create index on countries(tag);

create table if not exists regions(
	id uuid default uuid_generate_v4() primary key,
	country_id uuid not null references countries(id),
	name text not null,
	tag	text not null
); create index on regions(id); create index on regions(country_id); create index on regions(tag);

create table if not exists cities(
	id uuid default uuid_generate_v4() primary key,
	region_id uuid not null references regions(id),
	name text not null,
	tag text not null
); create index on cities(id); create index on cities(region_id); create index on cities(tag);

create table if not exists users(
	id uuid default uuid_generate_v4() primary key,
	role_id uuid not null references app_user_roles(id),
	email text not null,
	password text not null,
	reg_date decimal not null,
	refresh_token text,
	token_create_date decimal,
	token_expire_date decimal,

	family_status_id uuid references family_statuses(id),
	city_id uuid references cities(id),
	surname text not null,
	name text not null,
	avatar text,
	status text,
	birthdate decimal,
	profile_url text,

	profile_is_private boolean default false not null,
    friends_can_create_notes boolean default true not null,
    friends_can_comment_notes boolean default true not null,
    not_friends_can_write_msg boolean default true not null
); create index on users(id); create index on users(email, password); 
create index on users(family_status_id); create index on users(city_id); create index on users(profile_url);