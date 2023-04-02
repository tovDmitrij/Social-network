---------------------
-- СОЗДАНИЕ ТАБЛИЦ --
---------------------
create table if not exists app_logs(
	message	text not null,
	date	timestamp default current_timestamp not null
);

create table if not exists app_rules(
	id		serial			primary key,
	title	text not null,
	text	text not null,
	penalty text not null
);

create table if not exists app_user_roles(
	id		serial			primary key,
	name	text not null
);

create table if not exists users(
	id					serial						primary key,
	role_id				integer default 1 not null	references app_user_roles(id),
	email				text not null,
	password			text not null,
	registration_date	timestamp default current_timestamp not null
);

create table if not exists user_settings(
	user_id				integer			primary key	references users(id),
	profile_is_private	boolean default false not null,
	friends_can_create			boolean default true not null,
	friends_can_comment			boolean default true not null,
	not_friends_can_create		boolean default true not null,
	not_friends_can_comment		boolean default true not null,
	not_friends_can_write						boolean default true not null,
	not_friends_can_invite_into_conversation	boolean default true not null
);

create table if not exists groups(
	id				serial			primary key,
	creation_date	timestamp default current_timestamp not null
);

create table if not exists conversation_types(
	id		serial					primary key,
	name	text not null
);

create table if not exists conversations(
	id				serial					primary key,
	type_id			integer not null		references conversation_types(id),
	name			text not null,
	creation_date	timestamp default current_timestamp not null
);

create table if not exists app_user_banlists(
	id				serial						primary key,
	user_id			integer	not null			references users(id),
	moderator_id	integer	not null			references users(id),
	rule_id			integer	not null			references app_rules(id),
	text 			text not null,		
	date_from		timestamp default current_timestamp not null,
	date_to			timestamp not null
);

create table if not exists app_group_banlists(
	id				serial						primary key,
	group_id		integer	not null			references groups(id),
	moderator_id	integer	not null			references users(id),
	rule_id			integer	not null			references app_rules(id),
	text 			text not null,
	date_from		timestamp default current_timestamp not null,
	date_to			timestamp not null
);

create table if not exists app_conversation_banlists(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		timestamp default current_timestamp not null,
	date_to 		timestamp not null
);

create table if not exists app_ban_requests(
	id 		serial 				primary key,
	user_id integer not null 	references users(id),
	text 	text not null,
	date 	timestamp default current_timestamp not null
);

create table if not exists life_position_types(
	id		serial	primary key,
	name	text not null
);

create table if not exists life_positions(
	id		serial				primary key,
	type_id	integer not null 	references life_position_types(id),
	name	text not null
);

create table if not exists user_life_positions(
	id					serial		primary key,
	user_id				integer		references users(id),
	life_position_id	integer		references life_positions(id),
	date				timestamp default current_timestamp not null
);

create table if not exists languages(
	id		serial					primary key,
	name	text not null
);

create table if not exists user_profile_languages(
	id 				serial 		primary key,
	user_id			integer		references users(id),
	language_id		integer		references languages(id),
	date 			timestamp default current_timestamp not null
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
	user_id				integer			primary key	references users(id),
	family_status_id	integer			references family_statuses(id),
	city_id				integer			references cities(id),
	surname				text not null,
	name				text not null,
	patronymic			text,
	avatar				bytea,
	status				text,
	birthdate			date
);

create table if not exists user_profile_career(
	id				serial		primary key,
	user_id			integer		references users(id),
	city_id			integer		references cities(id),
	company_name	text,
	job				text,
	date_from		date,
	date_to			date
);

create table if not exists user_profile_military_services(
	id				serial		primary key,
	user_id 		integer 	references users(id),
	country_id 		integer 	references countries(id),
	military_unit 	text,
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
	user_id			integer		references users(id),
	univercity_id	integer		references universities(id),
	degree_id		integer		references study_degrees(id),
	direction_id	integer		references study_directions(id),
	study_form_id	integer		references study_forms(id),
	date_from		date,
	date_to			date
);

create table if not exists conversation_member_roles(
	id		serial			primary key,
	name	text not null
);

create table if not exists conversation_members(
	id					serial				primary key,
	conversation_id		integer	not null	references conversations(id),
	user_id				integer	not null	references users(id),
	role_id				integer not null	references conversation_member_roles(id)
);

create table if not exists conversation_member_requests(
	id					serial				primary key,
	conversation_id		integer	not null	references conversations(id),
	user_id				integer	not null	references users(id),
	member_id			integer	not null	references users(id),
	date				timestamp default current_timestamp not null
);

create table if not exists conversation_member_banlists(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	member_id 		integer not null 	references users(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		timestamp default current_timestamp not null,
	date_to 		timestamp not null
);

create table if not exists conversation_member_messages(
	id 				serial 				primary key,
	conversation_id integer not null	references conversations(id),
	member_id 		integer not null 	references users(id),
	text 			text not null,
	date 			timestamp default current_timestamp not null
);

create table if not exists user_friend_roles(
	id		serial					primary key,
	name	text not null
);

create table if not exists user_friend_lists(
	id				serial				primary key,
	page_owner_id	integer	not null	references users(id),
	friend_id		integer	not null	references users(id),
	friend_role_id	integer not null	references user_friend_roles(id),
	date			timestamp default current_timestamp not null
);

create table if not exists user_friend_requests(
	id				serial				primary key,
	user_id_from	integer	not null	references users(id),
	user_id_to		integer	not null	references users(id),
	date			timestamp default current_timestamp not null
);

create table if not exists user_group_lists(
	id			serial				primary key,
	group_id	integer	not null	references groups(id),
	user_id		integer	not null	references users(id),
	date		timestamp default current_timestamp not null
);

create table if not exists user_banlists(
	id					serial				primary key,
	user_id_ban_from	integer	not null	references users(id),
	user_id_ban_to		integer	not null	references users(id),
	date				timestamp default current_timestamp not null
);

create table if not exists user_comments(
	id			serial				primary key,
	user_id		integer not null	references users(id),
	text		text not null,
	date		timestamp default current_timestamp not null
);

create table if not exists user_comment_responses(
	comment_id_from		integer		references user_comments(id),
	comment_id_to		integer		references user_comments(id)
);

create table if not exists user_reactions(
	id 			serial 				primary key,
	user_id 	integer not null 	references users(id),
	reaction 	boolean not null
);

create table if not exists user_comment_reactions(
	comment_id 	integer references user_comments(id),
	reaction_id integer references user_reactions(id)
);

create table if not exists user_notes(
	id 			serial 				primary key,
	user_id 	integer not null 	references users(id),
	text 		text not null,
	date 		timestamp default current_timestamp not null
);

create table if not exists user_note_reactions(
	note_id 	integer references user_notes(id),
	reaction_id integer references user_reactions(id)
);

create table if not exists user_comment_notes(
	note_id 	integer references user_notes(id),
	comment_id 	integer references user_comments(id)
);

create table if not exists user_page_notes(
	note_id 		integer 			primary key references user_notes(id),
	page_owner_id 	integer not null 	references users(id)
);

create table if not exists group_page_notes(
	note_id 		integer 			primary key references user_notes(id),
	group_id 		integer not null 	references groups(id),
	is_admin 		boolean default false not null,
	is_commentable 	boolean default true not null
);

create table if not exists group_topics(
	topic_id 		integer 			primary key references user_notes(id),
	group_id 		integer not null 	references groups(id),
	title 			text not null,
	is_commentable 	boolean default true not null
);

create table if not exists group_main_info(
	group_id		integer				primary key	references groups(id),
	name			text not null,
	description		text,
	website_link	text
);

create table if not exists group_settings_main(
	group_id			integer		primary key	references groups(id),
	group_is_private	boolean default false not null,
	members_can_create_notes	boolean default true not null,
	members_can_comments_notes	boolean default true not null
);

create table if not exists group_member_roles(
	id		serial			primary key,
	name	text not null
);

create table if not exists group_members(
	id				serial				primary key,
	group_id		integer	not null	references groups(id),
	user_id			integer	not null	references users(id),
	user_role_id	integer not null	references group_member_roles(id),
	date 			timestamp default current_timestamp not null
);

create table if not exists group_member_requests(
	id			serial				primary key,
	group_id	integer	not null	references groups(id),
	user_id		integer	not null	references users(id),
	date		timestamp default current_timestamp not null
);

create table if not exists group_member_banlists(
	id				serial				primary key,
	group_id		integer not null	references groups(id),
	user_id			integer not null	references users(id),
	moderator_id	integer not null	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text			text not null,
	date_from		timestamp default current_timestamp not null,
	date_to			timestamp not null
);



----------------------------
-- СОЗДАНИЕ ПРЕДСТАВЛЕНИЙ --
----------------------------
--Представление, содержащее основную информацию о пользователе
create or replace view view_user_base_info as
	select
		u.id, u.registration_date, aur.name role_title, upmi.surname, upmi.name, upmi.patronymic, upmi.avatar, upmi.status, upmi,birthdate, fs.name family_status, c.name city
	from users u
		left join user_profile_main_info upmi on u.id = upmi.user_id
		left join app_user_roles aur on u.role_id = aur.id
		left join family_statuses fs on upmi.family_status_id = fs.id
		left join cities c on c.id = upmi.city_id;
		
--Представление, содержащее выбранные языки пользователя
create or replace view view_profile_languages as
	select upl.language_id id, u.id user_id, l.name, upl.date 
	from users u
		right join user_profile_languages upl on upl.user_id = u.id
		left join languages l on l.id = upl.language_id;

--Представление, содержащее информацию и выбранных жизненных позициях пользователя
create or replace view view_profile_life_positions as
	select 
		u.id user_id, lp.type_id, lpt.name type_name, lp.id position_id, lp.name position_name, ulp.date
	from users u
		right join user_life_positions ulp on u.id = ulp.user_id
		left join life_positions lp on ulp.life_position_id = lp.id
		left join life_position_types lpt on lpt.id = lp.type_id;
	
--Представление, содержащее информацию о жизненных позициях
create or replace view view_life_positions as
	select lp.id, lp.name position_name, lp.type_id, lps.name type_name
	from life_positions lp
		left join life_position_types lps on lp.type_id = lps.id
		

------------------------
-- СОЗДАНИЕ ТРИГГЕРОВ --
------------------------
--tbd



----------------------------
-- СОЗДАНИЕ ПОЛЬЗОВАТЕЛЕЙ --
----------------------------
create user user_default with password 'jwu7iSQ';
revoke all privileges on database social_network from user_default;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO user_default;

create user user_moderator with password 'g2Wu18x';
revoke all privileges on database social_network from user_moderator;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO user_moderator;

create user user_admin with password '52iJs*x';
revoke all privileges on database social_network from user_admin;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO user_admin;