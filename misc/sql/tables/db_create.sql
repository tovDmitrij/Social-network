create table app_logs(
	cause	text not null,
	place	text not null,
	text	text not null,
	date	timestamp default current_timestamp not null
);

create table app_rules(
	id		serial					primary key,
	title	text not null,
	text	text not null,
	penalty text not null
);

create table app_user_roles(
	id					serial					primary key,
	name				text not null,
	can_ban_everything	boolean not null,
	can_assign_roles	boolean not null
);

create table users(
	id					serial						primary key,
	role_id				integer default 1 not null	references app_user_roles(id),
	login				text not null,
	password			text not null,
	registration_date	timestamp default current_timestamp not null
);

create table user_settings_main(
	user_id				integer			primary key	references users(id),
	profile_is_private	boolean not null
);

create table user_settings_notes(
	user_id						integer			primary key	references users(id),
	friends_can_create			boolean not null,
	friends_can_comment			boolean not null,
	not_friends_can_create		boolean not null,
	not_friends_can_comment		boolean not null
);

create table user_settings_messages(
	user_id										integer			primary key	references users(id),
	not_friends_can_write						boolean not null,
	not_friends_can_invite_into_conversation	boolean not null
);

create table groups(
	id				serial			primary key,
	creation_date	timestamp default current_timestamp not null
);

create table conversation_types(
	id		serial					primary key,
	name	text not null
);

create table conversations(
	id				serial					primary key,
	type_id			integer not null		references conversation_types(id),
	name			text not null,
	creation_date	timestamp default current_timestamp not null
);

create table app_user_banlists(
	id				serial						primary key,
	user_id			integer	not null			references users(id),
	moderator_id	integer	not null			references users(id),
	rule_id			integer	not null			references app_rules(id),
	text 			text not null,		
	date_from		timestamp default current_timestamp not null,
	date_to			timestamp not null
);

create table app_group_banlists(
	id				serial						primary key,
	group_id		integer	not null			references groups(id),
	moderator_id	integer	not null			references users(id),
	rule_id			integer	not null			references app_rules(id),
	text 			text not null,
	date_from		timestamp default current_timestamp not null,
	date_to			timestamp not null
);

create table app_conversation_banlists(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		timestamp default current_timestamp not null,
	date_to 		timestamp not null
);

create table app_ban_requests(
	id 		serial 				primary key,
	user_id integer not null 	references users(id),
	text 	text not null,
	date 	timestamp default current_timestamp not null
);

create table attitude_to_alcohol(
	id		serial					primary key,
	name	text not null
);

create table attitude_to_smoking(
	id		serial					primary key,
	name	text not null
);

create table main_things_in_people(
	id		serial					primary key,
	name	text not null
);

create table main_things_in_life(
	id		serial					primary key,
	name	text not null
);

create table world_outlook(
	id		serial					primary key,
	name	text not null
);

create table political_preferences(
	id		serial					primary key,
	name	text not null
);

create table user_life_positions(
	user_id		integer			primary key references users(id),
	pp_id		integer			references political_preferences(id),
	wo_id		integer			references world_outlook(id),
	mtl_id		integer			references main_things_in_life(id),
	mtp_id		integer			references main_things_in_people(id),
	ats_id		integer			references attitude_to_smoking(id),
	ata_id		integer			references attitude_to_alcohol(id),
	inspire		text
);

create table languages(
	id		serial					primary key,
	name	text not null
);

create table user_profile_languages(
	user_id			integer		references users(id),
	language_id		integer		references languages(id),
	primary key(user_id, language_id)
);

create table family_statuses(
	id		serial					primary key,
	name	text not null
);

create table countries(
	id		integer					primary key,
	name	text not null
);

create table regions(
	id			integer					primary key,
	country_id	integer not null		references countries(id),
	name		text not null 
);

create table cities(
	id			integer					primary key,
	region_id 	integer not null		references regions(id),
	name		text not null
);

create table user_profile_main_info(
	user_id				integer					primary key	references users(id),
	family_status_id	integer					references family_statuses(id),
	city_id				integer					references cities(id),
	surname				text not null,
	name				text not null,
	patronymic			text,
	avatar				bytea,
	status				text,
	birthdate			date
);

create table user_profile_career(
	user_id			integer			references users(id),
	city_id			integer			references cities(id),
	date_from		date,
	company_name	text,
	job				text,
	date_to			date,
	primary key(user_id, date_from)
);

create table user_profile_military_services(
	user_id 		integer 			references users(id),
	date_from 		date,
	country_id 		integer 			references countries(id),
	military_unit 	text,
	date_to 		date,
	primary key(user_id, date_from)
);

create table study_degrees(
	id		serial					primary key,
	name	text not null
);

create table study_forms(
	id		serial					primary key,
	name	text not null
);

create table study_directions(
	id		serial					primary key,
	name	text not null	
);

create table study_faculties(
	id		serial					primary key,
	name	text not null	
);

create table faculty_directions(
	faculty_id		integer		references study_faculties(id),
	direction_id	integer		references study_directions(id),
	primary key(faculty_id, direction_id)
);

create table universities(
	id			serial					primary key,
	city_id		integer not null		references cities(id),
	name		text not null
);

create table university_faculties(
	university_id	integer		references universities(id),
	faculty_id		integer		references study_faculties(id),
	primary key(university_id, faculty_id)
);

create table user_profile_universities(
	user_id			integer		references users(id),
	univercity_id	integer		references universities(id),
	degree_id		integer		references study_degrees(id),
	direction_id	integer		references study_directions(id),
	study_form_id	integer		references study_forms(id),
	date_from		date,
	date_to			date,
	primary key(user_id, univercity_id, degree_id, direction_id) 
);

create table conversation_member_roles(
	id					serial					primary key,
	name				text not null,
	can_ban_members		boolean not null,
	can_assign_roles	boolean not null
);

create table conversation_members(
	conversation_id		integer				references conversations(id),
	user_id				integer				references users(id),
	role_id				integer not null	references conversation_member_roles(id),
	primary key(conversation_id, user_id)
);

create table conversation_member_requests(
	conversation_id		integer						references conversations(id),
	user_id				integer						references users(id),
	member_id			integer						references users(id),
	date				timestamp default current_timestamp not null,
	primary key(conversation_id, user_id)
);

create table conversation_member_banlists(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	member_id 		integer not null 	references users(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		timestamp default current_timestamp not null,
	date_to 		timestamp not null
);

create table conversation_member_messages(
	id 				serial 				primary key,
	conversation_id integer not null	references conversations(id),
	member_id 		integer not null 	references users(id),
	text 			text not null,
	date 			timestamp default current_timestamp not null
);

create table user_friend_roles(
	id		serial					primary key,
	name	text not null
);

create table user_friend_lists(
	page_owner_id	integer						references users(id),
	friend_id		integer						references users(id),
	friend_role_id	integer not null			references user_friend_roles(id),
	date			timestamp default current_timestamp not null,
	primary key(page_owner_id, friend_id)
);

create table user_friend_requests(
	user_id_from	integer					references users(id),
	user_id_to		integer					references users(id),
	date			timestamp default current_timestamp not null,
	primary key (user_id_from, user_id_to)
);

create table user_group_lists(
	group_id	integer					references groups(id),
	user_id		integer					references users(id),
	date		timestamp default current_timestamp not null,
	primary key(group_id, user_id)
);

create table user_banlists(
	user_id_ban_from	integer					references users(id),
	user_id_ban_to		integer					references users(id),
	date				timestamp default current_timestamp not null,
	primary key(user_id_ban_from, user_id_ban_to)
);

create table user_comments(
	id			serial						primary key,
	user_id		integer not null			references users(id),
	text		text not null,
	date		timestamp default current_timestamp not null
);

create table user_comment_responses(
	comment_id_from		integer		references user_comments(id),
	comment_id_to		integer		references user_comments(id),
	primary key(comment_id_from, comment_id_to)
);

create table user_reactions(
	id 			serial 				primary key,
	user_id 	integer not null 	references users(id),
	reaction 	boolean not null
);

create table user_comment_reactions(
	comment_id 	integer references user_comments(id),
	reaction_id integer references user_reactions(id),
	primary key(comment_id, reaction_id)
);

create table user_notes(
	id 			serial 				primary key,
	user_id 	integer not null 	references users(id),
	text 		text not null,
	date 		timestamp default current_timestamp not null
);

create table user_note_reactions(
	note_id 	integer references user_notes(id),
	reaction_id integer references user_reactions(id),
	primary key(note_id, reaction_id)
);

create table user_comment_notes(
	note_id 	integer references user_notes(id),
	comment_id 	integer references user_comments(id),
	primary key(note_id, comment_id)
);

create table user_page_notes(
	note_id 		integer 			primary key references user_notes(id),
	page_owner_id 	integer not null 	references users(id)
);

create table group_page_notes(
	note_id 		integer 			primary key references user_notes(id),
	group_id 		integer not null 	references groups(id),
	is_admin 		boolean default false not null,
	is_commentable 	boolean default true not null
);

create table group_topics(
	topic_id 		integer 			primary key references user_notes(id),
	group_id 		integer not null 	references groups(id),
	title 			text not null,
	is_commentable 	boolean default true not null
);

create table group_main_info(
	group_id		integer					primary key	references groups(id),
	name			text not null,
	description		text,
	website_link	text
);

create table group_settings_main(
	group_id			integer					primary key	references groups(id),
	group_is_private	boolean default false not null
);

create table group_settings_notes(
	group_id					integer					primary key	references groups(id),
	members_can_create_notes	boolean default true not null,
	members_can_comments_notes	boolean default true not null
);

create table group_member_roles(
	id							serial					primary key,
	name						text not null,
	can_create_notes_by_group	boolean default false not null,
	can_create_topics			boolean default false not null,
	can_ban_users				boolean default false not null,
	can_delete_comments			boolean default false not null,
	can_delete_user_notes		boolean default false not null,
	can_assign_roles			boolean default false not null
);

create table group_members(
	group_id		integer			 	references groups(id),
	user_id			integer				references users(id),
	user_role_id	integer not null	references group_member_roles(id),
	primary key(group_id, user_id)
);

create table group_member_requests(
	group_id	integer					references groups(id),
	user_id		integer					references users(id),
	date		timestamp default current_timestamp not null,
	primary key(group_id, user_id)
);

create table group_member_banlists(
	id				serial						primary key,
	group_id		integer not null			references groups(id),
	user_id			integer not null			references users(id),
	moderator_id	integer not null			references users(id),
	rule_id 		integer not null 			references app_rules(id),
	text			text not null,
	date_from		timestamp default current_timestamp not null,
	date_to			timestamp not null
);